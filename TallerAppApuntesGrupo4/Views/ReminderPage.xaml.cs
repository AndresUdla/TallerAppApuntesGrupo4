using TallerAppApuntesGrupo4.ViewModels;

namespace TallerAppApuntesGrupo4.Views
{
    public partial class ReminderPage : ContentPage
    {
        private RemindersViewModel vm;

        public ReminderPage()
        {
            InitializeComponent();
            vm = new RemindersViewModel();
            BindingContext = vm;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            vm.CargarRecordatorios();
        }
    }
}
