using System.Diagnostics;

namespace SpotifyContentAvailabilityChecker.Helpers
{
    public static class ProcessStarterHelper
    {
        public static string DirPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SCAC");
        public static string FilePath = Path.Combine(DirPath, "SearchHistory.json");

        public static Process CreateProcess(string arguments, string fileName)
        {
            return new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = fileName,
                    Arguments= arguments,
                }
            };
        }
    }
}
