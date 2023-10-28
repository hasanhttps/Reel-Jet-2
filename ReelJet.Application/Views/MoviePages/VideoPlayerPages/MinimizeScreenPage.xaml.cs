using System;
using System.Windows.Controls;
using ReelJet.Database.Entities;
using System.Collections.ObjectModel;
using Reel_Jet.ViewModels.MoviePageModels.VideoPlayerPageModels;

namespace Reel_Jet.Views.MoviePages.VideoPlayerPages {
    public partial class MinimizeScreenPage : Page {
        public MinimizeScreenPage(Frame frame, Movie movie, ObservableCollection<Reel_Jet.Models.MovieNamespace.Option> options, string videoUrl, string videoPgUrl) {

            InitializeComponent();

            FullScreenPage fullScreenPage = new FullScreenPage(frame, movie, videoUrl);
            PlayerFrame.Content = fullScreenPage;

            DataContext = new MinimizeScreenPageModel(frame, movie, (fullScreenPage.DataContext as FullScreenPageModel)!.getPlayer(), 
                PlayerFrame, options, videoUrl, videoPgUrl);
        }
    }
}
