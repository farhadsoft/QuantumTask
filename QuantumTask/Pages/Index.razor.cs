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

        protected Note note = new Note();
        protected int? editId = default;
        protected bool edit = false;
        protected string SearchTerm { get; set; } = "";

        protected override async Task OnInitializedAsync()
        {
            Notes = await Task.Run(() => noteRepository.Notes.Where(x => x.NoteText.Contains(SearchTerm) || x.Title.Contains(SearchTerm)));
        }

        protected override Task OnParametersSetAsync()
        {
            return base.OnParametersSetAsync();
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
