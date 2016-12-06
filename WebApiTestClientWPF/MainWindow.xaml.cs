using System.Windows;
using System.IO;
using WebApiTestClient;
using Newtonsoft.Json;
using WebApiTestClient.DTO;

namespace WebApiTestClientWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private WebApiClient _webApiClient;
        private const string _logoffUrl = "logoff";
        private const string configName = "WebApiTestClient.config.json";
        private string configPath;
        private bool confChanged;

        public MainWindow()
        {
            InitializeComponent();
            var currPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            configPath = System.IO.Path.Combine(currPath, configName);
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
            if (_webApiClient != null)
            {
                _webApiClient = new WebApiClient(tbMainURL.Text, tbLoginURL.Text, _logoffUrl, _webApiClient.SessionParams);
            }
            else
            {
                _webApiClient = new WebApiClient(tbMainURL.Text, tbLoginURL.Text, _logoffUrl);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
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

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (confChanged)
            {
                InitWebApiClient();
                confChanged = false;
            }
            var res = _webApiClient.Login(tbUserName.Text, tbPassword.Text);
            tbLoginResponse.Text = res.Item2;
        }

        private void btnLogoff_Click(object sender, RoutedEventArgs e)
        {
            if (confChanged)
            {
                InitWebApiClient();
                confChanged = false;
            }
            var res = _webApiClient.Logoff();
            tbLoginResponse.Text = res.Item2;
        }

        private void btnSendRequest_Click(object sender, RoutedEventArgs e)
        {
            var rslt = _webApiClient.SendRequestWithBody(tbEndPointURL.Text, tbRequestBody.Text);
            tbResponse.Text = rslt.Item2;
        }
    }
}
