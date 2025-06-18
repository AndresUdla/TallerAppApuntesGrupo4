using System.Collections.ObjectModel;
using System.ComponentModel;
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
        public ICommand EditCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;


        public RemindersViewModel()
        {
            AgregarCommand = new Command(async () => await GoToAgregarPage());
            EliminarCommand = new Command<Reminder>(async r => await Eliminar(r));
            EditCommand = new Command<Reminder>(async r => await Editar(r));

            CargarRecordatorios();
        }

        private async Task Editar(Reminder recordatorio)
        {
            var json = System.Text.Json.JsonSerializer.Serialize(recordatorio);
            await Shell.Current.GoToAsync($"///CreateReminderPage?data={Uri.EscapeDataString(json)}");
        }


        public async void CargarRecordatorios()
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
            await Shell.Current.GoToAsync("///CreateReminderPage");
        }

        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
