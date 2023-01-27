namespace SpotifyContentAvailabilityChecker
{
    public partial class SettingsWindow : Form
    {
        readonly SCAC referenceForm;

        public SettingsWindow(SCAC referenceForm)
        {
            InitializeComponent();
            this.referenceForm = referenceForm;
        }

        private void SettingsWindow_Load(object sender, EventArgs e)
        {
            CHK_EnableSearchSwitch.Checked = Properties.Settings.Default.EnableSearchSwitch;
            CHK_ShowGridlines.Checked = Properties.Settings.Default.ShowGridLines;
        }

        private void BTN_SaveSettings_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ShowGridLines = CHK_ShowGridlines.Checked;
            referenceForm.LVW_CountryResults.GridLines = CHK_ShowGridlines.Checked;
            referenceForm.LVW_SearchHistory.GridLines = CHK_ShowGridlines.Checked;

            Properties.Settings.Default.EnableSearchSwitch = CHK_EnableSearchSwitch.Checked;

            Properties.Settings.Default.Save();
        }
    }
}
