using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using System.Collections.ObjectModel;
using TallerAppApuntesGrupo4.Models;

namespace TallerAppApuntesGrupo4.ViewModels
{
    internal class AboutViewModel
    {
        public string Title => AppInfo.Name;
        public string Version => AppInfo.VersionString;
        public string Message => "This app was created by Josue Mullo, Martin Burga & Santiago Pilamunga";

        public ObservableCollection<TeamMembers> Members { get; set; } = new();

        public AboutViewModel()
        {
            LoadMembers();
        }

        private void LoadMembers()
        {
            Members.Add(new TeamMembers
            {
                MemberName = "Josue Mullo",
                MemberAge = 20,
                MemberFavSport = "Futbol",
                ImageMember = "jotchua.jpg"
            });
            Members.Add(new TeamMembers
            {
                MemberName = "Martin Burga",
                MemberAge = 20,
                MemberFavSport = "Basketball",
                ImageMember = "martincat.jpg"
            });
            Members.Add(new TeamMembers
            {
                MemberName = "Santiago Pilamunga",
                MemberAge = 20,
                MemberFavSport = "League of Legends",
                ImageMember = "pilamungacat.jpg"
            });
        }
    }
}
