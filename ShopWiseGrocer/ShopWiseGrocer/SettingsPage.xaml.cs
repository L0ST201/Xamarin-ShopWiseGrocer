﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace ShopWiseGrocer
{
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();

            LanguagePicker.ItemsSource = new List<string>
        {
            "English",
            "Spanish",
            "French",
        };

            string currentLanguage = Preferences.Get("AppLanguage", "English");
            LanguagePicker.SelectedIndex = LanguagePicker.ItemsSource.IndexOf(currentLanguage);

            double currentFontSize = Preferences.Get("AppFontSize", 16);
            FontSizeSlider.Value = currentFontSize;
        }

        void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                string selectedLanguage = (string)picker.ItemsSource[selectedIndex];

                HandleLanguageChange(selectedLanguage);
            }
        }

        void HandleLanguageChange(string language)
        {
            Preferences.Set("AppLanguage", language);
        }

        void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            Preferences.Set("AppFontSize", e.NewValue);
        }
    }
}