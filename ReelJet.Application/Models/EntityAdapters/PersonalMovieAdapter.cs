using ReelJet.Database.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media.Imaging;

namespace ReelJet.Application.Models.EntityAdapters;

public class PersonalMovieAdapter {

    public string Hour { get; set; }
    public string Minute { get; set; }
    public int LikeCount { get; set; }
    public int ViewCount { get; set; }
    public string MovieLink { get; set; }
    public string Description { get; set; }
    public BitmapImage Avatar { get; set; }
    public BitmapImage Poster { get; set; }
    public DateTime UploadDate { get; set; }

    // Navigation Properties

    public virtual User User { get; set; }

}