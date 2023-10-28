using System;
using System.Windows;
using System.Collections.Generic;
using ReelJet.Database.Entities.Concretes;
using static Reel_Jet.Models.DatabaseNamespace.JsonHandling;
using static ReelJet.Application.Models.DatabaseNamespace.Database;

namespace ReelJet.Application;

public partial class App : System.Windows.Application {

    private void Application_Exit(object sender, ExitEventArgs e) {
        WriteData<List<User>>(Users, "users");
    }
}
