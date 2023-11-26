﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace Linode.Api.Objets.Region.Get
{
    public class Response
    {
        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public List<Region> Data { get; set; } = new List<Region>();

        [JsonProperty("page", NullValueHandling = NullValueHandling.Ignore)]
        public long Page { get; set; } = 0;

        [JsonProperty("pages", NullValueHandling = NullValueHandling.Ignore)]
        public long Pages { get; set; } = 0;

        [JsonProperty("results", NullValueHandling = NullValueHandling.Ignore)]
        public long Results { get; set; } = 0;
    }
}
