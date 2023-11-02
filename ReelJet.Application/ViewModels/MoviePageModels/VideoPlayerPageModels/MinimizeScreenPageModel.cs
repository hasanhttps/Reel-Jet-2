using System;
using System.Linq;
using System.Net.Http;
using HtmlAgilityPack;
using Reel_Jet.Commands;
using System.Windows.Input;
using System.ComponentModel;
using System.Windows.Controls;
using Reel_Jet.Views.MoviePages;
using ReelJet.Database.Entities;
using Microsoft.Web.WebView2.Wpf;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using Reel_Jet.Views.NavigationBarPages;
using ReelJet.Database.Entities.Concretes;
using Reel_Jet.Views.MoviePages.VideoPlayerPages;
using static ReelJet.Application.Models.DatabaseNamespace.Database;

#nullable disable

namespace Reel_Jet.ViewModels.MoviePageModels.VideoPlayerPageModels {
    public class MinimizeScreenPageModel : INotifyPropertyChanged {

         // Private Fields

        private Movie Movie;
        private WebView2 Player;
        private Frame MainFrame;
        private string _videoUrl;
        private string newcomment;
        private string _videoPgUrl;

        // Binding Properties

        public ObservableCollection<Comment> Comments { get; set; }

        public string NewComment { get => newcomment;
            set {
                newcomment = value;
                OnPropertyChanged();
            }
        }

        public Frame PlayerFrame { get; set; }
        public RelayCommand SendCommentCommand { get; set; }
        public ICommand WatchListPgButtonCommand { get; set; }
        public ICommand FullScreenButtonCommand { get; set; }
        public ICommand SelectionChangedCommand { get; set; }
        public ICommand SettingsPgButtonCommand { get; set; }
        public ICommand HistoryPgButtonCommand { get; set; }
        public ICommand ProfilePgButtonCommand { get; set; }
        public ICommand MovieListPageCommand { get; set; }
        public ObservableCollection<Reel_Jet.Models.MovieNamespace.Option> Options { get; set; }
        public string VideoUrl {
            get => _videoUrl;
            set {
                _videoUrl = value;
            } 
        }

        // Constructor

        public MinimizeScreenPageModel() {

            SelectionChangedCommand = new RelayCommand(SelectionChanged);
            FullScreenButtonCommand = new RelayCommand(FullScreenPage);
            WatchListPgButtonCommand = new RelayCommand(WatchListPage);
            SettingsPgButtonCommand = new RelayCommand(SettingsPage);
            HistoryPgButtonCommand = new RelayCommand(HistoryPage);
            MovieListPageCommand = new RelayCommand(MovieListPage);
            ProfilePgButtonCommand = new RelayCommand(ProfilePage);
            SendCommentCommand= new RelayCommand(SendComment);

            Comments = new();
        }

        public MinimizeScreenPageModel(Frame frame, Movie movie, WebView2 player, 
            Frame playerframe, ObservableCollection<Reel_Jet.Models.MovieNamespace.Option> options, string videoUrl, string videoPgLink)
            : this() {

            MainFrame = frame;
            Movie = movie;
            Player = player;
            Options = options;
            VideoUrl = videoUrl;
            PlayerFrame = playerframe;
            _videoPgUrl = videoPgLink;

            Uri uri = new Uri(VideoUrl!);
            Player.Source = uri;

            WriteComments();
            
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

        private void ProfilePage(object? sender) {
            MainFrame.Content = new UserAccountPage(MainFrame);
        }

        private void SettingsPage(object? sender) { 
            MainFrame.Content = new SettingsPage(MainFrame);
        }

        private void FullScreenPage(object? sender) {
            VideoPlayerPageModel videoPlayerPageModel = ((MainFrame.Content as VideoPlayerPage).DataContext as VideoPlayerPageModel);

            Frame videoPlayerFrame = videoPlayerPageModel.VideoPlayerFrame;
            videoPlayerPageModel.PrevFrame = videoPlayerFrame.Content;
            videoPlayerPageModel.fullScreenPage = PlayerFrame.Content as FullScreenPage;

            videoPlayerFrame.Navigate(PlayerFrame.Content);
        }

        private void SelectionChanged(object? sender) {
            string option = (sender as Reel_Jet.Models.MovieNamespace.Option)!.option;
            if (option != null) {
                int count = 0;
                foreach(var op in Options!) {
                    count++;
                    if (op.option == option) break;
                }

                try {
                    FindEmbedVideoLink(_videoPgUrl + count.ToString() + "/");
                    Uri uri = new Uri(VideoUrl!);
                    Player.Source = uri;
                }
                catch (Exception e) {
                    if (e.Message == "Trailer Link" && option.ToLower() == "fragman") {
                        Uri uri = new Uri(VideoUrl!);
                        Player.Source = uri;
                    }
                }
            }
        }

        private void FindEmbedVideoLink(string? VideoPageLink) {

            var httpClient = new HttpClient();
            var htmlDocument = new HtmlDocument();
            var html = httpClient.GetStringAsync(VideoPageLink).Result;
            htmlDocument.LoadHtml(html);

            Options = new();
            var linkContainer = htmlDocument.DocumentNode.SelectSingleNode("//iframe[@src]");
            var optionNodes = htmlDocument.DocumentNode.SelectNodes("//div[@class='keremiya_part']//span");

            foreach(var optionNode in optionNodes) {
                Reel_Jet.Models.MovieNamespace.Option option = new();
                option.option = optionNode.InnerText;
                Options.Add(option);
            }

            HtmlAttribute scrapingLink = linkContainer.Attributes["src"];

            if (scrapingLink.Value.Substring(0, 5) == "https") VideoUrl = scrapingLink.Value;
            else VideoUrl = "https:" + scrapingLink.Value;

            if (VideoUrl.Contains("youtube.com"))
                throw new Exception("Trailer Link");
        }

        private void SendComment(object? param) {
            if (!string.IsNullOrEmpty(NewComment)) {
                Comment comment = new Comment { Content = NewComment, PostedTime = DateTime.Now, LikeCount = 0, UserId = CurrentUser.Id };

                Comments.Add(comment);
                DbContext.Comments.Add(comment);
                DbContext.SaveChanges();

                CommentsMovies commentsMovies = new CommentsMovies() { CommentId = comment.Id, MovieId = Movie.Id };
                DbContext.CommentsMovies.Add(commentsMovies);
                DbContext.SaveChanges();

                NewComment = string.Empty;

            }
        }

        private void WriteComments() {

            if (Movie != null) {

                var comments = DbContext.CommentsMovies
                    .Where(p => p.MovieId == Movie.Id)
                    .Select(p => p.Comment)
                    .ToList();

                foreach (var comment in comments) {
                    Comments.Add(comment);
                }
            }
        }
        // INotifyPropertyChanged

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string? propertyName = null) { 
            PropertyChanged!.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
