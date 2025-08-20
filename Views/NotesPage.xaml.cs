using System.Collections.ObjectModel;
using System.Windows.Input;
using WeatherApp.Services;

namespace WeatherApp.Views;

public partial class NotesPage : ContentPage
{
    public NotesPage(NotesPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}