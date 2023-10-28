using System;
using System.Linq;
using System.Text;
using ReelJet.Database.Entities.Abstracts;

namespace ReelJet.Database.Entities.Concretes;

public class PersonalMovie : BaseMovie {

    public string MovieLink { get; set; }

    // Navigation Properties

    public virtual ICollection<UserPersonalMovieWatchList> WatchList { get; set; }
    public virtual ICollection<CommentsPersonalMovies> CommentsMovies { get; set; }
    public virtual ICollection<UserPersonalMovieHistoryList> HistoryList { get; set; }
}