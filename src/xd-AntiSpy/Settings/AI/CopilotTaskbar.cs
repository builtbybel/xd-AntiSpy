using xdAntiSpy;
using Microsoft.Win32;
using System;
using System.Drawing;

namespace Settings.AI
{
    public class CopilotTaskbar : SettingsBase
    {
        public CopilotTaskbar(Logger logger) : base(logger)
        {
        }

        private const string keyName = @"HKEY_CURRENT_USER\Software\Policies\Microsoft\Windows\WindowsCopilot";

        public override string ID() => "Don't Show Copilot in Taskbar";

        public override string Info() => "This feature will disable Copilot in Taskbar.";

        public override bool CheckFeature()
        {
            return Utils.IntEquals(keyName, "TurnOffWindowsCopilot", 1);
        }

        public override bool DoFeature()
        {
            try
            {
                Registry.SetValue(keyName, "TurnOffWindowsCopilot", 1, Microsoft.Win32.RegistryValueKind.DWord);

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
                Registry.SetValue(keyName, "TurnOffWindowsCopilot", 0, Microsoft.Win32.RegistryValueKind.DWord);

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