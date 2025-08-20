using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherApp.Views
{
    public class NotesPageViewModel
    {
        private readonly NotesService _apiService;

        public ObservableCollection<Note> Notes { get; } = new();
        public Note NewNote { get; set; } = new();

        public ICommand LoadNotesCommand { get; }
        public ICommand AddNoteCommand { get; }

        public NotesPageViewModel(NotesService apiService)
        {
            _apiService = apiService;

            LoadNotesCommand = new Command(async () => await LoadNotes());
            AddNoteCommand = new Command(async () => await AddNote());

            // Auto-load notes when VM is created
            Task.Run(LoadNotes);
        }

        private async Task LoadNotes()
        {
            var notes = await _apiService.GetNotesAsync();
            MainThread.BeginInvokeOnMainThread(() =>
            {
                Notes.Clear();
                foreach (var note in notes)
                    Notes.Add(note);
            });
        }

        private async Task AddNote()
        {
            if (!string.IsNullOrWhiteSpace(NewNote.Title) &&
                !string.IsNullOrWhiteSpace(NewNote.Description))
            {
                var success = await _apiService.AddNoteAsync(NewNote);
                if (success)
                {
                    MainThread.BeginInvokeOnMainThread(() =>
                    {
                        Notes.Add(new Note { Title = NewNote.Title, Description = NewNote.Description });
                        NewNote = new Note();
                    });
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Could not save note.", "OK");
                }
            }
        }
    }
}
