using xdAntiSpy;
using xdAntiSpy.Locales;
using Microsoft.Win32;
using System;
using System.Drawing;

namespace Settings.Gaming
{
    public class GameDVR : SettingsBase
    {
        public GameDVR( Logger logger) : base(logger)
        {
        }

        private const string keyName = @"HKEY_CURRENT_USER\System\GameConfigStore";
        // 0 = Enabled, 2 = Disabled
        private const string keyName2 = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\PolicyManager\default\ApplicationManagement\AllowGameDVR";

        
        public override string ID() => Strings._gamingGameDVR;

        public override string Info() => Strings._gamingGameDVR_desc;

        public override bool CheckFeature()
        {
            return Utils.IntEquals(keyName, "GameDVR_Enabled", 0) &&
                    Utils.IntEquals(keyName, "GameDVR_FSEBehaviorMode", 2) &&
                    Utils.IntEquals(keyName2, "value", 0);
        }

        public override bool DoFeature()
        {
            try
            {
                Registry.SetValue(keyName, "GameDVR_Enabled", 0, RegistryValueKind.DWord);
                Registry.SetValue(keyName, "GameDVR_FSEBehaviorMode", 2, RegistryValueKind.DWord);
                Registry.SetValue(keyName2, "value", 0, RegistryValueKind.DWord);

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
                Registry.SetValue(keyName, "GameDVR_Enabled", 1, RegistryValueKind.DWord);
                Registry.SetValue(keyName, "GameDVR_FSEBehaviorMode", 0, RegistryValueKind.DWord);
                Registry.SetValue(keyName2, "value", 1, RegistryValueKind.DWord);

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