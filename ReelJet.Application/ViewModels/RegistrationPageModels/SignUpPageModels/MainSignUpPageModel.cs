using System;
using System.Windows.Controls;
using ReelJet.Database.Entities.Concretes;
using Reel_Jet.Views.RegistrationPages.SignUpPages;

#nullable disable

namespace Reel_Jet.ViewModels.RegistrationPageModels.SignUpPageModels {
    public class MainSignupPageModel {
        private Frame MainFrame;

        public MainSignupPageModel(Frame frame, Frame frame2, User? currentUser, string process) {

            MainFrame = frame;
            if (process == "Registration") frame2.Content = new RegistrationPage(MainFrame, frame2);
            else if (process == "Password Recover") frame2.Content = new ValidationPage(MainFrame, currentUser, "Password Recover");
        }
    }
}