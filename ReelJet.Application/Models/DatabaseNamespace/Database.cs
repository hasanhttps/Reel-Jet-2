﻿using System;
using System.Windows.Controls;
using ReelJet.Database.Contexts;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Reel_Jet.Models.MovieNamespace;
using ReelJet.Database.Entities.Concretes;

namespace ReelJet.Application.Models.DatabaseNamespace;

public static class Database {

    // Properties

    public static User CurrentUser { get; set; }
    public static List<User> Users { get; set; }
    public static ReelJetDbContext DbContext { get; set; }
    public static ObservableCollection<Movie> Movies { get; set; } = new();
    public static UserAuthentication userAuthentication { get; set; } = new();
    public static Dictionary<string, TextBlock> ErrorLabels { get; set; } = new();

    // Constructor

    static Database() {
        
    }

    // Functions

    public static bool CheckUserExist(string email, string password) {
        foreach (var user in Users) {
            if (user.Email == email && user.Password == password) {
                CurrentUser = user;
                return true;
            }
        }
        return false;
    }
}