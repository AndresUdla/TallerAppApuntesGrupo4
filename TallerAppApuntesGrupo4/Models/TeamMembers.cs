using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerAppApuntesGrupo4.Models
{
    internal class TeamMembers
    {
        public required string MemberName { get; set; }
        public int MemberAge { get; set; }
        public required string MemberFavSport { get; set; } 
        public required string ImageMember { get; set; } 
    }
}
