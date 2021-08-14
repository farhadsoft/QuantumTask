using QuantumTask.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuantumTask.Pages
{
    public partial class Index
    {
        private IEnumerable<Note> Notes;

        protected Note note = new();
        protected int? editId = default;
        protected bool edit = false;
        protected string SearchTerm { get; set; } = "";
        protected int TotalNotes { get; set; } = 0;

        protected override async Task OnInitializedAsync()
        {
            Notes = await Task.Run(() => noteRepository.Notes.Where(x => x.NoteText.Contains(SearchTerm) || x.Title.Contains(SearchTerm)));
            TotalNotes = Notes.Count();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            TotalNotes = await Task.Run(() => noteRepository.Notes.Count());
        }

        protected void Create()
        {
            note.Created = DateTime.Now;
            noteRepository.Create(note);
            note = new Note();
        }

        protected void Edit(Note note)
        {
            noteRepository.Edit(note);
        }

        protected void ShowEditForm()
        {
            edit = !edit;
        }

        protected void ShowEditor(int id)
        {
            if (editId == id)
            {
                editId = default;
            }
            else
            {
                editId = id;
            }
        }
    }
}
