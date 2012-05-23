using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyGojo.Web.Models
{

    /*
      // Create Json.Net formatter serializing DateTime using the ISO 8601 format

         JsonSerializerSettings serializerSettings = new JsonSerializerSettings();
         serializerSettings.Converters.Add(new IsoDateTimeConverter());
         config.Formatters[0] = new JsonNetFormatter(serializerSettings);
     */




    public class DifficultToSerialize
    {
        private readonly DateTime _created = DateTime.UtcNow;
        private readonly Dictionary<int, string> _colorMap = new Dictionary<int, string>
            {
                { 1, "blue"},
                { 2, "red" },
                { 3, "green" },
                { 4, "black" },
                { 5, "white" },
            };

 
        public DateTime Created { get { return _created; } }
        public IDictionary<int, string> ColorMap { get { return _colorMap; } }
    }
}