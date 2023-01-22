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
            this.TPG_History = new System.Windows.Forms.TabPage();
            this.GBX_History = new System.Windows.Forms.GroupBox();
            this.LVW_SearchHistory = new System.Windows.Forms.ListView();
            this.CHDR_Favorite = new System.Windows.Forms.ColumnHeader();
            this.CHDR_Title = new System.Windows.Forms.ColumnHeader();
            this.CHDR_Author = new System.Windows.Forms.ColumnHeader();
            this.CHDR_Type = new System.Windows.Forms.ColumnHeader();
            this.CHDR_Link = new System.Windows.Forms.ColumnHeader();
            this.GBX_ActionEvents = new System.Windows.Forms.GroupBox();
            this.BTN_OpenSearchHistory = new System.Windows.Forms.Button();
            this.BTN_UseSelectedSearch = new System.Windows.Forms.Button();
            this.BTN_ClearSearches = new System.Windows.Forms.Button();
            this.GBX_SearchInfo = new System.Windows.Forms.GroupBox();
            this.CHK_FavoriteSearchOnly = new System.Windows.Forms.CheckBox();
            this.TXT_HistorySearch = new System.Windows.Forms.TextBox();
            this.CBX_HistorySearchBy = new System.Windows.Forms.ComboBox();
            this.LBL_HistorySearchBy = new System.Windows.Forms.Label();
            this.LBL_HistorySearch = new System.Windows.Forms.Label();
            this.BTN_ClearSearch = new System.Windows.Forms.Button();
            this.GBX_SpotifyInfo.SuspendLayout();
            this.GBX_Result.SuspendLayout();
            this.GBX_Actions.SuspendLayout();
            this.GBX_ContentInfo.SuspendLayout();
            this.TCRTL_Main.SuspendLayout();
            this.TPG_Search.SuspendLayout();
            this.TPG_History.SuspendLayout();
            this.GBX_History.SuspendLayout();
            this.GBX_ActionEvents.SuspendLayout();
            this.GBX_SearchInfo.SuspendLayout();
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
            this.TXT_ContentTypeDisplay.Location = new System.Drawing.Point(121, 51);
            this.TXT_ContentTypeDisplay.Name = "TXT_ContentTypeDisplay";
            this.TXT_ContentTypeDisplay.ReadOnly = true;
            this.TXT_ContentTypeDisplay.Size = new System.Drawing.Size(258, 23);
            this.TXT_ContentTypeDisplay.TabIndex = 4;
            // 
            // TXT_AccessToken
            // 
            this.TXT_AccessToken.Location = new System.Drawing.Point(121, 80);
            this.TXT_AccessToken.Name = "TXT_AccessToken";
            this.TXT_AccessToken.PasswordChar = '*';
            this.TXT_AccessToken.ReadOnly = true;
            this.TXT_AccessToken.Size = new System.Drawing.Size(258, 23);
            this.TXT_AccessToken.TabIndex = 6;
            // 
            // LBL_AccessToken
            // 
            this.LBL_AccessToken.AutoSize = true;
            this.LBL_AccessToken.Location = new System.Drawing.Point(8, 84);
            this.LBL_AccessToken.Name = "LBL_AccessToken";
            this.LBL_AccessToken.Size = new System.Drawing.Size(80, 15);
            this.LBL_AccessToken.TabIndex = 5;
            this.LBL_AccessToken.Text = "Access Token:";
            // 
            // LBL_ContentType
            // 
            this.LBL_ContentType.AutoSize = true;
            this.LBL_ContentType.Location = new System.Drawing.Point(8, 55);
            this.LBL_ContentType.Name = "LBL_ContentType";
            this.LBL_ContentType.Size = new System.Drawing.Size(80, 15);
            this.LBL_ContentType.TabIndex = 3;
            this.LBL_ContentType.Text = "Content Type:";
            // 
            // TXT_ContentLinkURI
            // 
            this.TXT_ContentLinkURI.Location = new System.Drawing.Point(121, 22);
            this.TXT_ContentLinkURI.Name = "TXT_ContentLinkURI";
            this.TXT_ContentLinkURI.Size = new System.Drawing.Size(258, 23);
            this.TXT_ContentLinkURI.TabIndex = 2;
            this.TXT_ContentLinkURI.TextChanged += new System.EventHandler(this.TXT_ContentLinkURI_TextChanged);
            // 
            // LBL_Resource
            // 
            this.LBL_Resource.AutoSize = true;
            this.LBL_Resource.Location = new System.Drawing.Point(8, 26);
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
            this.GBX_Result.Location = new System.Drawing.Point(400, 5);
            this.GBX_Result.Name = "GBX_Result";
            this.GBX_Result.Size = new System.Drawing.Size(389, 331);
            this.GBX_Result.TabIndex = 19;
            this.GBX_Result.TabStop = false;
            this.GBX_Result.Text = "Result";
            // 
            // TXT_SearchInput
            // 
            this.TXT_SearchInput.Location = new System.Drawing.Point(99, 20);
            this.TXT_SearchInput.Name = "TXT_SearchInput";
            this.TXT_SearchInput.Size = new System.Drawing.Size(284, 23);
            this.TXT_SearchInput.TabIndex = 21;
            this.TXT_SearchInput.TextChanged += new System.EventHandler(this.TXT_SearchInput_TextChanged);
            // 
            // CBX_SearchBy
            // 
            this.CBX_SearchBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBX_SearchBy.FormattingEnabled = true;
            this.CBX_SearchBy.Items.AddRange(new object[] {
            "Country Code",
            "Country Name"});
            this.CBX_SearchBy.Location = new System.Drawing.Point(99, 49);
            this.CBX_SearchBy.Name = "CBX_SearchBy";
            this.CBX_SearchBy.Size = new System.Drawing.Size(284, 23);
            this.CBX_SearchBy.TabIndex = 23;
            // 
            // LBL_SearchBy
            // 
            this.LBL_SearchBy.AutoSize = true;
            this.LBL_SearchBy.Location = new System.Drawing.Point(6, 52);
            this.LBL_SearchBy.Name = "LBL_SearchBy";
            this.LBL_SearchBy.Size = new System.Drawing.Size(61, 15);
            this.LBL_SearchBy.TabIndex = 22;
            this.LBL_SearchBy.Text = "Search By:";
            // 
            // LBL_SearchInput
            // 
            this.LBL_SearchInput.AutoSize = true;
            this.LBL_SearchInput.Location = new System.Drawing.Point(6, 23);
            this.LBL_SearchInput.Name = "LBL_SearchInput";
            this.LBL_SearchInput.Size = new System.Drawing.Size(76, 15);
            this.LBL_SearchInput.TabIndex = 20;
            this.LBL_SearchInput.Text = "Search Input:";
            // 
            // LVW_CountryResults
            // 
            this.LVW_CountryResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CH_CountryCode,
            this.CH_CountryName});
            this.LVW_CountryResults.Location = new System.Drawing.Point(6, 79);
            this.LVW_CountryResults.Name = "LVW_CountryResults";
            this.LVW_CountryResults.Size = new System.Drawing.Size(377, 240);
            this.LVW_CountryResults.TabIndex = 24;
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
            this.GBX_Actions.Controls.Add(this.BTN_ClearSearch);
            this.GBX_Actions.Controls.Add(this.BTN_StartSearch);
            this.GBX_Actions.Controls.Add(this.BTN_GetAccessToken);
            this.GBX_Actions.Location = new System.Drawing.Point(6, 130);
            this.GBX_Actions.Name = "GBX_Actions";
            this.GBX_Actions.Size = new System.Drawing.Size(389, 55);
            this.GBX_Actions.TabIndex = 7;
            this.GBX_Actions.TabStop = false;
            this.GBX_Actions.Text = "Actions";
            // 
            // BTN_StartSearch
            // 
            this.BTN_StartSearch.Location = new System.Drawing.Point(139, 20);
            this.BTN_StartSearch.Name = "BTN_StartSearch";
            this.BTN_StartSearch.Size = new System.Drawing.Size(110, 23);
            this.BTN_StartSearch.TabIndex = 9;
            this.BTN_StartSearch.Text = "Start Search";
            this.BTN_StartSearch.UseVisualStyleBackColor = true;
            this.BTN_StartSearch.Click += new System.EventHandler(this.BTN_StartSearch_Click);
            // 
            // BTN_GetAccessToken
            // 
            this.BTN_GetAccessToken.Location = new System.Drawing.Point(23, 20);
            this.BTN_GetAccessToken.Name = "BTN_GetAccessToken";
            this.BTN_GetAccessToken.Size = new System.Drawing.Size(110, 23);
            this.BTN_GetAccessToken.TabIndex = 8;
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
            this.GBX_ContentInfo.TabIndex = 10;
            this.GBX_ContentInfo.TabStop = false;
            this.GBX_ContentInfo.Text = "Content Information";
            // 
            // TXT_SoundCopyright
            // 
            this.TXT_SoundCopyright.Location = new System.Drawing.Point(121, 110);
            this.TXT_SoundCopyright.Name = "TXT_SoundCopyright";
            this.TXT_SoundCopyright.ReadOnly = true;
            this.TXT_SoundCopyright.Size = new System.Drawing.Size(258, 23);
            this.TXT_SoundCopyright.TabIndex = 18;
            // 
            // LBL_SoundCopyright
            // 
            this.LBL_SoundCopyright.AutoSize = true;
            this.LBL_SoundCopyright.Location = new System.Drawing.Point(8, 113);
            this.LBL_SoundCopyright.Name = "LBL_SoundCopyright";
            this.LBL_SoundCopyright.Size = new System.Drawing.Size(100, 15);
            this.LBL_SoundCopyright.TabIndex = 17;
            this.LBL_SoundCopyright.Text = "Sound Copyright:";
            // 
            // TXT_Authors
            // 
            this.TXT_Authors.Location = new System.Drawing.Point(121, 52);
            this.TXT_Authors.Name = "TXT_Authors";
            this.TXT_Authors.ReadOnly = true;
            this.TXT_Authors.Size = new System.Drawing.Size(258, 23);
            this.TXT_Authors.TabIndex = 14;
            // 
            // TXT_Copyright
            // 
            this.TXT_Copyright.Location = new System.Drawing.Point(121, 81);
            this.TXT_Copyright.Name = "TXT_Copyright";
            this.TXT_Copyright.ReadOnly = true;
            this.TXT_Copyright.Size = new System.Drawing.Size(258, 23);
            this.TXT_Copyright.TabIndex = 16;
            // 
            // LBL_Copyright
            // 
            this.LBL_Copyright.AutoSize = true;
            this.LBL_Copyright.Location = new System.Drawing.Point(8, 84);
            this.LBL_Copyright.Name = "LBL_Copyright";
            this.LBL_Copyright.Size = new System.Drawing.Size(63, 15);
            this.LBL_Copyright.TabIndex = 15;
            this.LBL_Copyright.Text = "Copyright:";
            // 
            // TXT_Title
            // 
            this.TXT_Title.Location = new System.Drawing.Point(121, 23);
            this.TXT_Title.Name = "TXT_Title";
            this.TXT_Title.ReadOnly = true;
            this.TXT_Title.Size = new System.Drawing.Size(258, 23);
            this.TXT_Title.TabIndex = 12;
            // 
            // LBL_Title
            // 
            this.LBL_Title.AutoSize = true;
            this.LBL_Title.Location = new System.Drawing.Point(8, 26);
            this.LBL_Title.Name = "LBL_Title";
            this.LBL_Title.Size = new System.Drawing.Size(32, 15);
            this.LBL_Title.TabIndex = 11;
            this.LBL_Title.Text = "Title:";
            // 
            // LBL_Authors
            // 
            this.LBL_Authors.AutoSize = true;
            this.LBL_Authors.Location = new System.Drawing.Point(8, 55);
            this.LBL_Authors.Name = "LBL_Authors";
            this.LBL_Authors.Size = new System.Drawing.Size(60, 15);
            this.LBL_Authors.TabIndex = 13;
            this.LBL_Authors.Text = "Author(s):";
            // 
            // TCRTL_Main
            // 
            this.TCRTL_Main.Controls.Add(this.TPG_Search);
            this.TCRTL_Main.Controls.Add(this.TPG_History);
            this.TCRTL_Main.Location = new System.Drawing.Point(5, 3);
            this.TCRTL_Main.Name = "TCRTL_Main";
            this.TCRTL_Main.SelectedIndex = 0;
            this.TCRTL_Main.Size = new System.Drawing.Size(806, 371);
            this.TCRTL_Main.TabIndex = 50;
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
            // TPG_History
            // 
            this.TPG_History.Controls.Add(this.GBX_History);
            this.TPG_History.Controls.Add(this.GBX_ActionEvents);
            this.TPG_History.Controls.Add(this.GBX_SearchInfo);
            this.TPG_History.Location = new System.Drawing.Point(4, 24);
            this.TPG_History.Name = "TPG_History";
            this.TPG_History.Padding = new System.Windows.Forms.Padding(3);
            this.TPG_History.Size = new System.Drawing.Size(798, 343);
            this.TPG_History.TabIndex = 1;
            this.TPG_History.Text = "History";
            this.TPG_History.UseVisualStyleBackColor = true;
            // 
            // GBX_History
            // 
            this.GBX_History.Controls.Add(this.LVW_SearchHistory);
            this.GBX_History.Location = new System.Drawing.Point(6, 92);
            this.GBX_History.Name = "GBX_History";
            this.GBX_History.Size = new System.Drawing.Size(787, 245);
            this.GBX_History.TabIndex = 35;
            this.GBX_History.TabStop = false;
            this.GBX_History.Text = "History";
            // 
            // LVW_SearchHistory
            // 
            this.LVW_SearchHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CHDR_Favorite,
            this.CHDR_Title,
            this.CHDR_Author,
            this.CHDR_Type,
            this.CHDR_Link});
            this.LVW_SearchHistory.Location = new System.Drawing.Point(6, 20);
            this.LVW_SearchHistory.Name = "LVW_SearchHistory";
            this.LVW_SearchHistory.Size = new System.Drawing.Size(775, 219);
            this.LVW_SearchHistory.TabIndex = 36;
            this.LVW_SearchHistory.UseCompatibleStateImageBehavior = false;
            this.LVW_SearchHistory.View = System.Windows.Forms.View.Details;
            this.LVW_SearchHistory.SelectedIndexChanged += new System.EventHandler(this.LVW_SearchHistory_SelectedIndexChanged);
            // 
            // CHDR_Favorite
            // 
            this.CHDR_Favorite.Text = "★";
            this.CHDR_Favorite.Width = 30;
            // 
            // CHDR_Title
            // 
            this.CHDR_Title.Text = "Title";
            this.CHDR_Title.Width = 180;
            // 
            // CHDR_Author
            // 
            this.CHDR_Author.Text = "Author(s)";
            this.CHDR_Author.Width = 200;
            // 
            // CHDR_Type
            // 
            this.CHDR_Type.Text = "Type";
            this.CHDR_Type.Width = 80;
            // 
            // CHDR_Link
            // 
            this.CHDR_Link.Text = "Link";
            this.CHDR_Link.Width = 270;
            // 
            // GBX_ActionEvents
            // 
            this.GBX_ActionEvents.Controls.Add(this.BTN_OpenSearchHistory);
            this.GBX_ActionEvents.Controls.Add(this.BTN_UseSelectedSearch);
            this.GBX_ActionEvents.Controls.Add(this.BTN_ClearSearches);
            this.GBX_ActionEvents.Location = new System.Drawing.Point(400, 5);
            this.GBX_ActionEvents.Name = "GBX_ActionEvents";
            this.GBX_ActionEvents.Size = new System.Drawing.Size(393, 81);
            this.GBX_ActionEvents.TabIndex = 31;
            this.GBX_ActionEvents.TabStop = false;
            this.GBX_ActionEvents.Text = "Search Actions";
            // 
            // BTN_OpenSearchHistory
            // 
            this.BTN_OpenSearchHistory.Location = new System.Drawing.Point(260, 34);
            this.BTN_OpenSearchHistory.Name = "BTN_OpenSearchHistory";
            this.BTN_OpenSearchHistory.Size = new System.Drawing.Size(113, 23);
            this.BTN_OpenSearchHistory.TabIndex = 34;
            this.BTN_OpenSearchHistory.Text = "History Folder";
            this.BTN_OpenSearchHistory.UseVisualStyleBackColor = true;
            this.BTN_OpenSearchHistory.Click += new System.EventHandler(this.BTN_OpenSearchHistory_Click);
            // 
            // BTN_UseSelectedSearch
            // 
            this.BTN_UseSelectedSearch.Location = new System.Drawing.Point(22, 34);
            this.BTN_UseSelectedSearch.Name = "BTN_UseSelectedSearch";
            this.BTN_UseSelectedSearch.Size = new System.Drawing.Size(113, 23);
            this.BTN_UseSelectedSearch.TabIndex = 32;
            this.BTN_UseSelectedSearch.Text = "Use Search Info";
            this.BTN_UseSelectedSearch.UseVisualStyleBackColor = true;
            this.BTN_UseSelectedSearch.Click += new System.EventHandler(this.BTN_UseSelectedSearch_Click);
            // 
            // BTN_ClearSearches
            // 
            this.BTN_ClearSearches.Location = new System.Drawing.Point(141, 34);
            this.BTN_ClearSearches.Name = "BTN_ClearSearches";
            this.BTN_ClearSearches.Size = new System.Drawing.Size(113, 23);
            this.BTN_ClearSearches.TabIndex = 33;
            this.BTN_ClearSearches.Text = "Clear Searches";
            this.BTN_ClearSearches.UseVisualStyleBackColor = true;
            this.BTN_ClearSearches.Click += new System.EventHandler(this.BTN_ClearSearches_Click);
            // 
            // GBX_SearchInfo
            // 
            this.GBX_SearchInfo.Controls.Add(this.CHK_FavoriteSearchOnly);
            this.GBX_SearchInfo.Controls.Add(this.TXT_HistorySearch);
            this.GBX_SearchInfo.Controls.Add(this.CBX_HistorySearchBy);
            this.GBX_SearchInfo.Controls.Add(this.LBL_HistorySearchBy);
            this.GBX_SearchInfo.Controls.Add(this.LBL_HistorySearch);
            this.GBX_SearchInfo.Location = new System.Drawing.Point(6, 5);
            this.GBX_SearchInfo.Name = "GBX_SearchInfo";
            this.GBX_SearchInfo.Size = new System.Drawing.Size(389, 81);
            this.GBX_SearchInfo.TabIndex = 25;
            this.GBX_SearchInfo.TabStop = false;
            this.GBX_SearchInfo.Text = "Search Information";
            // 
            // CHK_FavoriteSearchOnly
            // 
            this.CHK_FavoriteSearchOnly.AutoSize = true;
            this.CHK_FavoriteSearchOnly.Location = new System.Drawing.Point(285, 50);
            this.CHK_FavoriteSearchOnly.Name = "CHK_FavoriteSearchOnly";
            this.CHK_FavoriteSearchOnly.Size = new System.Drawing.Size(101, 19);
            this.CHK_FavoriteSearchOnly.TabIndex = 30;
            this.CHK_FavoriteSearchOnly.Text = "Favorite Only?";
            this.CHK_FavoriteSearchOnly.UseVisualStyleBackColor = true;
            this.CHK_FavoriteSearchOnly.CheckedChanged += new System.EventHandler(this.CHK_FavoriteSearchOnly_CheckedChanged);
            // 
            // TXT_HistorySearch
            // 
            this.TXT_HistorySearch.Location = new System.Drawing.Point(92, 19);
            this.TXT_HistorySearch.Name = "TXT_HistorySearch";
            this.TXT_HistorySearch.Size = new System.Drawing.Size(290, 23);
            this.TXT_HistorySearch.TabIndex = 27;
            this.TXT_HistorySearch.TextChanged += new System.EventHandler(this.TXT_HistorySearch_TextChanged);
            // 
            // CBX_HistorySearchBy
            // 
            this.CBX_HistorySearchBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBX_HistorySearchBy.FormattingEnabled = true;
            this.CBX_HistorySearchBy.Items.AddRange(new object[] {
            "Title",
            "Author"});
            this.CBX_HistorySearchBy.Location = new System.Drawing.Point(92, 48);
            this.CBX_HistorySearchBy.Name = "CBX_HistorySearchBy";
            this.CBX_HistorySearchBy.Size = new System.Drawing.Size(184, 23);
            this.CBX_HistorySearchBy.TabIndex = 29;
            // 
            // LBL_HistorySearchBy
            // 
            this.LBL_HistorySearchBy.AutoSize = true;
            this.LBL_HistorySearchBy.Location = new System.Drawing.Point(6, 51);
            this.LBL_HistorySearchBy.Name = "LBL_HistorySearchBy";
            this.LBL_HistorySearchBy.Size = new System.Drawing.Size(61, 15);
            this.LBL_HistorySearchBy.TabIndex = 28;
            this.LBL_HistorySearchBy.Text = "Search By:";
            // 
            // LBL_HistorySearch
            // 
            this.LBL_HistorySearch.AutoSize = true;
            this.LBL_HistorySearch.Location = new System.Drawing.Point(6, 22);
            this.LBL_HistorySearch.Name = "LBL_HistorySearch";
            this.LBL_HistorySearch.Size = new System.Drawing.Size(76, 15);
            this.LBL_HistorySearch.TabIndex = 26;
            this.LBL_HistorySearch.Text = "Search Input:";
            // 
            // BTN_ClearSearch
            // 
            this.BTN_ClearSearch.Location = new System.Drawing.Point(255, 20);
            this.BTN_ClearSearch.Name = "BTN_ClearSearch";
            this.BTN_ClearSearch.Size = new System.Drawing.Size(110, 23);
            this.BTN_ClearSearch.TabIndex = 10;
            this.BTN_ClearSearch.Text = "Clear Search";
            this.BTN_ClearSearch.UseVisualStyleBackColor = true;
            this.BTN_ClearSearch.Click += new System.EventHandler(this.BTN_ClearSearch_Click);
            // 
            // SCAC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 378);
            this.Controls.Add(this.TCRTL_Main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(822, 380);
            this.Name = "SCAC";
            this.Text = "Spotify Content Availability Checker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SCAC_FormClosing);
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
            this.TPG_History.ResumeLayout(false);
            this.GBX_History.ResumeLayout(false);
            this.GBX_ActionEvents.ResumeLayout(false);
            this.GBX_SearchInfo.ResumeLayout(false);
            this.GBX_SearchInfo.PerformLayout();
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
        private TabPage TPG_History;
        private GroupBox GBX_SearchInfo;
        private TextBox TXT_HistorySearch;
        private ComboBox CBX_HistorySearchBy;
        private Label LBL_HistorySearchBy;
        private Label LBL_HistorySearch;
        private GroupBox GBX_ActionEvents;
        private GroupBox GBX_History;
        private ListView LVW_SearchHistory;
        private ColumnHeader CHDR_Title;
        private ColumnHeader CHDR_Author;
        private ColumnHeader CHDR_Type;
        private ColumnHeader CHDR_Link;
        private Button BTN_UseSelectedSearch;
        private Button BTN_ClearSearches;
        private ColumnHeader CHDR_Favorite;
        private Button BTN_OpenSearchHistory;
        private CheckBox CHK_FavoriteSearchOnly;
        private Button BTN_ClearSearch;
    }
}