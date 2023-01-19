namespace SpotifyContentAvailabilityChecker
{
    partial class SCAC
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.GBX_SpotifyInfo = new System.Windows.Forms.GroupBox();
            this.TXT_ContentTypeDisplay = new System.Windows.Forms.TextBox();
            this.TXT_AccessToken = new System.Windows.Forms.TextBox();
            this.LBL_AccessToken = new System.Windows.Forms.Label();
            this.LBL_ContentType = new System.Windows.Forms.Label();
            this.TXT_ContentLinkURI = new System.Windows.Forms.TextBox();
            this.LBL_Resource = new System.Windows.Forms.Label();
            this.GBX_Result = new System.Windows.Forms.GroupBox();
            this.TXT_SearchInput = new System.Windows.Forms.TextBox();
            this.CBX_SearchBy = new System.Windows.Forms.ComboBox();
            this.LBL_SearchBy = new System.Windows.Forms.Label();
            this.LBL_SearchInput = new System.Windows.Forms.Label();
            this.LVW_CountryResults = new System.Windows.Forms.ListView();
            this.CH_CountryCode = new System.Windows.Forms.ColumnHeader();
            this.CH_CountryName = new System.Windows.Forms.ColumnHeader();
            this.GBX_Actions = new System.Windows.Forms.GroupBox();
            this.BTN_StartSearch = new System.Windows.Forms.Button();
            this.BTN_GetAccessToken = new System.Windows.Forms.Button();
            this.GBX_ContentInfo = new System.Windows.Forms.GroupBox();
            this.TXT_SoundCopyright = new System.Windows.Forms.TextBox();
            this.LBL_SoundCopyright = new System.Windows.Forms.Label();
            this.TXT_Authors = new System.Windows.Forms.TextBox();
            this.TXT_Copyright = new System.Windows.Forms.TextBox();
            this.LBL_Copyright = new System.Windows.Forms.Label();
            this.TXT_Title = new System.Windows.Forms.TextBox();
            this.LBL_Title = new System.Windows.Forms.Label();
            this.LBL_Authors = new System.Windows.Forms.Label();
            this.TCRTL_Main = new System.Windows.Forms.TabControl();
            this.TPG_Search = new System.Windows.Forms.TabPage();
            this.GBX_SpotifyInfo.SuspendLayout();
            this.GBX_Result.SuspendLayout();
            this.GBX_Actions.SuspendLayout();
            this.GBX_ContentInfo.SuspendLayout();
            this.TCRTL_Main.SuspendLayout();
            this.TPG_Search.SuspendLayout();
            this.SuspendLayout();
            // 
            // GBX_SpotifyInfo
            // 
            this.GBX_SpotifyInfo.Controls.Add(this.TXT_ContentTypeDisplay);
            this.GBX_SpotifyInfo.Controls.Add(this.TXT_AccessToken);
            this.GBX_SpotifyInfo.Controls.Add(this.LBL_AccessToken);
            this.GBX_SpotifyInfo.Controls.Add(this.LBL_ContentType);
            this.GBX_SpotifyInfo.Controls.Add(this.TXT_ContentLinkURI);
            this.GBX_SpotifyInfo.Controls.Add(this.LBL_Resource);
            this.GBX_SpotifyInfo.Location = new System.Drawing.Point(6, 5);
            this.GBX_SpotifyInfo.Name = "GBX_SpotifyInfo";
            this.GBX_SpotifyInfo.Size = new System.Drawing.Size(389, 118);
            this.GBX_SpotifyInfo.TabIndex = 0;
            this.GBX_SpotifyInfo.TabStop = false;
            this.GBX_SpotifyInfo.Text = "Spotify Information";
            // 
            // TXT_ContentTypeDisplay
            // 
            this.TXT_ContentTypeDisplay.Location = new System.Drawing.Point(121, 50);
            this.TXT_ContentTypeDisplay.Name = "TXT_ContentTypeDisplay";
            this.TXT_ContentTypeDisplay.ReadOnly = true;
            this.TXT_ContentTypeDisplay.Size = new System.Drawing.Size(258, 23);
            this.TXT_ContentTypeDisplay.TabIndex = 8;
            // 
            // TXT_AccessToken
            // 
            this.TXT_AccessToken.Location = new System.Drawing.Point(121, 79);
            this.TXT_AccessToken.Name = "TXT_AccessToken";
            this.TXT_AccessToken.PasswordChar = '*';
            this.TXT_AccessToken.ReadOnly = true;
            this.TXT_AccessToken.Size = new System.Drawing.Size(258, 23);
            this.TXT_AccessToken.TabIndex = 7;
            // 
            // LBL_AccessToken
            // 
            this.LBL_AccessToken.AutoSize = true;
            this.LBL_AccessToken.Location = new System.Drawing.Point(8, 83);
            this.LBL_AccessToken.Name = "LBL_AccessToken";
            this.LBL_AccessToken.Size = new System.Drawing.Size(80, 15);
            this.LBL_AccessToken.TabIndex = 6;
            this.LBL_AccessToken.Text = "Access Token:";
            // 
            // LBL_ContentType
            // 
            this.LBL_ContentType.AutoSize = true;
            this.LBL_ContentType.Location = new System.Drawing.Point(8, 54);
            this.LBL_ContentType.Name = "LBL_ContentType";
            this.LBL_ContentType.Size = new System.Drawing.Size(80, 15);
            this.LBL_ContentType.TabIndex = 4;
            this.LBL_ContentType.Text = "Content Type:";
            // 
            // TXT_ContentLinkURI
            // 
            this.TXT_ContentLinkURI.Location = new System.Drawing.Point(121, 21);
            this.TXT_ContentLinkURI.Name = "TXT_ContentLinkURI";
            this.TXT_ContentLinkURI.Size = new System.Drawing.Size(258, 23);
            this.TXT_ContentLinkURI.TabIndex = 3;
            this.TXT_ContentLinkURI.TextChanged += new System.EventHandler(this.TXT_ContentLinkURI_TextChanged);
            // 
            // LBL_Resource
            // 
            this.LBL_Resource.AutoSize = true;
            this.LBL_Resource.Location = new System.Drawing.Point(8, 25);
            this.LBL_Resource.Name = "LBL_Resource";
            this.LBL_Resource.Size = new System.Drawing.Size(107, 15);
            this.LBL_Resource.TabIndex = 1;
            this.LBL_Resource.Text = "Content Link / URI:";
            // 
            // GBX_Result
            // 
            this.GBX_Result.Controls.Add(this.TXT_SearchInput);
            this.GBX_Result.Controls.Add(this.CBX_SearchBy);
            this.GBX_Result.Controls.Add(this.LBL_SearchBy);
            this.GBX_Result.Controls.Add(this.LBL_SearchInput);
            this.GBX_Result.Controls.Add(this.LVW_CountryResults);
            this.GBX_Result.Location = new System.Drawing.Point(401, 5);
            this.GBX_Result.Name = "GBX_Result";
            this.GBX_Result.Size = new System.Drawing.Size(389, 331);
            this.GBX_Result.TabIndex = 1;
            this.GBX_Result.TabStop = false;
            this.GBX_Result.Text = "Result";
            // 
            // TXT_SearchInput
            // 
            this.TXT_SearchInput.Location = new System.Drawing.Point(99, 21);
            this.TXT_SearchInput.Name = "TXT_SearchInput";
            this.TXT_SearchInput.Size = new System.Drawing.Size(284, 23);
            this.TXT_SearchInput.TabIndex = 8;
            this.TXT_SearchInput.TextChanged += new System.EventHandler(this.TXT_SearchInput_TextChanged);
            // 
            // CBX_SearchBy
            // 
            this.CBX_SearchBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBX_SearchBy.FormattingEnabled = true;
            this.CBX_SearchBy.Items.AddRange(new object[] {
            "Country Code",
            "Country Name"});
            this.CBX_SearchBy.Location = new System.Drawing.Point(99, 50);
            this.CBX_SearchBy.Name = "CBX_SearchBy";
            this.CBX_SearchBy.Size = new System.Drawing.Size(284, 23);
            this.CBX_SearchBy.TabIndex = 9;
            // 
            // LBL_SearchBy
            // 
            this.LBL_SearchBy.AutoSize = true;
            this.LBL_SearchBy.Location = new System.Drawing.Point(6, 53);
            this.LBL_SearchBy.Name = "LBL_SearchBy";
            this.LBL_SearchBy.Size = new System.Drawing.Size(61, 15);
            this.LBL_SearchBy.TabIndex = 8;
            this.LBL_SearchBy.Text = "Search By:";
            // 
            // LBL_SearchInput
            // 
            this.LBL_SearchInput.AutoSize = true;
            this.LBL_SearchInput.Location = new System.Drawing.Point(6, 24);
            this.LBL_SearchInput.Name = "LBL_SearchInput";
            this.LBL_SearchInput.Size = new System.Drawing.Size(76, 15);
            this.LBL_SearchInput.TabIndex = 8;
            this.LBL_SearchInput.Text = "Search Input:";
            // 
            // LVW_CountryResults
            // 
            this.LVW_CountryResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CH_CountryCode,
            this.CH_CountryName});
            this.LVW_CountryResults.Location = new System.Drawing.Point(6, 80);
            this.LVW_CountryResults.Name = "LVW_CountryResults";
            this.LVW_CountryResults.Size = new System.Drawing.Size(377, 239);
            this.LVW_CountryResults.TabIndex = 0;
            this.LVW_CountryResults.UseCompatibleStateImageBehavior = false;
            this.LVW_CountryResults.View = System.Windows.Forms.View.Details;
            // 
            // CH_CountryCode
            // 
            this.CH_CountryCode.Text = "Country Code";
            this.CH_CountryCode.Width = 120;
            // 
            // CH_CountryName
            // 
            this.CH_CountryName.Text = "Country Name";
            this.CH_CountryName.Width = 235;
            // 
            // GBX_Actions
            // 
            this.GBX_Actions.Controls.Add(this.BTN_StartSearch);
            this.GBX_Actions.Controls.Add(this.BTN_GetAccessToken);
            this.GBX_Actions.Location = new System.Drawing.Point(6, 130);
            this.GBX_Actions.Name = "GBX_Actions";
            this.GBX_Actions.Size = new System.Drawing.Size(389, 55);
            this.GBX_Actions.TabIndex = 1;
            this.GBX_Actions.TabStop = false;
            this.GBX_Actions.Text = "Actions";
            // 
            // BTN_StartSearch
            // 
            this.BTN_StartSearch.Location = new System.Drawing.Point(196, 20);
            this.BTN_StartSearch.Name = "BTN_StartSearch";
            this.BTN_StartSearch.Size = new System.Drawing.Size(123, 23);
            this.BTN_StartSearch.TabIndex = 1;
            this.BTN_StartSearch.Text = "Start Search";
            this.BTN_StartSearch.UseVisualStyleBackColor = true;
            this.BTN_StartSearch.Click += new System.EventHandler(this.BTN_StartSearch_Click);
            // 
            // BTN_GetAccessToken
            // 
            this.BTN_GetAccessToken.Location = new System.Drawing.Point(67, 20);
            this.BTN_GetAccessToken.Name = "BTN_GetAccessToken";
            this.BTN_GetAccessToken.Size = new System.Drawing.Size(123, 23);
            this.BTN_GetAccessToken.TabIndex = 0;
            this.BTN_GetAccessToken.Text = "Get Access Token";
            this.BTN_GetAccessToken.UseVisualStyleBackColor = true;
            this.BTN_GetAccessToken.Click += new System.EventHandler(this.BTN_GetAccessToken_Click);
            // 
            // GBX_ContentInfo
            // 
            this.GBX_ContentInfo.Controls.Add(this.TXT_SoundCopyright);
            this.GBX_ContentInfo.Controls.Add(this.LBL_SoundCopyright);
            this.GBX_ContentInfo.Controls.Add(this.TXT_Authors);
            this.GBX_ContentInfo.Controls.Add(this.TXT_Copyright);
            this.GBX_ContentInfo.Controls.Add(this.LBL_Copyright);
            this.GBX_ContentInfo.Controls.Add(this.TXT_Title);
            this.GBX_ContentInfo.Controls.Add(this.LBL_Title);
            this.GBX_ContentInfo.Controls.Add(this.LBL_Authors);
            this.GBX_ContentInfo.Location = new System.Drawing.Point(6, 191);
            this.GBX_ContentInfo.Name = "GBX_ContentInfo";
            this.GBX_ContentInfo.Size = new System.Drawing.Size(389, 145);
            this.GBX_ContentInfo.TabIndex = 2;
            this.GBX_ContentInfo.TabStop = false;
            this.GBX_ContentInfo.Text = "Content Information";
            // 
            // TXT_SoundCopyright
            // 
            this.TXT_SoundCopyright.Location = new System.Drawing.Point(121, 110);
            this.TXT_SoundCopyright.Name = "TXT_SoundCopyright";
            this.TXT_SoundCopyright.ReadOnly = true;
            this.TXT_SoundCopyright.Size = new System.Drawing.Size(258, 23);
            this.TXT_SoundCopyright.TabIndex = 12;
            // 
            // LBL_SoundCopyright
            // 
            this.LBL_SoundCopyright.AutoSize = true;
            this.LBL_SoundCopyright.Location = new System.Drawing.Point(8, 113);
            this.LBL_SoundCopyright.Name = "LBL_SoundCopyright";
            this.LBL_SoundCopyright.Size = new System.Drawing.Size(100, 15);
            this.LBL_SoundCopyright.TabIndex = 13;
            this.LBL_SoundCopyright.Text = "Sound Copyright:";
            // 
            // TXT_Authors
            // 
            this.TXT_Authors.Location = new System.Drawing.Point(121, 52);
            this.TXT_Authors.Name = "TXT_Authors";
            this.TXT_Authors.ReadOnly = true;
            this.TXT_Authors.Size = new System.Drawing.Size(258, 23);
            this.TXT_Authors.TabIndex = 11;
            // 
            // TXT_Copyright
            // 
            this.TXT_Copyright.Location = new System.Drawing.Point(121, 81);
            this.TXT_Copyright.Name = "TXT_Copyright";
            this.TXT_Copyright.ReadOnly = true;
            this.TXT_Copyright.Size = new System.Drawing.Size(258, 23);
            this.TXT_Copyright.TabIndex = 9;
            // 
            // LBL_Copyright
            // 
            this.LBL_Copyright.AutoSize = true;
            this.LBL_Copyright.Location = new System.Drawing.Point(8, 84);
            this.LBL_Copyright.Name = "LBL_Copyright";
            this.LBL_Copyright.Size = new System.Drawing.Size(63, 15);
            this.LBL_Copyright.TabIndex = 10;
            this.LBL_Copyright.Text = "Copyright:";
            // 
            // TXT_Title
            // 
            this.TXT_Title.Location = new System.Drawing.Point(121, 23);
            this.TXT_Title.Name = "TXT_Title";
            this.TXT_Title.ReadOnly = true;
            this.TXT_Title.Size = new System.Drawing.Size(258, 23);
            this.TXT_Title.TabIndex = 8;
            // 
            // LBL_Title
            // 
            this.LBL_Title.AutoSize = true;
            this.LBL_Title.Location = new System.Drawing.Point(8, 26);
            this.LBL_Title.Name = "LBL_Title";
            this.LBL_Title.Size = new System.Drawing.Size(32, 15);
            this.LBL_Title.TabIndex = 8;
            this.LBL_Title.Text = "Title:";
            // 
            // LBL_Authors
            // 
            this.LBL_Authors.AutoSize = true;
            this.LBL_Authors.Location = new System.Drawing.Point(8, 55);
            this.LBL_Authors.Name = "LBL_Authors";
            this.LBL_Authors.Size = new System.Drawing.Size(52, 15);
            this.LBL_Authors.TabIndex = 9;
            this.LBL_Authors.Text = "Authors:";
            // 
            // TCRTL_Main
            // 
            this.TCRTL_Main.Controls.Add(this.TPG_Search);
            this.TCRTL_Main.Location = new System.Drawing.Point(5, 4);
            this.TCRTL_Main.Name = "TCRTL_Main";
            this.TCRTL_Main.SelectedIndex = 0;
            this.TCRTL_Main.Size = new System.Drawing.Size(806, 371);
            this.TCRTL_Main.TabIndex = 3;
            // 
            // TPG_Search
            // 
            this.TPG_Search.Controls.Add(this.GBX_Result);
            this.TPG_Search.Controls.Add(this.GBX_SpotifyInfo);
            this.TPG_Search.Controls.Add(this.GBX_Actions);
            this.TPG_Search.Controls.Add(this.GBX_ContentInfo);
            this.TPG_Search.Location = new System.Drawing.Point(4, 24);
            this.TPG_Search.Name = "TPG_Search";
            this.TPG_Search.Padding = new System.Windows.Forms.Padding(3);
            this.TPG_Search.Size = new System.Drawing.Size(798, 343);
            this.TPG_Search.TabIndex = 0;
            this.TPG_Search.Text = "Search";
            this.TPG_Search.UseVisualStyleBackColor = true;
            // 
            // SCAC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 379);
            this.Controls.Add(this.TCRTL_Main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(822, 380);
            this.Name = "SCAC";
            this.Text = "Spotify Content Availability Checker";
            this.Load += new System.EventHandler(this.SCAC_Load);
            this.GBX_SpotifyInfo.ResumeLayout(false);
            this.GBX_SpotifyInfo.PerformLayout();
            this.GBX_Result.ResumeLayout(false);
            this.GBX_Result.PerformLayout();
            this.GBX_Actions.ResumeLayout(false);
            this.GBX_ContentInfo.ResumeLayout(false);
            this.GBX_ContentInfo.PerformLayout();
            this.TCRTL_Main.ResumeLayout(false);
            this.TPG_Search.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox GBX_SpotifyInfo;
        private TextBox TXT_AccessToken;
        private Label LBL_AccessToken;
        private Label LBL_ContentType;
        private TextBox TXT_ContentLinkURI;
        private Label LBL_Resource;
        private GroupBox GBX_Result;
        private GroupBox GBX_Actions;
        private Button BTN_GetAccessToken;
        private GroupBox GBX_ContentInfo;
        private Button BTN_StartSearch;
        private TextBox TXT_SearchInput;
        private ComboBox CBX_SearchBy;
        private Label LBL_SearchBy;
        private Label LBL_SearchInput;
        private ListView LVW_CountryResults;
        private ColumnHeader CH_CountryCode;
        private ColumnHeader CH_CountryName;
        private TextBox TXT_SoundCopyright;
        private Label LBL_SoundCopyright;
        private TextBox TXT_Authors;
        private TextBox TXT_Copyright;
        private Label LBL_Copyright;
        private TextBox TXT_Title;
        private Label LBL_Title;
        private Label LBL_Authors;
        private TextBox TXT_ContentTypeDisplay;
        private TabControl TCRTL_Main;
        private TabPage TPG_Search;
    }
}