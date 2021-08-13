using System.Linq;

namespace QuantumTask.Data
{
    public class EFNoteRepository : INoteRepository
    {
        private DataContext context; 
        public EFNoteRepository(DataContext context)
        {
            this.context = context;
        }
        /// <summary>
        /// Get all notes from data storage.
        /// </summary>
        public IQueryable<Note> Notes => context.Notes;

        /// <summary>
        /// Create a new note.
        /// </summary>
        /// <param name="note">New note</param>
        public void Create(Note note)
        {
            context.Add(note);
            context.SaveChanges();
        }

        /// <summary>
        /// Edit a selected note.
        /// </summary>
        /// <param name="note">Selected note</param>
        public void Edit(Note note)
        {
            context.Update(note);
            context.SaveChanges();
        }
    }
}
