namespace SpotifyContentAvailabilityChecker.Helpers
{
    public static class MessageBoxDisplayHelper
    {
        public static void ShowError(string title, string caption)
        {
            MessageBox.Show(title, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static DialogResult ShowQuestion(string title, string caption)
        {
            return MessageBox.Show(title, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
    }
}
