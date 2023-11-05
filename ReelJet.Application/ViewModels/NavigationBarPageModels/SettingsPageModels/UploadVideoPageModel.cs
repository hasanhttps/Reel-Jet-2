using System;
using System.Linq;
using Reel_Jet.Commands;
using System.Windows.Input;
using ReelJet.Database.Entities.Concretes;
using static ReelJet.Application.Models.DatabaseNamespace.Database;
using Microsoft.Win32;
using System.IO;
using System.Windows;

namespace ReelJet.Application.ViewModels.NavigationBarPageModels.SettingsPageModels;

public class UploadVideoPageModel {

    // Binding Properties

    public string Hour { get; set; }
    public string Title { get; set; }
    public string Minute { get; set; }
    public byte[] Poster { get; set; }
    public string MovieLink { get; set; }
    public string Description { get; set; }
    public ICommand? UploadVideoCommand { get; set; }
    public ICommand? UploadPosterCommand { get; set; }

    // Constructor

    public UploadVideoPageModel() {
        SetCommands();
    }

    // Functions

    private void SetCommands() {
        UploadVideoCommand = new RelayCommand(UploadVideo);
        UploadPosterCommand = new RelayCommand(UploadPoster);
    }

    private void UploadVideo(object? param) {

        PersonalMovie personalMovie = new() {

            UserId = CurrentUser.Id,
            MovieLink = MovieLink,
            Description = Description,
            Hour = Hour,
            Poster = Poster,
            Minute = Minute,
            Title = Title,
            UploadDate = DateTime.Now,
            LikeCount = 0,
            ViewCount = 0
        };
        DbContext.PersonalMovies.Add(personalMovie);
        DbContext.SaveChanges();
    }

    private void UploadPoster(object? param) {

        OpenFileDialog fileDialog = new OpenFileDialog();
        fileDialog.Filter = "Image Files (*.jpg, *.jpeg, *.png, *.gif, *.bmp)|*.jpg;*.jpeg;*.png;*.gif;*.bmp|All files (*.*)|*.*";

        if (fileDialog.ShowDialog() == true) {
            try {
                using (FileStream fs = new FileStream(fileDialog.FileName, FileMode.Open, FileAccess.Read)) {
                    using (BinaryReader br = new BinaryReader(fs)) {
                        Poster = br.ReadBytes((int)fs.Length);
                    }
                }
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}