using System;
using Reel_Jet.Commands;
using System.Windows.Input;
using System.Windows.Controls;
using Reel_Jet.Views.MoviePages;
using Reel_Jet.Views.NavigationBarPages;
using Reel_Jet.Views.NavigationBarPages.SettingsPages;


namespace Reel_Jet.ViewModels.NavigationBarPageModels {
    public class SettingsPageModel {

        // Private Fields

        private Frame MainFrame;
        private Frame SettingsFrame;

        // Binding Properties

        public ICommand? ClearCacheDataButtonCommand { get; set; }
        public ICommand? WatchListPgButtonCommand { get; set; }
        public ICommand? HistoryPgButtonCommand { get; set; }
        public ICommand? ProfilePgButtonCommand { get; set; }
        public ICommand? AccountPgButtonCommand { get; set; }
        public ICommand? MovieListPageCommand { get; set; }

        // Constructor

        public SettingsPageModel(Frame frame, Frame settingsframe) { 
            MainFrame = frame;
            SettingsFrame = settingsframe;

            ClearCacheDataButtonCommand = new RelayCommand(ClearCacheData);
            WatchListPgButtonCommand = new RelayCommand(WatchListPage);
            MovieListPageCommand = new RelayCommand(MovieListPage);
            ProfilePgButtonCommand = new RelayCommand(ProfilePage);
            AccountPgButtonCommand = new RelayCommand(AccountPage);
            HistoryPgButtonCommand = new RelayCommand(HistoryPage);
        }

        // Functions

        private void HistoryPage(object? sender) {
            MainFrame.Content = new HistoryPage(MainFrame);
        }

        private void WatchListPage(object? sender) {
            MainFrame.Content = new WatchListPage(MainFrame);
        }

        private void MovieListPage(object? sender) {
            MainFrame.Content = new MovieListPage(MainFrame);
        }

        private void AccountPage(object? sender) {
            SettingsFrame.Content = new AccountPage();
        }

        private void ClearCacheData(object? sender) {

        }

        private void ProfilePage(object? sender) {
            MainFrame.Content = new UserAccountPage(MainFrame);
        }
    }
}
