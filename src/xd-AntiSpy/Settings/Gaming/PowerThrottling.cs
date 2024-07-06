using xdAntiSpy;

using Microsoft.Win32;
using System;
using System.Drawing;

namespace Settings.Gaming
{
    public class PowerThrottling : SettingsBase
    {
        public PowerThrottling( Logger logger) : base(logger)
        {
        }

        private const string keyName = @"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Power\PowerThrottling";

        public override string ID() => "Turn off PowerThrottling";

        public override string Info() => "This feature will disable PowerThrottling.";

        public override bool CheckFeature()
        {
            return Utils.IntEquals(keyName, "PowerThrottlingOff", 1);
        }

        public override bool DoFeature()
        {
            try
            {
                Registry.SetValue(keyName, "PowerThrottlingOff", 1, Microsoft.Win32.RegistryValueKind.DWord);

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
                Registry.SetValue(keyName, "PowerThrottlingOff", 0, Microsoft.Win32.RegistryValueKind.DWord);

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