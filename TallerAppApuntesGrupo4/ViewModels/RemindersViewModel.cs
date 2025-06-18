using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TallerAppApuntesGrupo4.Models;
using TallerAppApuntesGrupo4.Repositories;

namespace TallerAppApuntesGrupo4.ViewModels
{
    public class RemindersViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Reminder> Recordatorios { get; set; } = new();

        private readonly ReminderRepository _repo = new();

        public ICommand AgregarCommand { get; }
        public ICommand EliminarCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        public RemindersViewModel()
        {
            AgregarCommand = new Command(async () => await GoToAgregarPage());
            EliminarCommand = new Command<Reminder>(async (recordatorio) => await Eliminar(recordatorio));

            CargarRecordatorios();
        }

        private async void CargarRecordatorios()
        {
            var lista = await _repo.ObtenerRecordatoriosAsync();
            Recordatorios = new ObservableCollection<Reminder>(lista);
            OnPropertyChanged(nameof(Recordatorios));
        }

        private async Task Eliminar(Reminder recordatorio)
        {
            Recordatorios.Remove(recordatorio);
            await _repo.GuardarRecordatoriosAsync(Recordatorios);
        }

        private async Task GoToAgregarPage()
        {
            await Shell.Current.GoToAsync("CrearRecordatorioPage");
        }

        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
