using System.Windows;
using Reel_Jet.Commands;
using System.Windows.Input;
using System.Windows.Controls;
using Reel_Jet.Views.MoviePages;
using ReelJet.Database.Entities.Concretes;
using ReelJet.Application.Models.DatabaseNamespace;
using static ReelJet.Application.Models.DatabaseNamespace.Database;

namespace Reel_Jet.ViewModels.RegistrationPageModels {
    public class LoginPageModel {

        // Private Fields

        private Frame MainFrame;

        // Binding Properties

        public User NewUser { get; set; } = new();
        public ICommand? SignInCommand { get; set; }

        // Constructor

        public LoginPageModel(Frame frame) {

            MainFrame = frame;
            SignInCommand = new RelayCommand(SignIn);
        }

        // Functions

        private void SignIn(object? param) {
            UserAuthentication authentication = new();

            if (!string.IsNullOrEmpty(NewUser.Email) && !string.IsNullOrEmpty(NewUser.Password))
                if (authentication.LogIn(NewUser)) {
                    userAuthentication.Avatar = UserAuthentication.LoadImage(CurrentUser.Avatar);
                    MainFrame.Content = new MovieListPage(MainFrame);
                }
                else
                    MessageBox.Show("This account doesn't exist!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            else
                MessageBox.Show("Fill all the required fields", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

    }
}
