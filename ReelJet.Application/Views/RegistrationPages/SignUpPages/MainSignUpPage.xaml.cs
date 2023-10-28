using System;
using System.Windows.Controls;
using Reel_Jet.ViewModels.RegistrationPageModels.SignUpPageModels;

namespace Reel_Jet.Views.RegistrationPages.SignUpPages {
    public partial class MainSignUpPage : Page {

        // Private Fields

        private Frame MainFrame;

        // Constructor

        public MainSignUpPage(Frame frame) {
            InitializeComponent();
            MainFrame = frame;
            DataContext = new MainSignupPageModel(MainFrame, Frame2);
        }
    }
}
