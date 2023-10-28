using System;
using System.Windows.Controls;
using ReelJet.Database.Entities;
using Reel_Jet.ViewModels.MoviePageModels;

namespace Reel_Jet.Views.MoviePages {

    public partial class VideoPlayerPage : Page {
        public VideoPlayerPage(Frame frame, Movie movie) {
            InitializeComponent();
            DataContext = new VideoPlayerPageModel(frame, movie, Player);
        }
    }
}
