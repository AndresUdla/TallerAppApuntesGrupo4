using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerAppApuntesGrupo4.Models
{
    public class Reminder
    {
        public string Texto { get; set; }
        public TimeSpan FechaHora { get; set; }
        public bool Activo { get; set; }
    }
}
