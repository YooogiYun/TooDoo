using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace TooDooMBH.Common.Models;

public class Note
{
    public Guid Id { get; set; } = Guid.Empty;

    [Required, MaxLength(75)]
    public string Title { get; set; }

    public string Content { get; set; }

    [MaxLength(250)]
    public string Description { get; set; }

    public List<string> Tags { get; set; }
    public DateTime CreatedOnTime { get; set; } = DateTime.Now;
    public DateTime ModifiedOnTime { get; set; }
    public string Url { get; set; }

    public bool UpdateFrom(Note note)
    {
        //Note backupNote = new()
        //{
        //    Id = this.Id,
        //    Title = this.Title ,
        //    Description = this.Description ,
        //    Content = this.Content ,
        //    Tags = this.Tags ,
        //    CreatedOnTime = this.CreatedOnTime ,
        //    ModifiedOnTime = this.ModifiedOnTime ,
        //    Url = this.Url ,
        //};

        try
        {
            this.Title = note.Title;
            this.Content = note.Content;
            this.Description = note.Description;
            this.Tags = note.Tags;
            this.ModifiedOnTime = DateTime.Now;
            this.Url = note.Url;
            return true;
        }
        catch(Exception e)
        {
            Debug.Print($"Failed to Update\nError message: {e.Message}");
            return false;
            //throw e;
        }
    }
}
