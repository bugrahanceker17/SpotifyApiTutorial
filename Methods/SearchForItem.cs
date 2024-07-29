using Newtonsoft.Json;
using SpotifyApiTutorial.Constants;

namespace SpotifyApiTutorial.Methods;

public static class SearchForItem
{
    public static async Task<SearchForItemResponse> Execute(string query, string type, int limit = 20, int offset = 0)
    {
        HttpClient client = new HttpClient();

        string url = $"https://api.spotify.com/v1/search?q={query}&type={type}&limit={limit}&offset={offset}&market=TR";
    
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
        
        request.Headers.Add("Authorization", $"Bearer {DataConfig.AccessToken}");
        
        HttpResponseMessage response = await client.SendAsync(request);
        
        client.Dispose();
        
        string responseString = await response.Content.ReadAsStringAsync();
        
        SearchForItemResponse? result = JsonConvert.DeserializeObject<SearchForItemResponse>(responseString);
        
        return result;
    }
}

    public class SearchForItemAlbum
    {
        public string album_type { get; set; }
        public List<SearchForItemArtist> artists { get; set; }
        public SearchForItemExternalIdsExternalUrls external_urls { get; set; }
        public string href { get; set; }
        public string id { get; set; }
        public List<SearchForItemExternalIdsImage> images { get; set; }
        public bool is_playable { get; set; }
        public string name { get; set; }
        public string release_date { get; set; }
        public string release_date_precision { get; set; }
        public int total_tracks { get; set; }
        public string type { get; set; }
        public string uri { get; set; }
    }

    public class SearchForItemArtist
    {
        public SearchForItemExternalIdsExternalUrls external_urls { get; set; }
        public string href { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string uri { get; set; }
    }

    public class SearchForItemExternalIdsExternalIds
    {
        public string isrc { get; set; }
    }

    public class SearchForItemExternalIdsExternalUrls
    {
        public string spotify { get; set; }
    }

    public class SearchForItemExternalIdsImage
    {
        public int height { get; set; }
        public string url { get; set; }
        public int width { get; set; }
    }

    public class SearchForItemExternalIdsItem
    {
        public SearchForItemAlbum album { get; set; }
        public List<SearchForItemArtist> artists { get; set; }
        public int disc_number { get; set; }
        public int duration_ms { get; set; }
        public bool @explicit { get; set; }
        public SearchForItemExternalIdsExternalIds external_ids { get; set; }
        public SearchForItemExternalIdsExternalUrls external_urls { get; set; }
        public string href { get; set; }
        public string id { get; set; }
        public bool is_local { get; set; }
        public bool is_playable { get; set; }
        public string name { get; set; }
        public int popularity { get; set; }
        public string preview_url { get; set; }
        public int track_number { get; set; }
        public string type { get; set; }
        public string uri { get; set; }
    }

    public class SearchForItemResponse
    {
        public SearchForItemExternalIdsTracks tracks { get; set; }
    }

    public class SearchForItemExternalIdsTracks
    {
        public string href { get; set; }
        public List<SearchForItemExternalIdsItem> items { get; set; }
        public int limit { get; set; }
        public string next { get; set; }
        public int offset { get; set; }
        public object previous { get; set; }
        public int total { get; set; }
    }