using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public class NotesService
    {
        private readonly HttpClient _httpClient;

        public NotesService(HttpClient httpClient)
        {
            _httpClient = httpClient;            
        }

        public async Task<List<Note>> GetNotesAsync()
        {
            try
            {
                var notes = await _httpClient.GetFromJsonAsync<List<Note>>("notes");
                return notes ?? new List<Note>();
            }
            catch (Exception ex)
            {
                // Log error, show friendly message
                Console.WriteLine($"Error fetching notes: {ex.Message}");
                return new List<Note>();
            }
        }

        public async Task<bool> AddNoteAsync(Note note)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("notes", note);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding note: {ex.Message}");
                return false;
            }
        }


    }
}
