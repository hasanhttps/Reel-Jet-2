using System;
using System.IO;
using System.Windows;
using Microsoft.Win32;
using Reel_Jet.Commands;
using System.Windows.Input;
using System.ComponentModel;
using System.Windows.Controls;
using Reel_Jet.Views.MoviePages;
using System.Windows.Media.Imaging;
using System.Runtime.CompilerServices;
using Reel_Jet.Views.NavigationBarPages;
using ReelJet.Database.Entities.Concretes;
using ReelJet.Application.Models.DatabaseNamespace;
using static ReelJet.Application.Models.DatabaseNamespace.Database;

namespace Reel_Jet.ViewModels.NavigationBarPageModels {

    public class UserAccountPageModel : INotifyPropertyChanged {

        // Private Fields

        private Frame MainFrame;
        private BitmapImage _avatar;
        
        // Binding Properties
        
        public BitmapImage Avatar { get => _avatar;
            set { 
                _avatar = value; OnProperty();
            } 
        }
        public User EditedUser { get; set; } = new();
        public ICommand WatchListPgButtonCommand { get; set; }
        public ICommand SettingsPgButtonCommand { get; set; }
        public ICommand ConfirmChangeCommand { get; set; }
        public ICommand MoviePgButtonCommand { get; set; }
        public ICommand HistoryPgCommand { get; set; }
        public ICommand EditPfpCommand { get; set; }


        // Constructor


        public UserAccountPageModel(Frame frame) {
            MainFrame = frame;

            setUser();

            WatchListPgButtonCommand = new RelayCommand(WatchListPage);
            SettingsPgButtonCommand = new RelayCommand(SettingsPage);
            MoviePgButtonCommand = new RelayCommand(MovieListPage);
            ConfirmChangeCommand = new RelayCommand(ConfirmChange);
            HistoryPgCommand = new RelayCommand(HistoryPage);
            EditPfpCommand = new RelayCommand(EditPfp);

            Avatar = userAuthentication.Avatar;
        }

        // Functions


        private void setUser() {

            EditedUser.Avatar = Database.CurrentUser.Avatar;
            EditedUser.Name = Database.CurrentUser.Name;
            EditedUser.Surname = Database.CurrentUser.Surname;
            EditedUser.Age = Database.CurrentUser.Age;
            EditedUser.Username = Database.CurrentUser.Username;
            EditedUser.PhoneNumber = Database.CurrentUser.PhoneNumber;
            EditedUser.Email = Database.CurrentUser.Email;
            EditedUser.Password = Database.CurrentUser.Password;
        }

        private void ConfirmChange(object? sender) {

            if (string.IsNullOrEmpty(EditedUser.Name) 
                || string.IsNullOrEmpty(EditedUser.Surname)
                || string.IsNullOrEmpty(EditedUser.Username) 
                || string.IsNullOrEmpty(EditedUser.PhoneNumber) 
                || string.IsNullOrEmpty(EditedUser.Password)) 
                
                MessageBox.Show("Fill all the required fields,Try Again", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);

            else {

                CurrentUser.Avatar      = EditedUser.Avatar      ;
                CurrentUser.Name        = EditedUser.Name        ;
                CurrentUser.Surname     = EditedUser.Surname     ;
                CurrentUser.Age         = EditedUser.Age         ;
                CurrentUser.Username    = EditedUser.Username    ;
                CurrentUser.PhoneNumber = EditedUser.PhoneNumber ;
                CurrentUser.Password    = EditedUser.Password    ;

                Database.DbContext.SaveChanges();
                userAuthentication.Avatar = UserAuthentication.LoadImage(CurrentUser.Avatar!);
                Avatar = userAuthentication.Avatar;
            }
        }

        private void EditPfp(object? obj) {

            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Image Files (*.jpg, *.jpeg, *.png, *.gif, *.bmp)|*.jpg;*.jpeg;*.png;*.gif;*.bmp|All files (*.*)|*.*";

            if (fileDialog.ShowDialog() == true) {
                using (FileStream fs = new FileStream(fileDialog.FileName, FileMode.Open, FileAccess.Read)) {
                    using (BinaryReader br = new BinaryReader(fs)) {
                        EditedUser.Avatar = br.ReadBytes((int)fs.Length);
                        Avatar = UserAuthentication.LoadImage(EditedUser.Avatar!);
                    }
                }
            }
        }

        private void MovieListPage(object? sender) {
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

        // INotifyPropertyChanged

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnProperty([CallerMemberName] string? name = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}