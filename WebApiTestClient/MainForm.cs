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
            var client = new HttpClient();
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
            var respTask= client.PostAsync(loginUrl, content);
            respTask.Wait();
            var response = respTask.Result;
            var valueTask = response.Content.ReadAsStringAsync();
            valueTask.Wait();
            tbLoginResponse.Text = valueTask.Result;
            if (response.IsSuccessStatusCode)
            {
                sessionParams = JsonConvert.DeserializeObject<LoginResponse>(valueTask.Result);
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
    }
}
