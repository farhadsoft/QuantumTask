using Microsoft.AspNetCore.Components;
using QuantumTask.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuantumTask.Pages
{
    public partial class Index
    {
        [Inject]
        INoteRepository NoteRepository { get; set; }
        protected List<Note> Notes;
        protected Note note = new();
        protected int? editId = default;
        protected bool edit = false;
        protected string SearchTerm { get; set; } = "";
        protected int TotalNotes { get; set; } = 0;

        protected override void OnInitialized()
        {
            Notes = NoteRepository.Notes.Where(x => x.NoteText.Contains(SearchTerm) || x.Title.Contains(SearchTerm))
                    .OrderByDescending(x => x.Created).ToList();
            TotalNotes = Notes.Count;
        }

        protected override void OnAfterRender(bool firstRender)
        {
            TotalNotes = NoteRepository.Notes.Count();
        }

        protected int CreatedDayCalc(DateTime createDate)
        {
            TimeSpan timeSpan = DateTime.Now.Subtract(createDate);
            int days = Convert.ToInt32(timeSpan.TotalDays);
            return days;
        }

        protected void Create()
        {
            note.Created = DateTime.Now;
            NoteRepository.Create(note);
            note = new Note();
        }

        protected void Edit(Note note)
        {
            NoteRepository.Edit(note);
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
