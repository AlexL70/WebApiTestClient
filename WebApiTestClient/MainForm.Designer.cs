namespace WebApiTestClient
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbMainURL = new System.Windows.Forms.TextBox();
            this.lblMainURL = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.lblLoginURL = new System.Windows.Forms.Label();
            this.tbLoginURL = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.tbLoginResponse = new System.Windows.Forms.TextBox();
            this.lblEndPointURL = new System.Windows.Forms.Label();
            this.tbEndPointURL = new System.Windows.Forms.TextBox();
            this.tbRequestBody = new System.Windows.Forms.TextBox();
            this.lblRequestBody = new System.Windows.Forms.Label();
            this.btnRequest = new System.Windows.Forms.Button();
            this.tbResponse = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbMainURL
            // 
            this.tbMainURL.Location = new System.Drawing.Point(122, 100);
            this.tbMainURL.Name = "tbMainURL";
            this.tbMainURL.Size = new System.Drawing.Size(510, 38);
            this.tbMainURL.TabIndex = 0;
            // 
            // lblMainURL
            // 
            this.lblMainURL.AutoSize = true;
            this.lblMainURL.Location = new System.Drawing.Point(128, 54);
            this.lblMainURL.Name = "lblMainURL";
            this.lblMainURL.Size = new System.Drawing.Size(140, 32);
            this.lblMainURL.TabIndex = 1;
            this.lblMainURL.Text = "Main URL";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(128, 251);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(149, 32);
            this.lblUserName.TabIndex = 2;
            this.lblUserName.Text = "UserName";
            // 
            // tbUserName
            // 
            this.tbUserName.Location = new System.Drawing.Point(122, 286);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(510, 38);
            this.tbUserName.TabIndex = 3;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(128, 332);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(139, 32);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Password";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(122, 367);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(510, 38);
            this.tbPassword.TabIndex = 5;
            // 
            // lblLoginURL
            // 
            this.lblLoginURL.AutoSize = true;
            this.lblLoginURL.Location = new System.Drawing.Point(128, 159);
            this.lblLoginURL.Name = "lblLoginURL";
            this.lblLoginURL.Size = new System.Drawing.Size(149, 32);
            this.lblLoginURL.TabIndex = 6;
            this.lblLoginURL.Text = "Login URL";
            // 
            // tbLoginURL
            // 
            this.tbLoginURL.Location = new System.Drawing.Point(122, 194);
            this.tbLoginURL.Name = "tbLoginURL";
            this.tbLoginURL.Size = new System.Drawing.Size(510, 38);
            this.tbLoginURL.TabIndex = 7;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(122, 456);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(303, 57);
            this.btnLogin.TabIndex = 8;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // tbLoginResponse
            // 
            this.tbLoginResponse.Location = new System.Drawing.Point(122, 566);
            this.tbLoginResponse.Multiline = true;
            this.tbLoginResponse.Name = "tbLoginResponse";
            this.tbLoginResponse.ReadOnly = true;
            this.tbLoginResponse.Size = new System.Drawing.Size(510, 443);
            this.tbLoginResponse.TabIndex = 9;
            // 
            // lblEndPointURL
            // 
            this.lblEndPointURL.AutoSize = true;
            this.lblEndPointURL.Location = new System.Drawing.Point(842, 53);
            this.lblEndPointURL.Name = "lblEndPointURL";
            this.lblEndPointURL.Size = new System.Drawing.Size(192, 32);
            this.lblEndPointURL.TabIndex = 10;
            this.lblEndPointURL.Text = "Endpoint URL";
            // 
            // tbEndPointURL
            // 
            this.tbEndPointURL.Location = new System.Drawing.Point(828, 99);
            this.tbEndPointURL.Name = "tbEndPointURL";
            this.tbEndPointURL.Size = new System.Drawing.Size(464, 38);
            this.tbEndPointURL.TabIndex = 11;
            // 
            // tbRequestBody
            // 
            this.tbRequestBody.Location = new System.Drawing.Point(828, 209);
            this.tbRequestBody.Multiline = true;
            this.tbRequestBody.Name = "tbRequestBody";
            this.tbRequestBody.Size = new System.Drawing.Size(464, 225);
            this.tbRequestBody.TabIndex = 12;
            // 
            // lblRequestBody
            // 
            this.lblRequestBody.AutoSize = true;
            this.lblRequestBody.Location = new System.Drawing.Point(842, 159);
            this.lblRequestBody.Name = "lblRequestBody";
            this.lblRequestBody.Size = new System.Drawing.Size(190, 32);
            this.lblRequestBody.TabIndex = 13;
            this.lblRequestBody.Text = "Request body";
            // 
            // btnRequest
            // 
            this.btnRequest.Location = new System.Drawing.Point(828, 456);
            this.btnRequest.Name = "btnRequest";
            this.btnRequest.Size = new System.Drawing.Size(310, 57);
            this.btnRequest.TabIndex = 14;
            this.btnRequest.Text = "SendRequest";
            this.btnRequest.UseVisualStyleBackColor = true;
            this.btnRequest.Click += new System.EventHandler(this.btnRequest_Click);
            // 
            // tbResponse
            // 
            this.tbResponse.Location = new System.Drawing.Point(828, 566);
            this.tbResponse.Multiline = true;
            this.tbResponse.Name = "tbResponse";
            this.tbResponse.ReadOnly = true;
            this.tbResponse.Size = new System.Drawing.Size(464, 443);
            this.tbResponse.TabIndex = 15;
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(1531, 1041);
            this.Controls.Add(this.tbResponse);
            this.Controls.Add(this.btnRequest);
            this.Controls.Add(this.lblRequestBody);
            this.Controls.Add(this.tbRequestBody);
            this.Controls.Add(this.tbEndPointURL);
            this.Controls.Add(this.lblEndPointURL);
            this.Controls.Add(this.tbLoginResponse);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.tbLoginURL);
            this.Controls.Add(this.lblLoginURL);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.tbUserName);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.lblMainURL);
            this.Controls.Add(this.tbMainURL);
            this.Name = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox tbMainURL;
        private System.Windows.Forms.Label lblMainURL;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label lblLoginURL;
        private System.Windows.Forms.TextBox tbLoginURL;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox tbLoginResponse;
        private System.Windows.Forms.Label lblEndPointURL;
        private System.Windows.Forms.TextBox tbEndPointURL;
        private System.Windows.Forms.TextBox tbRequestBody;
        private System.Windows.Forms.Label lblRequestBody;
        private System.Windows.Forms.Button btnRequest;
        private System.Windows.Forms.TextBox tbResponse;
    }
}

