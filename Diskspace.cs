using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SonarrApi.Classes;

namespace SonarrApi
{
    partial class Main
    {
        /// <summary>
        /// Gets the amount of Diskspace for each drive
        /// </summary>
        /// <returns>Diskspace Class</returns>
        public Diskspace [] getDiskspace()
        {
            var stream = ApiGetRequest(_apiKey, "Diskspace");
            return JsonConvert.DeserializeObject<Diskspace []>(stream);
        }
    }

    public class Diskspace
    {
        public string path { get; set; }
        public string label { get; set; }
        public long freeSpace { get; set; }
        public long totalSpace { get; set; }
    }
}
