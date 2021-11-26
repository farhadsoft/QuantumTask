using System;
using System.Collections.Generic;
using System.Linq;

namespace QuantumTask.Data
{
    public class EFNoteRepository : INoteRepository
    {
        private readonly DataContext context; 
        public EFNoteRepository(DataContext context)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            this.context = context;
        }
        /// <summary>
        /// Get all notes from data storage.
        /// </summary>
        public IEnumerable<Note> Notes => context.Notes;

        /// <summary>
        /// Create a new note.
        /// </summary>
        /// <param name="note">New note</param>
        public void Create(Note note)
        {
            context.Notes.Add(note);
            SaveChanges(context);
        }

        /// <summary>
        /// Edit a selected note.
        /// </summary>
        /// <param name="note">Selected note</param>
        public void Edit(Note note)
        {
            context.Notes.Update(note);
            SaveChanges(context);
        }

        public void SaveChanges(DataContext context)
        {
            ((DataContext)context).SaveChanges();
        }
    }
}
