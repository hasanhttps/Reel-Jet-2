using System;
using System.Windows;
using System.Threading;
using Reel_Jet.Commands;
using System.Windows.Input;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Threading;
using Reel_Jet.Views.MoviePages;
using Reel_Jet.Services.WebServices;
using System.Runtime.CompilerServices;
using Reel_Jet.Models.DatabaseNamespace;
using ReelJet.Database.Entities.Concretes;
using Reel_Jet.Views.RegistrationPages.SignUpPages;
using static Reel_Jet.Services.WebServices.SmtpService;
using ReelJet.Application.Models.DatabaseNamespace;

namespace Reel_Jet.ViewModels.RegistrationPageModels.SignUpPageModels {

    public class ValidationPageModel : INotifyPropertyChanged {


        // Private Fields

        private DispatcherTimer timer;
        private Frame MainFrame;
        private string _regcode;
        private string regCodeNumber1;
        private string regCodeNumber2;
        private string regCodeNumber3;
        private string regCodeNumber4;
        private string regCodeNumber5;
        private string regCodeNumber6;
        private int remainingSeconds = 300;


        // Binding Properties

        public ICommand ConfirmCommand { get; set; }
        public User NewUser { get; set; } = new();
        public string RegCodeFromMail { get; set; }
        public string TimerText => $"Time remaining: {remainingSeconds} seconds";
        public string RegCodeNumber1 { 
            get => regCodeNumber1;
            set {
                regCodeNumber1 = value; OnProperty(); 
            } 
        }
        public string RegCodeNumber2 { 
            get => regCodeNumber2;
            set { 
                regCodeNumber2 = value; OnProperty(); } }
        public string RegCodeNumber3 { 
            get => regCodeNumber3;
            set { 
                regCodeNumber3 = value; OnProperty(); 
            } 
        }
        public string RegCodeNumber4 { 
            get => regCodeNumber4; 
            set { regCodeNumber4 = value; OnProperty(); 
            } 
        }
        public string RegCodeNumber5 { 
            get => regCodeNumber5;
            set { regCodeNumber5 = value; OnProperty(); 
            } 
        }
        public string RegCodeNumber6 { 
            get => regCodeNumber6; 
            set { regCodeNumber6 = value; OnProperty(); 
            } 
        }
        public string RegCode {
            get => _regcode;
            set {
                _regcode = value; OnProperty();
            }
        }

        // Constructor


        public ValidationPageModel(Frame frame, User newUser) {

            MainFrame = frame;
            NewUser = newUser;
            ConfirmCommand = new RelayCommand(Confirm);
            RegCodeFromMail = Random.Shared.Next(100000, 1000000).ToString();

            sendRegistrationCodeNotification(newUser.Email);
            StartTimer();
        }


        // Functions


        private void Confirm(object? param) {

            if (remainingSeconds == 0) {
                MessageBox.Show("Your Time Has Expired", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                MainFrame.Content = new MainSignUpPage(MainFrame);
            }
            else {
                if (!string.IsNullOrEmpty(RegCodeNumber1) && !string.IsNullOrEmpty(RegCodeNumber2) && !string.IsNullOrEmpty(RegCodeNumber3) &&
                    !string.IsNullOrEmpty(RegCodeNumber4) && !string.IsNullOrEmpty(RegCodeNumber5) && !string.IsNullOrEmpty(RegCodeNumber6)) {

                    UserAuthentication userAuthentication = new();

                    string fullCode = RegCodeNumber1 + RegCodeNumber2 + RegCodeNumber3 + RegCodeNumber4 + RegCodeNumber5 + RegCodeNumber6;
                    if (fullCode == RegCodeFromMail) {
                        if (userAuthentication.SignUp(NewUser))
                            MainFrame.Content = new MovieListPage(MainFrame);
                    }
                    else
                        MessageBox.Show("Registration Code is Wrong , Try Again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                    MessageBox.Show("Fill all the required fields", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                MainFrame.Content = new MovieListPage(MainFrame);
            }
        }

        private NotificationService setRegistrationCodeNotification() {

            string message = $"<div class=\"\"><div class=\"aHl\"></div><div id=\":ot\" tabindex=\"-1\"></div><div id=\":mk\" class=\"ii gt\" jslog=\"20277; u014N:xr6bB; 1:WyIjdGhyZWFkLWY6MTc2Mzg5OTExNjA0OTQ4MDAzOCIsbnVsbCxudWxsLG51bGwsbnVsbCxudWxsLG51bGwsbnVsbCxudWxsLG51bGwsbnVsbCxudWxsLG51bGwsW11d; 4:WyIjbXNnLWY6MTc2Mzg5OTExNjA0OTQ4MDAzOCIsbnVsbCxbXV0.\"><div id=\":ml\" class=\"a3s aiL msg1943207792933616446\"><u></u><div style=\"margin:0;padding:0\" bgcolor=\"#FFFFFF\"><table width=\"100%\" height=\"100%\" style=\"min-width:348px\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" lang=\"az\"><tbody><tr height=\"32\" style=\"height:32px\"><td></td></tr><tr align=\"center\"><td><div><div></div></div><table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" style=\"padding-bottom:20px;max-width:516px;min-width:220px\"><tbody><tr><td width=\"8\" style=\"width:8px\"></td><td><div style=\"border-style:solid;border-width:thin;border-color:#dadce0;border-radius:8px;padding:40px 20px\" align=\"center\" class=\"m_1943207792933616446mdv2rw\"><img src=\"https://lh3.googleusercontent.com/drive-viewer/AITFw-ybVER3Em8NRohApTXuI_dRJ9yfA9ed-Qh9g3bOAtgWwpMh6tg-1Eu8JvNCGbgu_k3v2ygTRB1z18LQmeljRbcsC6TywA=s2560\" width=\"85\" height=\"85\" aria-hidden=\"true\" style=\"margin-bottom:16px\" alt=\"Google\" class=\"CToWUd\" data-bit=\"iit\"><div style=\"font-family:'Google Sans',Roboto,RobotoDraft,Helvetica,Arial,sans-serif;border-bottom:thin solid #dadce0;color:rgba(0,0,0,0.87);line-height:32px;padding-bottom:24px;text-align:center;word-break:break-word\"><div style=\"font-size:24px\">E-poçtunuzu doğrulayın </div></div><div style=\"font-family:Roboto-Regular,Helvetica,Arial,sans-serif;font-size:14px;color:rgba(0,0,0,0.87);line-height:20px;padding-top:20px;text-align:left\">Hesabinizi dogrulamaq ucun asagidaki koddan istifade edin : <br><div style=\"text-align:center;font-size:36px;margin-top:20px;line-height:44px\">{RegCodeFromMail}</div><br>Bu kodun vaxtı 5 dəqiqə sonra bitəcək.<br><br></div></div><div style=\"text-align:left\"><div style=\"font-family:Roboto-Regular,Helvetica,Arial,sans-serif;color:rgba(0,0,0,0.54);font-size:11px;line-height:18px;padding-top:12px;text-align:center\"><div>Google Hesabı və xidmətlərinə edilən mühüm dəyişikliklərdən xəbərdar olmaq üçün bu e-məktubu aldınız.</div><div style=\"direction:ltr\">© 2023 Google LLC, <a class=\"m_1943207792933616446afal\" style=\"font-family:Roboto-Regular,Helvetica,Arial,sans-serif;color:rgba(0,0,0,0.54);font-size:11px;line-height:18px;padding-top:12px;text-align:center\">1600 Amphitheatre Parkway, Mountain View, CA 94043, USA</a></div></div></div></td><td width=\"8\" style=\"width:8px\"></td></tr></tbody></table></td></tr><tr height=\"32\" style=\"height:32px\"><td></td></tr></tbody></table></div></div><div class=\"yj6qo\"></div><div class=\"yj6qo\"></div></div><div id=\":op\" class=\"ii gt\" style=\"display:none\"><div id=\":oo\" class=\"a3s aiL \"></div></div><div class=\"hi\"></div></div>";
            NotificationService notification = new("Registration Code", message, "Reel Jet");
            notification.DateTime = DateTime.Now; // Set time of notification

            isHtml = true; // Enable Html formatting
            return notification;
        }

        private void StartTimer() {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick!;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e) {
            remainingSeconds--;
            OnProperty(nameof(TimerText));

            if (remainingSeconds == 0)
                TimerExpired();
        }

        private void sendRegistrationCodeNotification(string email) {
            Thread thread = new Thread(() => sendMail(email, setRegistrationCodeNotification()));
            thread.IsBackground = false;
            thread.Start();
        }

        private void TimerExpired() {
            timer.Stop();
        }


        // Property Changed

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnProperty([CallerMemberName] string name = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}