using System;
using System.Windows;
using System.Net.Http;
using HtmlAgilityPack;
using System.ComponentModel;
using System.Windows.Controls;
using ReelJet.Database.Entities;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using Reel_Jet.Views.MoviePages.VideoPlayerPages;

#nullable disable

namespace Reel_Jet.ViewModels.MoviePageModels {
    class VideoPlayerPageModel : INotifyPropertyChanged {

        // Private Fields

        private Movie Movie;
        private Frame MainFrame;
        private string _videoPgUrl;
        private string _videoUrl;
        private string _search;

        // Binding Properties


        public object PrevFrame;
        public Frame VideoPlayerFrame;
        public FullScreenPage fullScreenPage;

        public ObservableCollection<Reel_Jet.Models.MovieNamespace.Option> Options { get; set; }
        public string VideoUrl {
            get => _videoUrl;
            set {
                _videoUrl = value;
            } 
        }

        // Constructor

        public VideoPlayerPageModel(Frame frame, Movie movie, Frame videoplayerframe) {
            VideoPlayerFrame = videoplayerframe;
            MainFrame = frame;
            Movie = movie;

            SearchAlgorithm(movie.Title);
            if (!CheckMovieExist()) {

                videoplayerframe.Content = MainFrame.Content;
                MessageBox.Show("Movie video don't exist!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else VideoPlayerFrame.Content = new MinimizeScreenPage(frame, movie, Options, VideoUrl, _videoPgUrl);
        }

        // Functions

        private bool CheckMovieExist() {
            if (ScrapeDiziBox()) return true;
            else if (ScrapeFullFilmIzleNet()) return true;
            else if (ScrapeFullHdIzle()) return true;
            return false;
        }

        private void SearchAlgorithm(string title) {
            _search = title.ToLower();
            _search = _search.Replace(" ", "+");
            _search = _search.Replace("ı", "i");
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
                Reel_Jet.Models.MovieNamespace.Option option = new Reel_Jet.Models.MovieNamespace.Option();
                option.option = optionNode.InnerText;
                Options.Add(option);
            }

            HtmlAttribute scrapingLink = linkContainer.Attributes["src"];

            if (scrapingLink.Value.Substring(0, 5) == "https") VideoUrl = scrapingLink.Value;
            else VideoUrl = "https:" + scrapingLink.Value;

            if (VideoUrl.Contains("youtube.com"))
                throw new Exception("Trailer Link");
        }

        private string? FindVideoLink(string searchlink) {

            string url = searchlink + _search;
            var httpClient = new HttpClient();
            var html = httpClient.GetStringAsync(url).Result;
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            HtmlAttribute? scr = null;
            HtmlNodeCollection movieDetailNodes = htmlDocument.DocumentNode.SelectNodes("//div[@class='movie-details existing-details']");

            foreach (var node in movieDetailNodes) {
                try {
                    if (node.InnerText.Contains(Movie.Year)) {
                        var doc = new HtmlDocument();
                        doc.LoadHtml(node.InnerHtml);

                        var nameDiv = doc.DocumentNode.SelectSingleNode("//div[@class='name']");
                        var anchorElement = nameDiv.SelectSingleNode("a");
                        scr = anchorElement.Attributes["href"];
                        break;
                    }   
                }
                catch { }
            }
            return scr!.Value;
        }


        // Scraping


        // DiziBox

        private bool ScrapeDiziBox() {
            try {
                string? VideoPageLink = FindVideoLink("https://www.dizifilmbox.pw/?s=");
                FindEmbedVideoLink(VideoPageLink);
                _videoPgUrl = VideoPageLink;
                return true;
            }
            catch {
                return false;
            }
        }

        // FullFilmIzle.net

        private bool ScrapeFullFilmIzleNet() {
            try {
                string? VideoPageLink = FindVideoLink("https://fullfilmizle.net/?s=");
                FindEmbedVideoLink(VideoPageLink);
                _videoPgUrl = VideoPageLink;
                return true;
            }
            catch {
                return false;
            }
        }

        // FullHdIzle.me

        private bool ScrapeFullHdIzle() {
            try {
                string? VideoPageLink = FindVideoLink("https://www.fullhdizle.me/?s=");
                FindEmbedVideoLink(VideoPageLink);
                _videoPgUrl = VideoPageLink;
                return true;
            }
            catch {
                return false;
            }
        }


        // INotifyPropertyChanged

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string? propertyName = null) { 
            PropertyChanged!.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}