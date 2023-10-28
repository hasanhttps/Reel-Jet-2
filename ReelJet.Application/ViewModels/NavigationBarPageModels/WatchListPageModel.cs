using System;
using System.Windows;
using Reel_Jet.Commands;
using System.Windows.Input;
using System.Windows.Controls;
using Reel_Jet.Views.MoviePages;
using ReelJet.Database.Entities;
using System.Collections.ObjectModel;
using Reel_Jet.Models.DatabaseNamespace;
using Reel_Jet.Views.NavigationBarPages;

namespace Reel_Jet.ViewModels.NavigationBarPageModels {
    public class WatchListPageModel {

        // Private Fields

        private Frame MainFrame;

        // Binding Properties

        //public ObservableCollection<Movie> MyWatchList { get; set; } = Database.CurrentUser.MyWatchList;
        public Reel_Jet.Models.MovieNamespace.ShortMovieInfo? MovieInfo { get; set; }
        public ICommand WatchMovieFromWatchListCommand { get; set; }
        public ICommand RemoveFromWatchListCommand { get; set; }
        public ICommand? MovieListPgButtonCommand { get; set; }
        public ICommand? SettingsPgButtonCommand { get; set; }
        public ICommand? HistoryPgButtonCommand { get; set; }
        public ICommand? ProfilePgButtonCommand { get; set; }

        // Constructor

        public WatchListPageModel(Frame frame) {
            MainFrame = frame;

            WatchMovieFromWatchListCommand = new RelayCommand(WatchMovieFromWatchList);
            RemoveFromWatchListCommand = new RelayCommand(RemoveFromWatchList);
            MovieListPgButtonCommand = new RelayCommand(MovieListPage);
            SettingsPgButtonCommand = new RelayCommand(SettingsPage);
            HistoryPgButtonCommand = new RelayCommand(HistoryPage);
            ProfilePgButtonCommand = new RelayCommand(ProfilePage);
        }

        // Functions

        private void MovieListPage(object? sender) {
            MainFrame.Content = new MovieListPage(MainFrame);
        }

        private void HistoryPage(object? sender) {
            MainFrame.Content = new HistoryPage(MainFrame);
        }

        private void ProfilePage(object? sender) {
            MainFrame.Content = new UserAccountPage(MainFrame);
        }
        private void SettingsPage(object? sender) {
            MainFrame.Content = new SettingsPage(MainFrame);
        }

        private void WatchMovieFromWatchList(object? sender) {
            Movie movie = (sender as Movie)!;
            MainFrame.Content = new VideoPlayerPage(MainFrame, movie);
        }

        private void RemoveFromWatchList(object? sender) {
            Movie a = (sender as Movie)!;
            //MyWatchList.Remove(a);
            //JsonHandling.WriteData(Database.Users, "users");
        }
    }
}