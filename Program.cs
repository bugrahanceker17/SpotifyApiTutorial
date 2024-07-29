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

Console.WriteLine("");
Console.WriteLine("");
Console.Write("Search a music : ");
string? q = Console.ReadLine();

var searchResult = await SearchForItem.Execute(q, SearchType._TRACK);

Console.WriteLine("Search result : ");
Console.WriteLine("-----------------------");

for (int i = 0; i < searchResult.tracks.items.Count; i++)
{
    Console.WriteLine($"{i+1} -> {searchResult.tracks.items[i].name} ({string.Join(",", searchResult.tracks.items[i].artists.Select(c=>c.name))})");    
}

Console.WriteLine("");
Console.WriteLine("");
Console.Write("Please select a music : ");
int selectedSearch = Convert.ToInt32(Console.ReadLine()) - 1;

SearchForItemExternalIdsItem selectedSearchItem = searchResult.tracks.items[selectedSearch];











