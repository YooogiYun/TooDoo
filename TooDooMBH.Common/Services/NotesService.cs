using System.Text.Json;
using TooDooMBH.Common.Interfaces;
using TooDooMBH.Common.Models;

namespace TooDooMBH.Common.Services;

public class NotesService
{
    private readonly IStorageService _storageService;
    private readonly JsonSerializerOptions _jsonSerializerOptions;

    public NotesService(IStorageService storageService)
    {
        this._storageService = storageService;
        this._jsonSerializerOptions = new JsonSerializerOptions();
    }

    public async Task<IEnumerable<Note>> GetAllNoteAsync( )
    {
        var serializedNotes = await _storageService.GetAsync(AppConstants.StorageKeys.Notes);
        if(!string.IsNullOrWhiteSpace(serializedNotes))
        {
            var notes = JsonSerializer.Deserialize<IEnumerable<Note>>(serializedNotes , _jsonSerializerOptions);
            return notes;
        }
        return Enumerable.Empty<Note>();
    }

    public async Task AddNoteAsync(Note note)
    {
        if(note.Id == Guid.Empty)
        {
            note.Id = Guid.NewGuid();
            note.CreatedOnTime = DateTime.Now;
            var notes = (await GetAllNoteAsync()).ToList();

            notes.Add(note);

            await SaveNotes(notes);
        }
    }

    public async Task UpdateNoteAsync(Note note)
    {
        if(note.Id != Guid.Empty)
        {
            var notes = await GetAllNoteAsync();
            var noteToUpdate = notes.FirstOrDefault(n => n.Id == note.Id);

            if(noteToUpdate != null)
            {
                noteToUpdate.UpdateFrom(note);

                await SaveNotes(notes);
            }
        }
    }

    public async Task DeleteNoteAsync(Guid id)
    {
        if(id == Guid.Empty) { return; }
        var notes = (await GetAllNoteAsync()).ToList();
        var noteToDelete = notes.FirstOrDefault(n => n.Id == id);
        if(noteToDelete is not null)
        {
            notes.Remove(noteToDelete);

            await SaveNotes(notes);
        }

    }


    public async Task<Note?> GetNoteAsync(Guid id)
    {
        if(id == Guid.Empty) { return null; }
        var notes = (await GetAllNoteAsync()).ToList();
        var noteGotten = notes.FirstOrDefault(n => n.Id == id);
        return noteGotten;
    }


    private async Task SaveNotes(IEnumerable<Note> notes)
    {
        var serializedNotes = JsonSerializer.Serialize<IEnumerable<Note>>(notes);
        await _storageService.SetAsync(AppConstants.StorageKeys.Notes , serializedNotes);
    }

}
