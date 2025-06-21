using System.Text.Json;
using TallerAppApuntesGrupo4.Models;
using TallerAppApuntesGrupo4.ViewModels;
using Microsoft.Maui.Controls;

namespace TallerAppApuntesGrupo4.Views
{
    public partial class CreateReminderPage : ContentPage, IQueryAttributable
    {
        private CreateReminderViewModel _viewModel;

        public CreateReminderPage()
        {
            InitializeComponent();
            _viewModel = new CreateReminderViewModel();
            BindingContext = _viewModel;
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("data"))
            {
                try
                {
                    string json = Uri.UnescapeDataString(query["data"].ToString());
                    var recordatorio = JsonSerializer.Deserialize<Reminder>(json);

                    if (recordatorio != null)
                    {
                        _viewModel.CargarParaEditar(recordatorio);
                    }
                }
                catch (Exception ex)
                {
                    // Opcional: puedes mostrar un mensaje de error si algo falla
                }
            }
        }
    }
}
