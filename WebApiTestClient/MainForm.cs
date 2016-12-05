using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows.Forms;
using WebApiTestClient.DTO;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.Net.Http.Headers;

namespace WebApiTestClient
{
    public partial class MainForm : Form
    {
        private LoginResponse sessionParams;
        private string configName = "WebApiTestClient.config.json";

        public MainForm()
        {
            InitializeComponent();
            var currPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            configName = Path.Combine(currPath, "WebApiTestClient.config.json");
            if (File.Exists(configName))
            {
                string sParams = File.ReadAllText(configName);
                State state = JsonConvert.DeserializeObject<State>(sParams);
                tbMainURL.Text = state.MainURL;
                tbLoginURL.Text = state.LoginURL;
                tbUserName.Text = state.UserName;
                tbPassword.Text = state.Password;
                tbEndPointURL.Text = state.EndPointURL;
                tbRequestBody.Text = state.RequestBody;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void Login()
        {
            var loginUrl = $"{tbMainURL.Text.TrimEnd('/')}/{tbLoginURL.Text.TrimStart('/')}";
            var lModel = new LoginStadardModel
            {
                grant_type = "password",
                userName = tbUserName.Text,
                password = tbPassword.Text
            };
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add(nameof(lModel.grant_type), lModel.grant_type);
            dict.Add(nameof(lModel.userName), lModel.userName);
            dict.Add("login", lModel.userName);
            dict.Add(nameof(lModel.password), lModel.password);
            var content = new FormUrlEncodedContent(dict);
            var rslt = SendRequest(loginUrl, content);
            tbLoginResponse.Text = rslt.Item2;
            if (rslt.Item1)
            {
                sessionParams = JsonConvert.DeserializeObject<LoginResponse>(rslt.Item2);
            }
        }

        private Tuple<bool, string> SendRequest(string loginUrl, HttpContent content)
        {
            using(var client = new HttpClient())
            {
                if (sessionParams != null)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", sessionParams.access_token);
                }
                var respTask = client.PostAsync(loginUrl, content);
                respTask.Wait();
                var response = respTask.Result;
                var valueTask = response.Content.ReadAsStringAsync();
                valueTask.Wait();
                return Tuple.Create(response.IsSuccessStatusCode, valueTask.Result);
            }
        }

        private void Logoff()
        {
            var logoffUrl = $"{tbMainURL.Text.TrimEnd('/')}/logoff";
            var rslt = SendRequest(logoffUrl, new StringContent(""));
            if (rslt.Item1)
            {
                tbLoginResponse.Text = $"Successfull logoff. {rslt.Item2}";
                sessionParams = null;
            }
            else
            {
                tbLoginResponse.Text = $"Logoff error. {rslt.Item2}";
            }
        }

        private void SendRequest()
        {
            string url = $"{tbMainURL.Text.TrimEnd('/')}/{tbEndPointURL.Text.TrimStart('/')}";
            var client = new HttpClient();
            var content = new StringContent(tbRequestBody.Text, Encoding.UTF8, "application/json");
            if (sessionParams != null)
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", sessionParams.access_token);
            }
            var respTask = client.PostAsync(url, content);
            respTask.Wait();
            var response = respTask.Result;
            var valueTask = response.Content.ReadAsStringAsync();
            valueTask.Wait();
            tbResponse.Text = valueTask.Result;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            State state = new State
            {
                MainURL = tbMainURL.Text,
                LoginURL = tbLoginURL.Text,
                UserName = tbUserName.Text,
                Password = tbPassword.Text,
                EndPointURL = tbEndPointURL.Text,
                RequestBody = tbRequestBody.Text
            };
            string sParam = JsonConvert.SerializeObject(state);
            File.WriteAllText(configName, sParam);
        }

        private void btnRequest_Click(object sender, EventArgs e)
        {
            SendRequest();
        }

        private void btnLogoff_Click(object sender, EventArgs e)
        {
            Logoff();
        }
    }
}
