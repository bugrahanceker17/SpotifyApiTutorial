using Newtonsoft.Json;
using SpotifyApiTutorial.Constants;

namespace SpotifyApiTutorial.Methods;

public static class GetUsersPlaylists
{
    public static async Task<GetUsersPlaylistResponse> Execute()
    {
        HttpClient client = new HttpClient();
        
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"https://api.spotify.com/v1/users/{DataConfig.UserId}/playlists?offset=0&limit=50");
        
        request.Headers.Add("Authorization", $"Bearer {DataConfig.AccessToken}");
        
        HttpResponseMessage response = await client.SendAsync(request);
        
        client.Dispose();

        string responseString = await response.Content.ReadAsStringAsync();
        
        GetUsersPlaylistResponse? playlists = JsonConvert.DeserializeObject<GetUsersPlaylistResponse>(responseString);

        return playlists;
    }
}

public class GetUsersPlaylistResponse
{
    public string href { get; set; }
    public int limit { get; set; }
    public object next { get; set; }
    public int offset { get; set; }
    public object previous { get; set; }
    public int total { get; set; }
    public List<Item> items { get; set; }
}

public class ExternalUrls
{
    public string spotify { get; set; }
}

public class Image
{
    public string url { get; set; }
    public int? height { get; set; }
    public int? width { get; set; }
}

public class Item
{
    public bool collaborative { get; set; }
    public string description { get; set; }
    public ExternalUrls external_urls { get; set; }
    public string href { get; set; }
    public string id { get; set; }
    public List<Image> images { get; set; }
    public string name { get; set; }
    public Owner owner { get; set; }
    public bool @public { get; set; }
    public string snapshot_id { get; set; }
    public Tracks tracks { get; set; }
    public string type { get; set; }
    public string uri { get; set; }
    public string primary_color { get; set; }
}

public class Owner
{
    public ExternalUrls external_urls { get; set; }
    public string href { get; set; }
    public string id { get; set; }
    public string type { get; set; }
    public string uri { get; set; }
    public string display_name { get; set; }
}

public class Tracks
{
    public string href { get; set; }
    public int total { get; set; }
}