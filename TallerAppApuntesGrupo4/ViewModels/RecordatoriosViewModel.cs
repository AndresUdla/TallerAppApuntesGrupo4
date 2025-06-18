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
    public class RecordatoriosViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Recordatorio> Recordatorios { get; set; } = new();

        private readonly RecordatorioRepository _repo = new();

        public ICommand AgregarCommand { get; }
        public ICommand EliminarCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        public RecordatoriosViewModel()
        {
            AgregarCommand = new Command(async () => await GoToAgregarPage());
            EliminarCommand = new Command<Recordatorio>(async (recordatorio) => await Eliminar(recordatorio));

            CargarRecordatorios();
        }

        private async void CargarRecordatorios()
        {
            var lista = await _repo.ObtenerRecordatoriosAsync();
            Recordatorios = new ObservableCollection<Recordatorio>(lista);
            OnPropertyChanged(nameof(Recordatorios));
        }

        private async Task Eliminar(Recordatorio recordatorio)
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
