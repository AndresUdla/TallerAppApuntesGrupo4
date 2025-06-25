using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TallerAppApuntesGrupo4.Models;

namespace TallerAppApuntesGrupo4.Repositories
{
    public class NoteRepository
    {
        private readonly string appDataPath = FileSystem.AppDataDirectory;

        public async Task<ObservableCollection<Note>> GetAllNotesAsync()
        {
            var files = Directory.EnumerateFiles(appDataPath, "*.notes.txt");

            var notes = files.Select(filename =>
                Note.Load(Path.GetFileName(filename))
            ).OrderByDescending(n => n.Date);

            return new ObservableCollection<Note>(notes);
        }

        public async Task SaveNoteAsync(Note note)
        {
            note.Date = System.DateTime.Now;
            string fullPath = Path.Combine(appDataPath, note.Filename);
            await File.WriteAllTextAsync(fullPath, note.Text);
        }

        public async Task DeleteNoteAsync(Note note)
        {
            string fullPath = Path.Combine(appDataPath, note.Filename);
            if (File.Exists(fullPath))
                File.Delete(fullPath);
        }
    }
}
