using System;
using System.Windows.Forms;
using WebApiTestClient.DTO;
using Newtonsoft.Json;
using System.IO;

namespace WebApiTestClient
{
    public partial class MainForm : Form
    {
        private WebApiClient _webApiClient;
        private const string _logoffUrl = "logoff";
        private const string configName = "WebApiTestClient.config.json";
        private string configPath;
        private bool confChanged;

        public MainForm()
        {
            InitializeComponent();
            var currPath = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            configPath = Path.Combine(currPath, configName);
            if (File.Exists(configPath))
            {
                string sParams = File.ReadAllText(configPath);
                State state = JsonConvert.DeserializeObject<State>(sParams);
                tbMainURL.Text = state.MainURL;
                tbLoginURL.Text = state.LoginURL;
                tbUserName.Text = state.UserName;
                tbPassword.Text = state.Password;
                tbEndPointURL.Text = state.EndPointURL;
                tbRequestBody.Text = state.RequestBody;
            }
            confChanged = true;
            InitWebApiClient();
        }

        private void InitWebApiClient()
        {
            LoginResponse currSessionParams = null;
            if (_webApiClient != null)
            {
                _webApiClient = new WebApiClient(tbMainURL.Text, tbLoginURL.Text, _logoffUrl, _webApiClient.SessionParams);
            }
            else
            {
                _webApiClient = new WebApiClient(tbMainURL.Text, tbLoginURL.Text, _logoffUrl);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (confChanged)
            {
                InitWebApiClient();
                confChanged = false;
            }
            var res = _webApiClient.Login(tbUserName.Text, tbPassword.Text);
            tbLoginResponse.Text = res.Item2;
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
            File.WriteAllText(configPath, sParam);
        }

        private void btnRequest_Click(object sender, EventArgs e)
        {
            var rslt = _webApiClient.SendRequestWithBody(tbEndPointURL.Text, tbRequestBody.Text);
            tbResponse.Text = rslt.Item2;
        }

        private void btnLogoff_Click(object sender, EventArgs e)
        {
            if (confChanged)
            {
                InitWebApiClient();
                confChanged = false;
            }
            var res = _webApiClient.Logoff();
            tbLoginResponse.Text = res.Item2;
        }
    }
}
