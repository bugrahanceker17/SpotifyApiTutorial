using Newtonsoft.Json;
using SpotifyApiTutorial.Constants;

namespace SpotifyApiTutorial.Methods;

public static class GetAccessToken
{
   public static async Task<string> Execute()
   {
      HttpClient client = new HttpClient();
    
      HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "https://accounts.spotify.com/api/token");

      request.Content = new FormUrlEncodedContent(new[]
      {
         new KeyValuePair<string, string>("grant_type", "client_credentials"),
         new KeyValuePair<string, string>("client_id", DataConfig.ClientId),
         new KeyValuePair<string, string>("client_secret", DataConfig.ClientSecret)
      });
      
      HttpResponseMessage response = await client.SendAsync(request);
      
      string tokenData = await response.Content.ReadAsStringAsync();
      
      TokenData? accessToken = JsonConvert.DeserializeObject<TokenData>(tokenData);
      
      client.Dispose();
      
      return accessToken.access_token;
   }
}

public class TokenData
{
   public string access_token { get; set; }
   public string token_type { get; set; }
   public int expires_in { get; set; }
}