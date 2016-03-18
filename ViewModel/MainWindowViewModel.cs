﻿/* ===================================================================
 License:
    DiscerningEye - FFXIV Gathering Dictionary and Alarm
    MainWindowViewModel.cs


    Copyright(C) 2015 - 2016  Christopher Whitley

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.If not, see<http://www.gnu.org/licenses/> .
  =================================================================== */


using DiscerningEye.Commands;
using DiscerningEye.DataAccess;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace DiscerningEye.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {

        //================================================================
        //  Fields
        //================================================================
        //readonly GatheringItemRepository _gatheringItemRepository;
        public static MainWindowViewModel ViewModel;




        ObservableCollection<ViewModelBase> _viewModels;
        private bool _isGatheringDictionaryOpen;


        //================================================================
        //  Properties
        //================================================================
        public bool IsGatheringDictionaryOpen
        {
            get { return this._isGatheringDictionaryOpen; }
            set
            {
                if (this._isGatheringDictionaryOpen == value) return;
                this._isGatheringDictionaryOpen = value;
                OnPropertyChanged("IsGatheringDictionaryOpen");
            }
        }


        public ObservableCollection<ViewModelBase> ViewModels
        {
            get
            {
                if (_viewModels == null)
                    _viewModels = new ObservableCollection<ViewModelBase>();
                return _viewModels;
            }
        }








        //================================================================
        //  Commands
        //================================================================
        /// <summary>
        /// Gets or sets the SettingsCommand
        /// </summary>
        /// <remarks>
        /// This is bound to the Command of the Settings button on MainWindow.xaml
        /// </remarks>
        public ICommand SettingsCommand
        {
            get;
            private set;
        }


        /// <summary>
        /// Gets or sets the SettingsSaveCommand
        /// </summary>
        /// <remarks>
        /// This is not bound to any controls on a view, instead it is called
        /// explicity when the Settings flyout on MainWindow.xaml is closed.
        /// </remarks>
        public ICommand SettingsSaveCommand
        {
            get;
            private set;
        }


        public ICommand GitHubCommand
        {
            get;
            private set;
        }

        public ICommand MinimalNotificationCommand
        {
            get;
            private set;
        }

        public ICommand AllNotificationsCommand
        {
            get;
            private set;
        }

        public ICommand OpenGatheringDictionaryCommand
        {
            get;
            private set;
        }






        //================================================================
        //  Constructor
        //================================================================
        /// <summary>
        /// Creates a new instance of MainWindowViewModel
        /// </summary>
        public MainWindowViewModel()
        {

            this.GitHubCommand = new LaunchGithubPageCommand(this);
            this.MinimalNotificationCommand = new MinimalNotificationsCommand(this);
            this.AllNotificationsCommand = new AllNotificationsCommand(this);
            this.OpenGatheringDictionaryCommand = new Commands.MainWindowViewModelCommands.OpenGatheringDictionaryCommand(this);
            MainWindowViewModel.ViewModel = this;
        }


        //================================================================
        //  Functions
        //================================================================

        public void OpenGatheringDictionary()
        {
            this.IsGatheringDictionaryOpen = true;
        }

        public void LaunchGithubPage()
        {
            System.Diagnostics.Process.Start("https://github.com/dartvalince");
        }

        public void MinimalNotifications()
        {
            Properties.Settings.Default.EnableAlarms = true;
            Properties.Settings.Default.EnableBallonTip = true;
            Properties.Settings.Default.EnableEarlyWarning = true;
            Properties.Settings.Default.EnableNotificationTone = false;
            Properties.Settings.Default.EnableTextToSpeech = false;
        }

        public void AllNotifications()
        {
            Properties.Settings.Default.EnableAlarms = true;
            Properties.Settings.Default.EnableBallonTip = true;
            Properties.Settings.Default.EnableEarlyWarning = true;
            Properties.Settings.Default.EnableNotificationTone = true;
            Properties.Settings.Default.EnableTextToSpeech = true;
        }


    }
}
