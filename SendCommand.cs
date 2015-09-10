using System.Linq;
using System.Text;
using Newtonsoft.Json;
using SonarrApi.Classes;

namespace SonarrApi
{
    partial class Main
    {
        public PostStatus sendCommand(CommandTypes command)
        {
            var body = new { name = command.ToString() };
            return _sendCommand(body);
        }

        public PostStatus sendCommand(CommandTypes command, string[] parameters)
        {

            var stringBuilder = new StringBuilder();
            if (parameters != null)
            {
                for (int i = 0; i < parameters.Count(); i = i + 2)
                {
                    stringBuilder.AppendLine(string.Format("{0}:{1},", parameters[i], parameters[i + 1]));
                }
            }
            var body = new { name = command.ToString(), stringBuilder };
            return _sendCommand(body);
        }

        private PostStatus _sendCommand(object body)
        {
            var apiMethod = string.Format("command");
            var stream = ApiPostRequest(_apiKey, apiMethod, body);
            return JsonConvert.DeserializeObject<PostStatus>(stream);
        }

        public enum CommandTypes { RefreshSeries, RescanSeries, EpisodeSearch, SeasonSearch, SeriesSearch, DownloadedEpisodesScan, RssSync };
    }
}
