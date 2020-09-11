using Newtonsoft.Json;
using System;

namespace UPSAssignment.Service.Model
{
    public class ServiceMainResponse
    {
        [JsonProperty("code")]
        public int Code { get; set; }
        [JsonProperty("meta")]
        public Meta Meta { get; set; }
        [JsonProperty("data")]
        public dynamic Data { get; set; }
    }

    public class MessageData
    {
        public string Field { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return Field + " " + Message;
        }
    }


    public class Pagination
    {
        [JsonProperty("total")]
        public int Total { get; set; }
        [JsonProperty("pages")]
        public int Pages { get; set; }
        [JsonProperty("page")]
        public int Page { get; set; }
        [JsonProperty("limit")]
        public int Limit { get; set; }
    }

    public class Meta
    {
        [JsonProperty("pagination")]
        public Pagination Pagination { get; set; }
    }

    public class UserInfo
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("gender")]
        public string Gender { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("created_at")]
        public DateTime Created_At { get; set; }
        [JsonProperty("updated_at")]
        public DateTime Updated_At { get; set; }
    }
}
