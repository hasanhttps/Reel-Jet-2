﻿using System;
using RestSharp;
using System.Linq;
using System.Threading;
using System.Text.Json;
using Castle.Core.Internal;
using System.Windows.Controls;
using System.Windows.Threading;
using ReelJet.Database.Contexts;
using Reel_Jet.Models.MovieNamespace;
using Reel_Jet.Views.RegistrationPages;
using static Reel_Jet.Services.WebServices.OmdbService;
using static ReelJet.Application.Models.DatabaseNamespace.Database;


namespace Reel_Jet.ViewModels.RegistrationPageModels {
    public class LoadingPageModel {

        // Private Fields

        private Frame MainFrame;

        // Constructor

        public LoadingPageModel(Frame frame) { 

            MainFrame = frame;

            Thread thread = new Thread(() => {
                DbContext = new ReelJetDbContext();
                var users = DbContext.Users.ToList();
                Users = users;
            });
            thread.Start();

            Thread thread2 = new Thread(Popular);
            thread2.Start();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(6.25);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        // Functions

        private void Timer_Tick(object? sender, EventArgs e) {
            // Stop the timer
            
            ((DispatcherTimer)sender!).Stop();
            MainFrame.Content = new LoginPage(MainFrame);
        }

        private async void Popular() {

            var options = new RestClientOptions("https://api.themoviedb.org/3/movie/popular?language=en-US&page=1");
            var client = new RestClient(options);
            var request = new RestRequest("");
            request.AddHeader("accept", "application/json");
            request.AddHeader("Authorization", "Bearer eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiIwN2I3OWYxNmU2NWFmMGY1YTBjNGY4ZGFkZDdkMDhjNCIsInN1YiI6IjY0YjA0MzFjMjBlY2FmMDBjNmY2MWQ1ZSIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.VErhjbegJJ2tyZVP-GiDRN_gTcH_MYVhQ1wThi0Ytb0");
            var response = await client.GetAsync(request);
            PopularMovies popularMovies = JsonSerializer.Deserialize<PopularMovies>(response.Content!)!;

            for(int i = 0; i < popularMovies.results.Count; i++)  {
                var jsonStr = await GetConcreteMovieByTitle(popularMovies.results[i].title);
                Movie movie = JsonSerializer.Deserialize<Movie>(jsonStr)!;
                movie.Year = popularMovies.results[i].release_date.Substring(0, 4);

                if (!movie.Title.IsNullOrEmpty()) Movies.Add(movie);
            }
        }

    }
}