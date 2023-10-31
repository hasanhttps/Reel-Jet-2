using System;
using Reel_Jet.Commands;
using System.Windows.Input;
using System.Windows.Controls;
using ReelJet.Database.Entities;
using Reel_Jet.Views.MoviePages;
using Microsoft.Web.WebView2.Wpf;
using Reel_Jet.Views.MoviePages.VideoPlayerPages;

namespace Reel_Jet.ViewModels.MoviePageModels.VideoPlayerPageModels {
    public class FullScreenPageModel {

        // Private Fields

        private Frame MainFrame;
        private Movie Movie;
        private WebView2 Player;

        // Binding Properties

        public ICommand MinimizeScreenButtonCommand { get; set; }
        public string VideoUrl { get; set; }

        // Constructor

        public FullScreenPageModel(Frame frame, Movie movie, WebView2 player, string videourl) {
            VideoUrl = videourl;
            MainFrame = frame;
            Movie = movie;
            Player = player;

            MinimizeScreenButtonCommand = new RelayCommand(MinimizePage);
        }

        // Functions


        private void MinimizePage(object? sender) {

            Frame videoPlayerFrame = ((MainFrame.Content as VideoPlayerPage)!.DataContext as VideoPlayerPageModel)!.VideoPlayerFrame;
            Uri uri = new Uri("https://www.google.com/");
            Player.Source = uri;

            MinimizeScreenPage minimizeScreen = (((MainFrame.Content as VideoPlayerPage)!.DataContext as VideoPlayerPageModel)!.PrevFrame as MinimizeScreenPage)!;
            videoPlayerFrame.NavigationService.Navigate(minimizeScreen);

            minimizeScreen.PlayerFrame.Content = new FullScreenPage(MainFrame, Movie, VideoUrl);
        }

        public WebView2 getPlayer() {
            return Player;
        }
    }
}
