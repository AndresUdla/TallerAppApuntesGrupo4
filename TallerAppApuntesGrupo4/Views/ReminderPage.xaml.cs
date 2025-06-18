using TallerAppApuntesGrupo4.ViewModels;

namespace TallerAppApuntesGrupo4.Views;
public partial class ReminderPage : ContentPage
{
    public ReminderPage()
    {
        InitializeComponent();
        BindingContext = new RemindersViewModel();
    }
}
