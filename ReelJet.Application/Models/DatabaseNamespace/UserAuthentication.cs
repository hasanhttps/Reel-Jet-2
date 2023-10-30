using System;
using System.IO;
using System.Windows;
using System.ComponentModel;
using System.Windows.Media.Imaging;
using System.Runtime.CompilerServices;
using Reel_Jet.Services.InterfaceServices;
using ReelJet.Database.Entities.Concretes;
using static ReelJet.Application.Models.DatabaseNamespace.Database;

namespace ReelJet.Application.Models.DatabaseNamespace;

public class UserAuthentication : IAuthLoginService, IAuthLogOutService, IAuthSignUpService, INotifyPropertyChanged {

    // Private Fields

    private BitmapImage _avatar;

    // Properties

    public BitmapImage Avatar { get => _avatar;
        set { 
            _avatar = value; OnProperty();
        } 
    }


    // Functions

    public bool LogIn(User user) {

        if (Users == null) return false;

        if (CheckUserExist(user.Email!, user.Password!)) return true;
        return false;
    }

    public bool SignUp(User newUser) {
        if (!CheckUserExist(newUser.Email!, newUser.Password!)) {

            //string imagePath = AppDomain.CurrentDomain + "/Static Files/Images/MaleUserProfile.png";

            //using (FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read)) {
            //    using (BinaryReader br = new BinaryReader(fs)) {
            //        newUser.Avatar = br.ReadBytes((int)fs.Length);
            //        Avatar = LoadImage(newUser.Avatar!);
            //    }
            //}

            CurrentUser = newUser;
            Users.Add(newUser);

            DbContext.Add<User>(newUser);
            DbContext.SaveChanges();

            return true;
        }
        else {
            MessageBox.Show("This email is already in use", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }
    }

    public void LogOut(User user) {
        // database-dan silme
    }

    public static BitmapImage LoadImage(byte[] imageData) {
        if (imageData == null || imageData.Length == 0) return null;

        var image = new BitmapImage();

        using (var mem = new MemoryStream(imageData)) {
            mem.Position = 0;
            image.BeginInit();
            image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
            image.CacheOption = BitmapCacheOption.OnLoad;
            image.UriSource = null;
            image.StreamSource = mem;
            image.EndInit();
        }
        image.Freeze();
        return image;
    }

    // INotifyPropertyChanged

    public event PropertyChangedEventHandler? PropertyChanged;

    public void OnProperty([CallerMemberName] string ?name = null) {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
