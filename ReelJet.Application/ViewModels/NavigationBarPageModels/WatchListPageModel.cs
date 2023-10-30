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

            var Movie = (sender as ReelJet.Database.Entities.Movie)!;
            MainFrame.Content = new VideoPlayerPage(MainFrame, Movie);
        }

        private void RemoveFromWatchList(object? sender) {
            Movie a = (sender as Movie)!;
            MyWatchList.Remove(a);
            UserWatchList? deleteditem = null;

            foreach (var item in DbContext.WatchLists) {
                if (item.UserId == CurrentUser.Id && item.MovieId == a.Id) deleteditem = item;
            }
            DbContext.WatchLists.Remove(deleteditem);
            DbContext.SaveChanges();
        }
    }
}