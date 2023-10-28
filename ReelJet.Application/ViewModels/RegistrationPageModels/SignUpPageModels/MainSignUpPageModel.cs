using System;
using System.Windows;
using Reel_Jet.Commands;
using System.Windows.Input;
using System.ComponentModel;
using System.Windows.Controls;
using System.Runtime.CompilerServices;
using Reel_Jet.Models.DatabaseNamespace;
using Reel_Jet.Views.RegistrationPages;
using Reel_Jet.Views.RegistrationPages.SignUpPages;

#nullable disable

namespace Reel_Jet.ViewModels.RegistrationPageModels.SignUpPageModels {
    public class MainSignupPageModel {
        private Frame MainFrame;

        public MainSignupPageModel(Frame frame, Frame frame2) {
            MainFrame = frame;
            frame2.Content = new RegistrationPage(MainFrame, frame2);
        }
    }
}