using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;
using System.Text.Json;
using TallerAppApuntesGrupo4.Models;

namespace TallerAppApuntesGrupo4.Repositories
{
    public class ReminderRepository
    {
        private readonly string filePath;

        public ReminderRepository()
        {
            filePath = Path.Combine(FileSystem.AppDataDirectory, "recordatorios.json");
        }

        public async Task<ObservableCollection<Reminder>> ObtenerRecordatoriosAsync()
        {
            if (!File.Exists(filePath))
                return new ObservableCollection<Reminder>();

            var json = await File.ReadAllTextAsync(filePath);
            return JsonSerializer.Deserialize<ObservableCollection<Reminder>>(json)
                   ?? new ObservableCollection<Reminder>();
        }

        public async Task GuardarRecordatoriosAsync(ObservableCollection<Reminder> recordatorios)
        {
            var json = JsonSerializer.Serialize(recordatorios);
            await File.WriteAllTextAsync(filePath, json);
        }
    }
}

