using System;
using System.Windows;
using Reel_Jet.Commands;
using System.Windows.Controls;
using ReelJet.Database.Entities.Concretes;
using Reel_Jet.Views.RegistrationPages.SignUpPages;

namespace ReelJet.Application.ViewModels.RegistrationPageModels;

public class ForgotPasswordPageModel {

    // Private Fields

    private Frame MainFrame;

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
        if (!string.IsNullOrEmpty(CurrentUser.Email) && !string.IsNullOrEmpty(CurrentUser.Password))
            MainFrame.Content = new ValidationPage(MainFrame, CurrentUser);
        else
            MessageBox.Show("Please Fill All Blanks!", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
    }

}
