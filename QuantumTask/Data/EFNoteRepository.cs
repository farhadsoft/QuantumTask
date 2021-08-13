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
        public IQueryable<Note> Notes => context.Notes;
        public void Create(Note note)
        {
            context.Add(note);
            context.SaveChanges();
        }
        public void Edit(Note note)
        {
            context.Update(note);
            context.SaveChanges();
        }
    }
}
