using SpotifyApiTutorial.Constants;
using SpotifyApiTutorial.Methods;

string accessToken = await GetAccessToken.Execute();

if (string.IsNullOrEmpty(accessToken))
    return;

DataConfig.AccessToken = accessToken;

GetUsersPlaylistResponse usersPlaylists = await GetUsersPlaylists.Execute();

Console.WriteLine("User Playlist : ");

foreach (var item in usersPlaylists.items)
{
    Console.WriteLine(item.name);
}

Console.WriteLine("------------");
Console.WriteLine("------------");

List<string> playlistIds = usersPlaylists.items.Select(c => c.id).ToList();

foreach (string item in playlistIds)
{
    var playlists = await GetPlaylistItems.Execute(item);

    Console.WriteLine("All musics in Playlist : ");
    Console.WriteLine("------------");
    foreach (var it in playlists.items)
    {
        Console.WriteLine($"{it.track?.artists.FirstOrDefault()?.name} - {it.track?.name}");
    }
}







