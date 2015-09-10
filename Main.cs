using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using Newtonsoft.Json;
using RestSharp;
using SonarrApi.Classes;

namespace SonarrApi
{
    public partial class Main
    {
        public string _apiKey = @"1e085a3ca4e84614be9fb11bfbd924d4";
        private string _host = @"http://beast:8989/api";
        private int _port = 8989;

        public CalendarEntry[] getCalendar()
        {
            var stream = ApiGetRequest(_apiKey, "Calendar");
            return JsonConvert.DeserializeObject<CalendarEntry[]>(stream);
        }


        /// <summary>
        /// Gets Calendar Entries from a start date to an end date
        /// </summary>
        /// <param name="startDate">YYYY-MM-DD</param>
        /// <param name="endDate">YYYY-MM-DD</param>
        /// <returns></returns>
        public CalendarEntry[] getCalendar(string startDate, string endDate)
        {
            var apiMethod = string.Format("Calendar?start={0}&end={1}",startDate,endDate);
            var stream = ApiGetRequest(_apiKey, apiMethod);
            return JsonConvert.DeserializeObject<CalendarEntry[]>(stream);
        }

        public SystemStatus getStatus()
        {
            var stream = ApiGetRequest(_apiKey, "system/status");
            return JsonConvert.DeserializeObject<SystemStatus>(stream);
        }

        public SeriesEntry[] getSeriesList()
        {
            var stream = ApiGetRequest(_apiKey, "series");
            return JsonConvert.DeserializeObject<SeriesEntry[]>(stream);
        }

        public SeriesEntry getSeries(int seriesId)
        {
            var apiEndpoint = string.Format("series/{0}", seriesId);
            var stream = ApiGetRequest(_apiKey, apiEndpoint);
            return JsonConvert.DeserializeObject<SeriesEntry>(stream);
        }

    }
}
