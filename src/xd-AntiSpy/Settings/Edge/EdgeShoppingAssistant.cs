using xdAntiSpy;

using Microsoft.Win32;
using System;
using System.Drawing;

namespace Settings.Edge
{
    public class EdgeShoppingAssistant : SettingsBase
    {
        public EdgeShoppingAssistant(Logger logger) : base(logger)
        {
        }

        private const string keyName = @"HKEY_LOCAL_MACHINE\Software\Policies\Microsoft\Edge";
        private const int desiredValue = 0;

        public override string ID() => "Disable Shopping assistant in Microsoft Edge";

        public override string Info() => "Shopping in Microsoft Edge feature will automatically find you the best prices and coupons from across the web as you shop";

        public override bool CheckFeature()
        {
            return Utils.IntEquals(keyName, "EdgeShoppingAssistantEnabled", desiredValue);
        }

        public override bool DoFeature()
        {
            try
            {
                Registry.SetValue(keyName, "EdgeShoppingAssistantEnabled", 0, Microsoft.Win32.RegistryValueKind.DWord);

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
                Registry.SetValue(keyName, "EdgeShoppingAssistantEnabled", 1, Microsoft.Win32.RegistryValueKind.DWord);

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