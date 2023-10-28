using Reel_Jet.Models;
using Reel_Jet.Models.DatabaseNamespace;
using ReelJet.Database.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reel_Jet.Services.InterfaceServices {
    public interface IAuthLoginService {
        bool LogIn(User user);
    }
}
