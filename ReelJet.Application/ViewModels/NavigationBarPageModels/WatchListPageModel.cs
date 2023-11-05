using System;
using System.Linq;
using System.Windows;
using Reel_Jet.Commands;
using System.Windows.Input;
using System.Windows.Controls;
using Reel_Jet.Views.MoviePages;
using ReelJet.Database.Entities;
using System.Collections.ObjectModel;
using Reel_Jet.Views.NavigationBarPages;
using ReelJet.Database.Entities.Concretes;
using static ReelJet.Application.Models.DatabaseNamespace.Database;


namespace Reel_Jet.ViewModels.NavigationBarPageModels {
    public class WatchListPageModel {

        // Private Fields

        private Frame MainFrame;

        // Binding Properties

        public ObservableCollection<Movie> MyWatchList { get; set; } = new ObservableCollection<Movie>();
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

            if (CurrentUser.WatchList != null) {
                foreach (var movie in CurrentUser.WatchList) {
                    MyWatchList.Add(movie.Movie);
                }
            }

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
 
            try {
                var Movie = (sender as ReelJet.Database.Entities.Movie)!;
                ReelJet.Database.Entities.Concretes.UserHistoryList historyList = new() {
                    UserId = CurrentUser.Id,
                    Movie = Movie,
                    MovieId = Movie.Id,
                    User = CurrentUser,
                };
 
                if(!DbContext.HistoryLists.Any(entity => entity.UserId == historyList.UserId && entity.Movie.imdbID==historyList.Movie.imdbID)) {
                    DbContext.HistoryLists.Add(historyList);
                    DbContext.SaveChanges();
                }
                
                MainFrame.Content = new VideoPlayerPage(MainFrame, Movie);
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void RemoveFromWatchList(object? sender) {

            ReelJet.Database.Entities.Movie a = (sender as ReelJet.Database.Entities.Movie)!;
            MyWatchList.Remove(a);
            UserWatchList? deleteditem = null;

            foreach (var item in DbContext.WatchLists)
                if (item.UserId == CurrentUser.Id && item.MovieId == a.Id) deleteditem = item;

            DbContext.WatchLists.Remove(deleteditem);
            DbContext.SaveChanges();
        }
    }
}