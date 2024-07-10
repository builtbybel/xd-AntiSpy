using xdAntiSpy;
using xdAntiSpy.Locales;
using System.Drawing;
using System.Management.Automation;
using System.Threading.Tasks;

namespace Settings.System
{
    internal class XPSWriter : SettingsBase
    {
        public XPSWriter( Logger logger) : base(logger)
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
            string script = "Get-WindowsOptionalFeature -Online -FeatureName \"Printing-XPSServices-Features\"";

            PowerShell powerShell = PowerShell.Create();
            powerShell.AddScript(script);

            var results = powerShell.Invoke();

            foreach (var item in results)
            {
                var Status = item.Members["State"].Value;

                if (Status.ToString() == "Enabled")
                {
                     logger.Log("XPS Documents Writer is installed.", Color.Green);
                    return false;
                }
            }


            return true;
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