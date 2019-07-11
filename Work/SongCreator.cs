using System.Text.RegularExpressions;
using NowPlaying.Models;

namespace NowPlaying.Work
{
    public class SongCreator
    {
        public SongPlaying Song { get; set; }

        public SongCreator()
        {
            Song =  new SongPlaying();
            string nowPlayingSTR = WinampFrontEndLib.WinampLib.GetCurrentSongTitle();
            Song.FullTitle = nowPlayingSTR;

            if (nowPlayingSTR.Contains("#"))
                nowPlayingSTR = nowPlayingSTR.Remove(nowPlayingSTR.IndexOf("#"));

            if (nowPlayingSTR.StartsWith("NEW"))
                nowPlayingSTR = nowPlayingSTR.Replace("NEW -", "");
            else if (nowPlayingSTR.StartsWith("New"))
                nowPlayingSTR = nowPlayingSTR.Replace("New -", "");

            string regex = "(\\[.*\\])|(\".*\")|('.*')|(\\(.*\\))";
            regex = @" ?\[.*?\]| ?\(.*?\)| ?\'| ?\"".*?\""";
            regex = @" ?\[.*?\]| ?\(.*?\)| ?\"".*?\""";

            nowPlayingSTR = Regex.Replace(nowPlayingSTR, regex, "");
            string[] split = nowPlayingSTR.Split('-');
            
            int startIndex = 0;
            if (int.TryParse(split[0].Replace("/", ""), out int numAux))
                startIndex = 1;

            Song.Artist = split[startIndex].Trim();
            Song.Album = split[startIndex + 1].Trim();
            Song.Album = Song.Album.Replace("*", "");
            if (split.Length > 2)
                Song.Title = split[startIndex + 2].Trim();
            else
                Song.Title = split[startIndex + 1].Trim();

            string artistName = Song.Artist;
            string songNameSearch = Song.Title;

            Song.Album = Regex.Replace(Song.Album, regex, "");
            string regex2 = @" ?\(.*?$";
            Song.Album = Regex.Replace(Song.Album, regex2, "");
            Song.Album = Song.Album.Replace("[", "").Trim();
        }
    }
}