﻿using Microsoft.Win32;
using System;
using System.Drawing;
using xdAntiSpy;
using xdAntiSpy.Locales;

namespace Settings.Ads
{
    public class WelcomeExperienceAds : SettingsBase
    {
        public WelcomeExperienceAds(Logger logger) : base(logger)
        {
        }

        private const string keyName = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager";
        private const string valueName = "SubscribedContent-310093Enabled";
        private const int desiredValue = 0;

        public override string ID() => Strings._adsWelcomeExperienceAds;

        public override string Info() => Strings._adsWelcomeExperienceAds_desc;

        public override bool CheckFeature()
        {
            return Utils.IntEquals(keyName, valueName, 0);
        }

        public override bool DoFeature()
        {
            try
            {
                Registry.SetValue(keyName, valueName, 0, Microsoft.Win32.RegistryValueKind.DWord);

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
                Registry.SetValue(keyName, valueName, 1, Microsoft.Win32.RegistryValueKind.DWord);

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