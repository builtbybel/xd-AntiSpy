using System.Management.Automation;
using xdAntiSpy;

namespace Settings.System
{
    internal class FaxPrinter : SettingsBase
    {
        public FaxPrinter(Logger logger) : base(logger)
        {
        }

        public override string ID()
        {
            return "Uninstall Fax Printer";
        }

        public override string Info()
        {
            return "This feature will uninstall the Fax Printer.";
        }

        public override bool CheckFeature()
        {
            return false;
        }

        public override bool DoFeature()
        {
            string script = "Remove-Printer -Name \"Fax\"";

            PowerShell powerShell = PowerShell.Create();

            powerShell.AddScript(script);
            powerShell.Invoke();

            if (powerShell.Streams.Error.Count > 0)
            {
                return false;
            }
            return true;
        }

        public override bool UndoFeature()
        {
            return true;
        }
    }
}