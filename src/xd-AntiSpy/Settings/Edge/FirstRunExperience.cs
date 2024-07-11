using Microsoft.Win32;
using System;
using System.Drawing;
using xdAntiSpy;
using xdAntiSpy.Locales;

namespace Settings.Edge
{
    public class FirstRunExperience : SettingsBase
    {
        public FirstRunExperience(Logger logger) : base(logger)
        {
        }

        private const string keyName = @"HKEY_LOCAL_MACHINE\Software\Policies\Microsoft\Edge";
        private const int desiredValue = 1;

        public override string ID() => Strings._edgeFirstRunExperience;

        public override string Info() => Strings._edgeFirstRunExperience_desc;

        public override bool CheckFeature()
        {
            return Utils.IntEquals(keyName, "HideFirstRunExperience", desiredValue);
        }

        public override bool DoFeature()
        {
            try
            {
                Registry.SetValue(keyName, "HideFirstRunExperience", 1, Microsoft.Win32.RegistryValueKind.DWord);

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
                Registry.SetValue(keyName, "HideFirstRunExperience", 0, Microsoft.Win32.RegistryValueKind.DWord);

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