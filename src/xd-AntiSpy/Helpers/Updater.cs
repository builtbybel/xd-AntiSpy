using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using System.Drawing;
using xdAntiSpy;

namespace Updater
{
    internal class Updater
    {
        public bool CheckForAppUpdates(Logger logger)
        {
            if (IsInet())
            {
                try
                {
                    string assemblyInfo = new WebClient().DownloadString("https://raw.githubusercontent.com/builtbybel/xd-AntiSpy/main/src/xd-AntiSpy/Properties/AssemblyInfo.cs");

                    var readVersion = assemblyInfo.Split('\n');
                    var infoVersion = readVersion.Where(t => t.Contains("[assembly: AssemblyFileVersion"));
                    var latestVersion = "";
                    foreach (var item in infoVersion)
                    {
                        latestVersion = item.Substring(item.IndexOf('(') + 2, item.LastIndexOf(')') - item.IndexOf('(') - 3);
                    }

                    if (latestVersion == Program.GetCurrentVersionTostring()) // Up-to-date
                    {
                        MessageBox.Show("No new updates available.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    else if (latestVersion != Program.GetCurrentVersionTostring()) // Update available
                    {
                        if (MessageBox.Show($"App version {latestVersion} available.\nDo you want to open the Download page?", "App update available", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            Process.Start("https://github.com/builtbybel/xd-Antispy/releases");
                        }
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    logger.Log($"Code red for App updates check: {ex.Message} Maybe the project is still too new.", Color.Red);
                }
            }
            else
            {
                logger.Log("Problem on Internet connection: Checking for App updates failed", Color.Red);
            }

            // Return false if with exception or problem with inet
            MessageBox.Show("No updates checked or available.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return false;
        }

        // Check Internet
        public static bool IsInet()
        {
            try
            {
                using (var checkInternet = new WebClient())
                using (checkInternet.OpenRead("http://clients3.google.com/generate_204"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
