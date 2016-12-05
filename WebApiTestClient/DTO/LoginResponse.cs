using Newtonsoft.Json;

namespace WebApiTestClient.DTO
{
    class LoginResponse
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public decimal expires_in { get; set; }
        public decimal dupuis_user_id { get; set; }
        [JsonProperty(".issued")]
        public string issued { get; set; }
        [JsonProperty(".expires")]
        public string expires { get; set; }
    }
}
