using Newtonsoft.Json;
using SpotifyApiTutorial.Constants;

namespace SpotifyApiTutorial.Methods;

public static class GetPlaylistItems
{
    public static async Task<GetPlaylistItemsResponse> Execute(string playlistId)
    {
        HttpClient client = new HttpClient();
        
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"https://api.spotify.com/v1/playlists/{playlistId}/tracks?market=TR");
        
        request.Headers.Add("Authorization", $"Bearer {DataConfig.AccessToken}");
        
        HttpResponseMessage response = await client.SendAsync(request);
        
        client.Dispose();

        string responseString = await response.Content.ReadAsStringAsync();
        
        GetPlaylistItemsResponse? playListItems =  JsonConvert.DeserializeObject<GetPlaylistItemsResponse>(responseString);

        return playListItems;
    }
}

public class GetPlaylistItemsResponse
{
    public string href { get; set; }
    public List<ItemForPlaylistItem> items { get; set; }
    public int limit { get; set; }
    public string next { get; set; }
    public int offset { get; set; }
    public object previous { get; set; }
    public int total { get; set; }
}

public class AddedBy
    {
        public ExternalUrls2 external_urls { get; set; }
        public string href { get; set; }
        public string id { get; set; }
        public string type { get; set; }
        public string uri { get; set; }
    }

    public class Album
    {
        public List<string> available_markets { get; set; }
        public string type { get; set; }
        public string album_type { get; set; }
        public string href { get; set; }
        public string id { get; set; }
        public List<ImageForPlaylistItem> images { get; set; }
        public string name { get; set; }
        public string release_date { get; set; }
        public string release_date_precision { get; set; }
        public string uri { get; set; }
        public List<Artist> artists { get; set; }
        public ExternalUrls external_urls { get; set; }
        public int total_tracks { get; set; }
    }

    public class Artist
    {
        public ExternalUrls external_urls { get; set; }
        public string href { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string uri { get; set; }
    }

    public class ExternalIds
    {
        public string isrc { get; set; }
    }

    public class ExternalUrls2
    {
        public string spotify { get; set; }
    }

    public class ImageForPlaylistItem
    {
        public int height { get; set; }
        public string url { get; set; }
        public int width { get; set; }
    }

    public class ItemForPlaylistItem
    {
        public DateTime added_at { get; set; }
        public AddedBy added_by { get; set; }
        public bool is_local { get; set; }
        public object primary_color { get; set; }
        public Track track { get; set; }
        public VideoThumbnail video_thumbnail { get; set; }
    }

    public class Track
    {
        public string preview_url { get; set; }
        public List<string> available_markets { get; set; }
        public bool @explicit { get; set; }
        public string type { get; set; }
        public bool episode { get; set; }
        public bool track { get; set; }
        public Album album { get; set; }
        public List<Artist> artists { get; set; }
        public int disc_number { get; set; }
        public int track_number { get; set; }
        public int duration_ms { get; set; }
        public ExternalIds external_ids { get; set; }
        public ExternalUrls external_urls { get; set; }
        public string href { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public int popularity { get; set; }
        public string uri { get; set; }
        public bool is_local { get; set; }
    }

    public class VideoThumbnail
    {
        public object url { get; set; }
    }