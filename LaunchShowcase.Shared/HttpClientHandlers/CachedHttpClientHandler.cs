using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using OwlCore.Extensions;
using Windows.Storage;

namespace LaunchShowcase.Sdk.HttpClientHandlers
{
    /// <summary>
    /// An <see cref="CompositeHttpClientHandlerActionBase"/> that provides caching functionality.
    /// </summary>
    /// <remarks>
    /// Taken and modified from <see cref="OwlCore.Net.HttpClientHandlers.CachedHttpClientHandlerAction"/>.
    /// </remarks>
    public class CachedHttpClientHandler : HttpClientHandler
    {
        private readonly StorageFolder _cacheFolder;

        /// <summary>
        /// Creates an instance of the <see cref="CachedHttpClientHandler"/>.
        /// </summary>
        public CachedHttpClientHandler(StorageFolder cacheFolder)
        {
            _cacheFolder = cacheFolder;
        }

        /// <inheritdoc cref="HttpClientHandler.SendAsync(HttpRequestMessage, CancellationToken)"/>
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // check if item is cached
            var cachedEntry = await ReadCachedFile(_cacheFolder, request.RequestUri.OriginalString);

            var shouldUseCache = true;

            if (cachedEntry != null && shouldUseCache)
            {
                // if cache found
                if (cachedEntry.ContentBytes != null)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new ByteArrayContent(cachedEntry.ContentBytes);

                    return response;
                }
            }

            // Code has been hacked and modified to always return data.
            // This should never run, but is left as a backup.
            var result = await base.SendAsync(request, cancellationToken);

            await WriteCachedFile(_cacheFolder, request.RequestUri.OriginalString, result);

            return result;
        }

        /// <summary>
        /// Writes cache to the file.
        /// </summary>
        /// <param name="folder">Path to cache file.</param>
        /// <param name="request">API request information.</param>
        /// <param name="response">The response string to be cached.</param>
        /// <returns>Returns a <see cref="Task" /></returns>
        public static async Task WriteCachedFile(StorageFolder folder, string request, HttpResponseMessage response)
        {
            var cachedFile = await GetCachedFile(request);
            var contentBytes = await response.Content.ReadAsByteArrayAsync();

            var cacheEntry = new CacheEntry
            {
                ContentBytes = contentBytes,
                RequestUri = request,
                TimeStamp = DateTime.UtcNow,
            };

            var serializedData = JsonSerializer.Serialize(cacheEntry);

            await FileIO.WriteTextAsync(cachedFile, serializedData);
        }

        /// <summary>
        /// Read cache data.
        /// </summary>
        /// <param name="folder">Path to the cache folder</param>
        /// <param name="request">API request information</param>
        /// <returns>Information related to cache in a <see cref="CacheEntry"/></returns>
        private static async Task<CacheEntry> ReadCachedFile(StorageFolder folder, string request)
        {
            var cachedFile = await GetCachedFile(request);

            CacheEntry cacheEntry = null;
            bool fileExists = cachedFile == null;


            try
            {
                var fileBytes = await FileIO.ReadTextAsync(cachedFile);
                cacheEntry = JsonSerializer.Deserialize<CacheEntry>(fileBytes);
            }
            catch (Exception ex)
            {
                if (fileExists)
                    Debug.WriteLine($"WARNING: Failed to read or deserialized the file at \"{cachedFile}\". The data will be discarded. ({ex})");
            }

            if (cacheEntry?.RequestUri is null)
                return null;

            // Check if the cached request matches the given (could be a hash collision).
            if (!request.Contains(cacheEntry.RequestUri))
                return null;

            return cacheEntry;
        }

        /// <summary>
        /// Generates a file for the cache.
        /// </summary>
        /// <param name="folder">Path to the directory where the file is stored.</param>
        /// <param name="requestUri">The request uri.</param>
        /// <returns>The file path.</returns>
        private static async Task<StorageFile> GetCachedFile(string requestUri)
        {
            var fileName = requestUri.HashMD5Fast() + ".cache";

            try
            {
                var uri = new Uri("ms-appx:///Assets/HttpCache/" + fileName);
                
                return await StorageFile.GetFileFromApplicationUriAsync(uri);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }

    /// <summary>
    /// Decides if the given URL should return data from cache.
    /// </summary>
    /// <param name="uri">The URL to decide against.</param>
    /// <param name="cacheEntry">The cache entry for this request, if found.</param>
    /// <returns><see langword="true"/> if a cached value should be returned/cached, otherwise false.</returns>
    public delegate bool CacheRequestFilter(Uri uri, CacheEntry? cacheEntry = null);

    /// <summary>
    /// A class to hold and save cached data.
    /// </summary>
    public class CacheEntry
    {
        /// <summary>
        /// The cached response object.
        /// </summary>
        public string? RequestUri { get; set; }

        /// <summary>
        /// The http response content.
        /// </summary>
        public byte[]? ContentBytes { get; set; }

        /// <summary>
        /// Timestamp for the cache.
        /// </summary>
        public DateTime TimeStamp { get; set; }
    }
}