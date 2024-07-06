using xdAntiSpy;

using Microsoft.Win32;
using System;
using System.Drawing;

namespace Settings.System
{
    public class VerboseMessages : SettingsBase
    {
        public VerboseMessages( Logger logger) : base(logger)
        {
        }

        private const string keyName = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System";
        private const int desiredValue = 0;

        public override string ID() => "Display highly detailed status messages";

        public override string Info() => "This feature will display highly detailed status messages.";

        public override bool CheckFeature()
        {
            return !Utils.IntEquals(keyName, "verbosestatus", desiredValue);
        }

        public override bool DoFeature()
        {
            try
            {
                Registry.SetValue(keyName, "verbosestatus", 1, RegistryValueKind.DWord);

                return true;
            }
            catch (Exception ex)
            {
                logger.Log("Code red in " + ex.Message, Color.Red);
            }

            return false;
        }

        public override bool UndoFeature()
        {
            try
            {
                Registry.SetValue(keyName, "verbosestatus", desiredValue, Microsoft.Win32.RegistryValueKind.DWord);

                return true;
            }
            catch (Exception ex)
            {
                logger.Log("Code red in " + ex.Message, Color.Red);
            }

            return false;
        }
    }
}