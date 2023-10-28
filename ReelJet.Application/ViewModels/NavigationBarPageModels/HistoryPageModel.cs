﻿using System;
using System.Linq;
using System.Windows;
using Reel_Jet.Commands;
using System.Windows.Input;
using System.Windows.Controls;
using Reel_Jet.Views.MoviePages;
using ReelJet.Database.Entities;
using System.Collections.ObjectModel;
using Reel_Jet.Views.NavigationBarPages;
using static ReelJet.Application.Models.DatabaseNamespace.Database;

namespace Reel_Jet.ViewModels.NavigationBarPageModels {
    public class HistoryPageModel {

        // Private Fields

        private Frame MainFrame;

        // Binding Properties

        public ObservableCollection<Movie> HistoryList { get; set; } = new();
        public ICommand? WatchListPgButtonCommand { get; set; }
        public ICommand? SelectionChangedCommand { get; set; }
        public ICommand? SettingsPgButtonCommand { get; set; }
        public ICommand? ProfilePgButtonCommand { get; set; }
        public ICommand? MoviePgButtonCommand { get; set; }

        // Constructor

        public HistoryPageModel(Frame frame) {

            if (CurrentUser.HistoryList != null) {
                foreach (var movie in CurrentUser.HistoryList) {
                    HistoryList.Add(movie.Movie);
                }
            }

            MainFrame = frame;

            SelectionChangedCommand = new RelayCommand(SelectionChanged);
            WatchListPgButtonCommand = new RelayCommand(WatchListPage);
            SettingsPgButtonCommand = new RelayCommand(SettingsPage);
            ProfilePgButtonCommand = new RelayCommand(ProfilePage);
            MoviePgButtonCommand = new RelayCommand(MovieListPage);
        }

        // Functions

        private void SelectionChanged(object? param) {
            Movie movie = (Movie)param!;
            MainFrame.Content = new VideoPlayerPage(MainFrame, movie);
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
    }
}
