using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Threading.Tasks;

namespace OSHelper
{
    internal class OSHelper
    {
        public static async Task<string> GetWindowsVersion()
        {
            return await Task.Run(() =>
            {
                try
                {
                    using (PowerShell powerShellInstance = PowerShell.Create())
                    {
                        powerShellInstance.AddScript("Get-CimInstance -ClassName Win32_OperatingSystem");
                        Collection<PSObject> psOutput = powerShellInstance.Invoke();

                        foreach (PSObject outputItem in psOutput)
                        {
                            if (outputItem != null)
                            {
                                string productName = outputItem.Properties["Caption"]?.Value?.ToString();
                                if (!string.IsNullOrEmpty(productName))
                                {
                                    string osVersion = productName.Contains("Windows 10") ? "Windows 10" : "Windows 11";

                                    using (RegistryKey displayVersionKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion"))
                                    {
                                        if (displayVersionKey != null)
                                        {
                                            string displayVersion = displayVersionKey.GetValue("DisplayVersion")?.ToString();
                                            return $"{osVersion} ({displayVersion})";
                                        }
                                    }
                                    return osVersion;
                                }
                            }
                        }
                    }
                }
                catch
                {
                }
                return "OS not supported";
            });
        }
    }
}