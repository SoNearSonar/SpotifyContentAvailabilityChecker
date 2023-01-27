using SpotifyContentAvailabilityChecker.Helpers;
using System.Diagnostics;

namespace SpotifyContentAvailabilityChecker
{
    public partial class SettingsWindow : Form
    {
        private readonly SCAC _referenceForm;
        private readonly Process _process;

        public SettingsWindow(SCAC referenceForm)
        {
            InitializeComponent();
            _referenceForm = referenceForm;
            _process = ProcessStarterHelper.CreateProcess(ProcessStarterHelper.DirPath, "explorer.exe");
        }

        private void SettingsWindow_Load(object sender, EventArgs e)
        {
            CHK_EnableSearchSwitch.Checked = Properties.Settings.Default.EnableSearchSwitch;
            CHK_ShowGridlines.Checked = Properties.Settings.Default.ShowGridLines;
        }

        private void BTN_SaveSettings_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ShowGridLines = CHK_ShowGridlines.Checked;
            _referenceForm.LVW_CountryResults.GridLines = CHK_ShowGridlines.Checked;
            _referenceForm.LVW_SearchHistory.GridLines = CHK_ShowGridlines.Checked;

            Properties.Settings.Default.EnableSearchSwitch = CHK_EnableSearchSwitch.Checked;

            Properties.Settings.Default.Save();
        }

        private void BTN_OpenHistoryFolder_Click(object sender, EventArgs e)
        {
            _process.Start();
        }
    }
}
