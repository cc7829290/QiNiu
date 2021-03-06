﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace QINIUYUN
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            //加载界面
            var AppearanceManager = WPFTools.Presentation.AppearanceManager.Current;
            AppearanceManager.AccentColor = QINIUYUN.Properties.Settings.Default.SelectedAccentColor;
            AppearanceManager.FontSize = QINIUYUN.Properties.Settings.Default.SelectedFontSize;
            if (QINIUYUN.Properties.Settings.Default.SelectedTheme == 0)
            {
                AppearanceManager.ThemeSource = WPFTools.Presentation.AppearanceManager.LightThemeSource;
            }
            else if (QINIUYUN.Properties.Settings.Default.SelectedTheme == 1)
            {
                AppearanceManager.ThemeSource = WPFTools.Presentation.AppearanceManager.DarkThemeSource;
            }
        }
    }
}
