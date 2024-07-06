using Microsoft.Win32;
using System;
using System.Drawing;

using xdAntiSpy;

namespace Settings.Edge
{
    public class StartupBoost : SettingsBase
    {
        public StartupBoost(Logger logger) : base(logger)
        {
        }

        private const string keyName = @"HKEY_LOCAL_MACHINE\Software\Policies\Microsoft\Edge";
        private const int desiredValue = 0;

        public override string ID() => "Disable Start Boost";

        public override string Info() => "Enables Microsoft Edge processes to initialize at operating system startup and restart in the background after the last browser window has been closed";

        public override bool CheckFeature()
        {
            return Utils.IntEquals(keyName, "StartupBoostEnabled", desiredValue);
        }

        public override bool DoFeature()
        {
            try
            {
                Registry.SetValue(keyName, "StartupBoostEnabled", 0, Microsoft.Win32.RegistryValueKind.DWord);

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
                Registry.SetValue(keyName, "StartupBoostEnabled", 1, Microsoft.Win32.RegistryValueKind.DWord);

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