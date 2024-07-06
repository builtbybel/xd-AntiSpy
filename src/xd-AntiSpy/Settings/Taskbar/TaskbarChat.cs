using xdAntiSpy;

using Microsoft.Win32;
using System;
using System.Drawing;

namespace Settings.Taskbar
{
    internal class TaskbarChat : SettingsBase
    {
        public TaskbarChat( Logger logger) : base(logger)
        {
        }

        private const string keyName = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced";
        private const int desiredValue = 1;

        public override string ID()
        {
            return "Hide Chat icon on taskbar";
        }

        public override string Info()
        {
            return "This feature will disable the chat icon on the taskbar.";
        }

        public override bool CheckFeature()
        {
            return !(
                   Utils.IntEquals(keyName, "TaskbarMn", desiredValue)
             );
        }

        public override bool DoFeature()
        {
            try
            {
                Registry.SetValue(keyName, "TaskbarMn", 0, RegistryValueKind.DWord);
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
                Registry.SetValue(keyName, "TaskbarMn", 1, RegistryValueKind.DWord);
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