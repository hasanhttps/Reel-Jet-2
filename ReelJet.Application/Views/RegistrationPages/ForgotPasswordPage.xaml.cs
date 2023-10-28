using System;
using System.Windows.Controls;
using ReelJet.Application.ViewModels.RegistrationPageModels;

namespace ReelJet.Application.Views.RegistrationPages;

public partial class ForgotPasswordPage : Page {
    public ForgotPasswordPage(Frame frame) {
        InitializeComponent();
        DataContext = new ForgotPasswordPageModel(frame);

    }
}