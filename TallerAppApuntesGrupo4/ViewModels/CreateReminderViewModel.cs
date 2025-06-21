using System.ComponentModel;
using System.Windows.Input;
using TallerAppApuntesGrupo4.Models;
using TallerAppApuntesGrupo4.Repositories;
using System.Collections.ObjectModel;

namespace TallerAppApuntesGrupo4.ViewModels
{
    public class CreateReminderViewModel : INotifyPropertyChanged
    {
        // Propiedades
        private string texto;
        public string Texto { get => texto; set { texto = value; OnPropertyChanged(nameof(Texto)); } }

        private TimeSpan hora;
        public TimeSpan Hora { get => hora; set { hora = value; OnPropertyChanged(nameof(Hora)); } }

        private bool activo;
        public bool Activo { get => activo; set { activo = value; OnPropertyChanged(nameof(Activo)); } }

        private readonly ReminderRepository _repo = new();
        public ICommand SaveCommand { get; }

        private Reminder _recordatorioOriginal;

        public CreateReminderViewModel()
        {
            SaveCommand = new Command(async () => await GuardarRecordatorio());
        }

        public void CargarParaEditar(Reminder recordatorio)
        {
            _recordatorioOriginal = recordatorio;
            Texto = recordatorio.Texto;
            Hora = recordatorio.FechaHora;
            Activo = recordatorio.Activo;
        }

        private async Task GuardarRecordatorio()
        {
            var lista = await _repo.ObtenerRecordatoriosAsync();

            if (_recordatorioOriginal != null)
            {
                var index = lista.IndexOf(lista.First(r => r.Texto == _recordatorioOriginal.Texto && r.FechaHora == _recordatorioOriginal.FechaHora));
                lista[index] = new Reminder { Texto = Texto, FechaHora = Hora, Activo = Activo };
            }
            else
            {
                lista.Add(new Reminder { Texto = Texto, FechaHora = Hora, Activo = Activo });
            }

            await _repo.GuardarRecordatoriosAsync(lista);
            await Shell.Current.GoToAsync("///ReminderPage");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

}
