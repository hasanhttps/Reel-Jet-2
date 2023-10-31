using System;
using System.Windows;
using Reel_Jet.Commands;
using System.Windows.Input;
using System.ComponentModel;
using System.Windows.Controls;
using Reel_Jet.Views.MoviePages;
using Reel_Jet.Models.MovieNamespace;
using System.Runtime.CompilerServices;
using Reel_Jet.Views.NavigationBarPages;
using static ReelJet.Application.Models.DatabaseNamespace.Database;


namespace Reel_Jet.ViewModels.MoviePageModels {
    public class MoviePreviewPageModel : INotifyPropertyChanged {

        // Private Fields

        private Movie? _movie;
        private Frame MainFrame;

        // Binding Properties

        public ICommand? WatchListPgButtonCommand { get; set; }
        public ICommand? SettingsPgButtonCommand { get; set; }
        public ICommand? HistoryPgButtonCommand { get; set; }
        public ICommand? ProfilePgButtonCommand { get; set; }
        public ICommand? VideoPlayerPageCommand { get; set; }
        public ICommand? MovieListPageCommand { get; set; }
        public string trailerLink { get; set; }
        public Movie Movie {
            get => _movie!;
            set {
                _movie = value;
            }
        }

        // Constructor

        public MoviePreviewPageModel(Frame frame, Movie movie) { 
            
            MainFrame = frame;
            Movie = movie;

            trailerLink = "https://www.youtube.com/results?search_query=" + movie.Title + " trailer";

            WatchListPgButtonCommand = new RelayCommand(WatchListPage);
            VideoPlayerPageCommand = new RelayCommand(VideoPlayerPage);
            SettingsPgButtonCommand = new RelayCommand(SettingsPage);
            HistoryPgButtonCommand = new RelayCommand(HistoryPage);
            ProfilePgButtonCommand = new RelayCommand(ProfilePage);
            MovieListPageCommand = new RelayCommand(MovieListPage);
        }

        // Functions

        private void MovieListPage(object? param) {
            MainFrame.Content = new MovieListPage(MainFrame);
        }

        private void HistoryPage(object? sender) {
            MainFrame.Content = new HistoryPage(MainFrame);
        }

        private void WatchListPage(object? sender) {
            MainFrame.Content = new WatchListPage(MainFrame);
        }

        private void SettingsPage(object? sender) {
            MainFrame.Content = new SettingsPage(MainFrame);
        }

        private void ProfilePage(object? sender) {
            MainFrame.Content = new UserAccountPage(MainFrame);
        }
        
        private void VideoPlayerPage(object? param) {
            
            bool isContain = false;

            ReelJet.Database.Entities.Movie MovieAdapter = new();

            if (CurrentUser.HistoryList != null)
                foreach(var movie in CurrentUser.HistoryList) {
                    if (movie.Movie.Title == Movie.Title && movie.Movie.imdbID == Movie.imdbID) {

                        MovieAdapter = movie.Movie;
                        isContain = true;
                    }
                }


            if (!isContain) {

                ReelJet.Database.Entities.Movie movie = new() {
                    Actors = Movie.Actors,
                    Awards = Movie.Awards,
                    BoxOffice = Movie.BoxOffice,
                    Country = Movie.Country,
                    Director = Movie.Director,
                    DVD = Movie.DVD,
                    Genre = Movie.Genre,
                    imdbID = Movie.imdbID,
                    imdbVotes = Movie.imdbVotes,
                    imdbRating = Movie.imdbRating,
                    Language = Movie.Language,
                    LikeCount = 0,
                    ViewCount = 1,
                    Metascore = Movie.Metascore,
                    Plot = Movie.Plot,
                    Poster = Movie.Poster,
                    Production = Movie.Production,
                    Rated = Movie.Rated,
                    Released = Movie.Released,
                    Response = Movie.Response,
                    Runtime = Movie.Runtime,
                    Year = Movie.Year,
                    Writer = Movie.Writer,
                    Website = Movie.Website,
                    Type = Movie.Type,
                    Title = Movie.Title
                };
                DbContext.Movies.Add(movie);
                DbContext.SaveChanges();

                ReelJet.Database.Entities.Concretes.UserHistoryList historyList = new() {
                    UserId = CurrentUser.Id,
                    MovieId = movie.Id,
                };

                foreach (var rating in Movie.Ratings)
                    DbContext.Ratings.Add(new() {
                        Source = rating.Source,
                        Value = rating.Value,
                        MovieId = movie.Id
                    });

                DbContext.HistoryLists.Add(historyList);

                DbContext.SaveChanges();

                MovieAdapter = movie;
            }

            MainFrame.Content = new VideoPlayerPage(MainFrame, MovieAdapter);
        }

        // INotifyPropertyChanged

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string? propertyName = null) { 
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}