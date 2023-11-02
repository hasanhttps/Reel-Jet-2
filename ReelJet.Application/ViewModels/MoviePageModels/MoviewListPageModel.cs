using System;
using RestSharp;
using System.Windows;
using System.Threading;
using System.Text.Json;
using Reel_Jet.Commands;
using System.Windows.Input;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Threading;
using Reel_Jet.Views.MoviePages;
using Microsoft.Identity.Client;
using Reel_Jet.Services.WebServices;
using System.Collections.ObjectModel;
using Reel_Jet.Models.MovieNamespace;
using System.Runtime.CompilerServices;
using Reel_Jet.Views.NavigationBarPages;
using ReelJet.Application.Models.DatabaseNamespace;
using static Reel_Jet.Services.WebServices.OmdbService;
using static ReelJet.Application.Models.DatabaseNamespace.Database;


namespace Reel_Jet.ViewModels.MoviePageModels {
    public class MoviewListPageModel : INotifyPropertyChanged {

        // Private Fields

        private Frame MainFrame;
        private MovieCollection _movie;
        private string _selectedfilter;

        // Binding Properties

        public ICommand? WatchTrailerFromListCommand { get; set; }
        public ICommand? WatchListPgButtonCommand { get; set; }
        public ICommand? SelectionChangedCommand { get; set; }
        public ICommand? FilterSelectionChangedCommand { get; set; }
        public ICommand? SettingsPgButtonCommand { get; set; }
        public ICommand? HistoryPgButtonCommand { get; set; }
        public ICommand? ProfilePgButtonCommand { get; set; }
        public ICommand? AddToWatchListCommand { get; set; }
        public ICommand? SearchCommand { get; set; }
        public MovieCollection Movie {
            get => _movie;
            set {
                _movie = value;
                OnPropertyChanged();
            }
        }

        public string SelectedFilter
        {
            get => _selectedfilter;
            set
            {
                _selectedfilter = value;
                OnPropertyChanged();
            }
        }


        public ObservableCollection<Movie> Movies { get; set; }

        // Constructor

        public MoviewListPageModel(Frame frame) { 

            MainFrame = frame;

            WatchTrailerFromListCommand = new RelayCommand(SelectionChanged);
            FilterSelectionChangedCommand=new RelayCommand(FilterSelectionChanged);
            SelectionChangedCommand = new RelayCommand(SelectionChanged);
            WatchListPgButtonCommand = new RelayCommand(WatchListPage);
            AddToWatchListCommand = new RelayCommand(AddToWatchList);
            SettingsPgButtonCommand = new RelayCommand(SettingsPage);
            HistoryPgButtonCommand = new RelayCommand(HistoryPage);
            ProfilePgButtonCommand = new RelayCommand(ProfilePage);
            SearchCommand = new RelayCommand(Search);

            this.Movies = Database.Movies;

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(6.25);
            timer.Tick += Timer_Tick;
            timer.Start();


        }

        // Functions

        private void HistoryPage(object? sender) {
            MainFrame.Content = new HistoryPage(MainFrame);
        }
        private void WatchListPage(object? sender) {
            MainFrame.Content = new WatchListPage(MainFrame);
        }
        private void ProfilePage(object? sender) {
            MainFrame.Content = new UserAccountPage(MainFrame);
        }
        private void SettingsPage(object? sender) {
            MainFrame.Content = new SettingsPage(MainFrame);
        }
        private async void TaskToJson(string title) {

            var jsonStr = await OmdbService.GetAllMoviesByTitle(title);
            Movie = JsonSerializer.Deserialize<MovieCollection>(jsonStr)!;

            if (Movie.Search is not null) {
                if (Movies != null) Movies.Clear();

                foreach (var result in Movie.Search) {

                    var movieCollectionJson = await OmdbService.GetConcreteMovieById(result.imdbID);
                    var movieFromCollection = JsonSerializer.Deserialize<Movie>(movieCollectionJson);

                    if (movieFromCollection!.Poster == "N/A")
                        movieFromCollection.Poster = "\\Static Files\\Images\\no-poster.png";

                    if (movieFromCollection is not null)
                        Movies.Add(movieFromCollection);
                }
                return;
            }
        }

        private void AddToWatchList(object? sender) {
            
            Movie Movie = (sender as Movie)!;
            bool isContain = false;

            ReelJet.Database.Entities.Movie MovieEntity = new() {
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
                Title = Movie.Title,

            };

            if (CurrentUser.WatchList != null)
                foreach (var movie in CurrentUser.WatchList) {
                    if (movie.Movie.Title == MovieEntity.Title && movie.Movie.imdbID == MovieEntity.imdbID)
                        isContain = true;
                }

            if (!isContain) {

                DbContext.Movies.Add(MovieEntity);
                DbContext.SaveChanges();

                ReelJet.Database.Entities.Concretes.UserWatchList WatchList = new() {
                    UserId = CurrentUser.Id,
                    MovieId = MovieEntity.Id,
                };

                foreach (var rating in Movie.Ratings)
                    DbContext.Ratings.Add(new() {
                        Source = rating.Source,
                        Value = rating.Value,
                        MovieId = MovieEntity.Id
                    });

                DbContext.WatchLists.Add(WatchList);
                DbContext.SaveChanges();
            }
        }

        private void SelectionChanged(object? param) {

            Movie movie = (param as Movie)!;
            if (movie != null)
                MainFrame.Content = new MoviePreviewPage(MainFrame, movie);
        }

        private void Search(object? param) {

            string text = (param as string)!;
            MessageBox.Show(text);
            TaskToJson(text);
        }


        private void FilterSelectionChanged(object? param) {

            Movies.Clear();
            string selectedfilter = (param as ComboBoxItem).Content.ToString();
            selectedfilter=selectedfilter.Replace(" ", "_");
            var FilterThread = new Thread(() => ApplyFilter(selectedfilter.ToLower()));
            FilterThread.Start();
            
        }

        private async void ApplyFilter(string filterchoice) {

            var options = new RestClientOptions($"https://api.themoviedb.org/3/movie/{filterchoice}?language=en-US&page=1");
            var client = new RestClient(options);
            var request = new RestRequest("");
            request.AddHeader("accept", "application/json");
            request.AddHeader("Authorization", "Bearer eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiIwN2I3OWYxNmU2NWFmMGY1YTBjNGY4ZGFkZDdkMDhjNCIsInN1YiI6IjY0YjA0MzFjMjBlY2FmMDBjNmY2MWQ1ZSIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.VErhjbegJJ2tyZVP-GiDRN_gTcH_MYVhQ1wThi0Ytb0");
            var response = await client.GetAsync(request);
            PopularMovies popularMovies = JsonSerializer.Deserialize<PopularMovies>(response.Content!)!;

            await Application.Current.Dispatcher.Invoke(async() => {
                for (int i = 0; i < popularMovies.results.Count; i++) {
                    var jsonStr = await GetConcreteMovieByTitle(popularMovies.results[i].title);
                    Movie movie = JsonSerializer.Deserialize<Movie>(jsonStr)!;
                    movie.Year = popularMovies.results[i].release_date.Substring(0, 4);

                    if (!string.IsNullOrEmpty(movie.Title)) {
                        Movies.Add(movie);
                    }
                }
            });

        }


        private void Timer_Tick(object? sender, EventArgs e) {
            // Stop the timer
            ((DispatcherTimer)sender!).Stop();
        }

        // INotifyPropertyChanged

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string? propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}