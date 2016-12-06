using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using WebApiTestClient.DTO;

namespace WebApiTestClient
{
    public class WebApiClient
    {
        string _baseUrl, _loginUrl, _logoffUrl;

        public WebApiClient(string baseUrl, string loginUrl, string logoffUrl)
            : this(baseUrl, loginUrl, logoffUrl, new LoginResponse())
        {
        }

        public WebApiClient(string baseUrl, string loginUrl, string logoffUrl, LoginResponse sessionParams)
        {
            _baseUrl = baseUrl.TrimEnd('/');
            _loginUrl = loginUrl.TrimStart('/');
            _logoffUrl = loginUrl.TrimStart('/');
            SessionParams = sessionParams;
        }

        public LoginResponse SessionParams { get; private set; }

        public Tuple<bool, string> SendRequest(string url, HttpContent content)
        {
            using (var client = new HttpClient())
            {
                if (SessionParams != null)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", SessionParams.access_token);
                }
                var respTask = client.PostAsync(url, content);
                respTask.Wait();
                var response = respTask.Result;
                var valueTask = response.Content.ReadAsStringAsync();
                valueTask.Wait();
                return Tuple.Create(response.IsSuccessStatusCode, valueTask.Result);
            }
        }

        public Tuple<bool, string> Logoff()
        {
            var logoffUrl = $"{_baseUrl}/{_logoffUrl}";
            var rslt = SendRequest(logoffUrl, new StringContent(""));
            if (rslt.Item1)
            {
                SessionParams = null;
                return Tuple.Create(true, $"Successfull logoff. {rslt.Item2}");
            }
            else
            {
                return Tuple.Create(false, $"Logoff error. {rslt.Item2}");
            }
        }

        public Tuple<bool, string> Login(string userName, string password)
        {
            var loginUrl = $"{_baseUrl}/{_loginUrl}";
            var lModel = new LoginStadardModel
            {
                grant_type = "password",
                userName = userName,
                password = password
            };
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add(nameof(lModel.grant_type), lModel.grant_type);
            dict.Add(nameof(lModel.userName), lModel.userName);
            dict.Add("login", lModel.userName);
            dict.Add(nameof(lModel.password), lModel.password);
            var content = new FormUrlEncodedContent(dict);
            var rslt = SendRequest(loginUrl, content);
            if (rslt.Item1)
            {
                SessionParams = JsonConvert.DeserializeObject<LoginResponse>(rslt.Item2);
            }
            return rslt;
        }

        internal Tuple<bool, string> SendRequestWithBody(string url, string body)
        {
            string fullUrl = $"{_baseUrl}/{url.TrimStart('/')}";
            var client = new HttpClient();
            var content = new StringContent(body, Encoding.UTF8, "application/json");
            if (SessionParams != null)
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", SessionParams.access_token);
            }
            var respTask = client.PostAsync(fullUrl, content);
            respTask.Wait();
            var response = respTask.Result;
            var valueTask = response.Content.ReadAsStringAsync();
            valueTask.Wait();
            return Tuple.Create(response.IsSuccessStatusCode, valueTask.Result);
        }
    }
}
