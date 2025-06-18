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
    public class RecordatorioRepository
    {
        private readonly string filePath;

        public RecordatorioRepository()
        {
            filePath = Path.Combine(FileSystem.AppDataDirectory, "recordatorios.json");
        }

        public async Task<ObservableCollection<Recordatorio>> ObtenerRecordatoriosAsync()
        {
            if (!File.Exists(filePath))
                return new ObservableCollection<Recordatorio>();

            var json = await File.ReadAllTextAsync(filePath);
            return JsonSerializer.Deserialize<ObservableCollection<Recordatorio>>(json)
                   ?? new ObservableCollection<Recordatorio>();
        }

        public async Task GuardarRecordatoriosAsync(ObservableCollection<Recordatorio> recordatorios)
        {
            var json = JsonSerializer.Serialize(recordatorios);
            await File.WriteAllTextAsync(filePath, json);
        }
    }
}

