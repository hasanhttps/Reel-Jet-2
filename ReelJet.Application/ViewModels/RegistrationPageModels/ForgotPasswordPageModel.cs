using System;
using System.Windows;
using Reel_Jet.Commands;
using System.Windows.Controls;
using ReelJet.Database.Entities.Concretes;
using Reel_Jet.Views.RegistrationPages.SignUpPages;
using static ReelJet.Application.Models.DatabaseNamespace.Database;

namespace ReelJet.Application.ViewModels.RegistrationPageModels;

public class ForgotPasswordPageModel {

    // Private Fields

    private Frame MainFrame;
    private Frame RegistrationFrame;

    // Binding Properties

    public User CurrentUser { get; set; } = new();
    public RelayCommand RequestPasswordCommand { get; set; }
    
    // Constructor

    public ForgotPasswordPageModel(Frame frame) {

        MainFrame = frame;

        RequestPasswordCommand = new RelayCommand(RequestPassword);
    }

    // Functions

    public void RequestPassword(object? param) {

        bool isContain = false;

        foreach(var user in DbContext.Users)
            if (user.Email == CurrentUser.Email)
                isContain = true;
        if (!isContain) MessageBox.Show($"In database there is no user with email {CurrentUser.Email}.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

        if (!string.IsNullOrEmpty(CurrentUser.Email) && !string.IsNullOrEmpty(CurrentUser.Password) && isContain) {

            MainFrame.Content = new MainSignUpPage(MainFrame, CurrentUser, "Password Recover");
        }
        else
            MessageBox.Show("Please Fill All Blanks!", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
    }

}
