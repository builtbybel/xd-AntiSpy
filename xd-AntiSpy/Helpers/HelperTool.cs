using System.IO;
using System.Windows.Forms;

namespace HelperTool
{
    internal class Utils

    {
        public static class Data
        {
            public static string DataRootDir = Application.StartupPath +
                                                @"\app\";
        }

        // Create data directory if non present
        public static void CreateDataDir()
        {
            bool dirExists = Directory.Exists(@"app");
            if (!dirExists)
                Directory.CreateDirectory(@"app");
        }
    }
}