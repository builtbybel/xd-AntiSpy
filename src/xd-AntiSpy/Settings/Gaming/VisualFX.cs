using xdAntiSpy;

using Microsoft.Win32;
using System;
using System.Drawing;

namespace Settings.Gaming
{
    public class VisualFX : SettingsBase
    {
        public VisualFX( Logger logger) : base(logger)
        {
        }

        private const string keyName = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects";
        private const int desiredValue = 2;

        public override string ID() => "Disable VisualFX";

        public override string Info() => "This feature will disable VisualFX.";

        public override bool CheckFeature()
        {
            return Utils.IntEquals(keyName, "VisualFXSetting",0);
        }

        public override bool DoFeature()
        {
            try
            {
                Registry.SetValue(keyName, "VisualFXSetting", 0, RegistryValueKind.DWord);

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
                Registry.SetValue(keyName, "VisualFXSetting", 2, RegistryValueKind.DWord);

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