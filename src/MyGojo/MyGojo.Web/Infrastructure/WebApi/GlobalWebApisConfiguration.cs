﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MyGojo.Web.Infrastructure.WebApi
{
    public class GlobalWebApisConfiguration
    {
        public static void Configure()
        {
            HttpConfiguration configuration = GlobalConfiguration.Configuration;

            // Add custom JsonNetFormatter at top to make it the default instead of the MVC built-in and limited
            // DataContractJsonSerializer - no support for untyped values like object, dynamic or anonymous types
            //                            - has Microsoft AJAX style Date formatting
            //                            - for types like Dictionaries it has very ugly serialization formats

            JsonSerializerSettings serializerSettings = new JsonSerializerSettings();
            serializerSettings.Converters.Add(new IsoDateTimeConverter());

            configuration.Formatters.Insert(0, new JsonNetFormatter(serializerSettings));

            // No removal of built-in to handle JsonValue, JsonObject, and JsonArray as intended
            // Custom formatter simply takes precedence since they process in sequence.
        }
    }
}