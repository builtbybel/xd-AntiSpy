﻿using Microsoft.Win32;
using System;
using System.Drawing;
using xdAntiSpy;
using xdAntiSpy.Locales;

namespace Settings.Taskbar
{
    internal class StartmenuLayout : SettingsBase
    {
        public StartmenuLayout(Logger logger) : base(logger)
        {
        }

        private const string keyName = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced";
        private const string valueName = "Start_Layout";
        private const int desiredValue = 1;

        public override string ID()
        {
            return Strings._taskbarStartmenuLayout;
        }

        public override string Info()
        {
            return Strings._taskbarStartmenuLayout_desc;
        }

        public override bool CheckFeature()
        {
            return (
                   Utils.IntEquals(keyName, valueName, desiredValue)
             );
        }

        public override bool DoFeature()
        {
            try
            {
                Registry.SetValue(keyName, valueName, 1, RegistryValueKind.DWord);
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
                Registry.SetValue(keyName, valueName, 0, RegistryValueKind.DWord);
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