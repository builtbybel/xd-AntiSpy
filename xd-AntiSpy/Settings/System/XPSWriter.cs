using System;
using System.Drawing;
using System.Management.Automation;
using System.Threading.Tasks;
using xdAntiSpy;
using LocalizationLibrary.Locales;

namespace Settings.System
{
    internal class XPSWriter : SettingsBase
    {
        public XPSWriter(Logger logger) : base(logger)
        {
        }

        public override string ID()
        {
            return Strings._systemXPSWriter;
        }

        public override string Info()
        {
            return Strings._systemXPSWriter_desc;
        }

        public override bool CheckFeature()
        {
            const string script = "Get-WindowsOptionalFeature -Online -FeatureName \"Printing-XPSServices-Features\"";
            bool isFeatureDisabled = true;

            try
            {
                // Check with a timeout
                using (PowerShell powerShell = PowerShell.Create())
                {
                    powerShell.AddScript(script);
                    var task = Task.Run(() => powerShell.Invoke());

                    if (task.Wait(TimeSpan.FromSeconds(3)))
                    {
                        var results = task.Result;

                        foreach (var item in results)
                        {
                            var status = item.Members["State"].Value.ToString();

                            if (status == "Enabled")
                            {
                                logger.Log("XPS Documents Writer is installed.", Color.Green);
                                isFeatureDisabled = false;
                                break;
                            }
                        }
                    }
                    else
                    {
                        // Timeout occurred
                        logger.Log("Check XPSWriter timed out. Skipping feature check.", Color.Orange);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Log($"Error checking feature: {ex.Message}", Color.Red);
            }

            return isFeatureDisabled;
        }

        public override bool DoFeature()
        {
            logger.Log("I am uninstalling XPS Documents Writer. Please wait.", Color.Magenta);

            string script = "Disable-WindowsOptionalFeature -Online -FeatureName \"Printing-XPSServices-Features\" -NoRestart -WarningAction SilentlyContinue | Out-Null";
            PowerShell powerShell = PowerShell.Create();
            powerShell.AddScript(script);

            Task.Run(() =>
            {
                var results = powerShell.Invoke();

                if (powerShell.Streams.Error.Count > 0)
                {
                    logger.Log("= XPS Documents Writer not found.", Color.Red);
                }
                else
                {
                    logger.Log("XPS Documents Writer has been successfully removed.", Color.Green);
                }
            });

            return true;
        }

        public override bool UndoFeature()
        {
            logger.Log("Reinstalling 'XPS Documents Writer'. Please wait.", Color.Magenta);

            string script = "Enable-WindowsOptionalFeature -Online -FeatureName \"Printing-XPSServices-Features\" -NoRestart -WarningAction SilentlyContinue | Out-Null";
            PowerShell powerShell = PowerShell.Create();
            powerShell.AddScript(script);

            Task.Run(() =>
            {
                var results = powerShell.Invoke();

                if (powerShell.Streams.Error.Count > 0)
                {
                    logger.Log("XPS Documents Writer could not be installed.", Color.Red);
                }
                else
                {
                    logger.Log("XPS Documents Writer has been successfully installed.", Color.Green);
                }
            });

            return true;
        }
    }
}