using System.Linq;

namespace QuantumTask.Data
{
    public interface INoteRepository
    {
        IQueryable<Note> Notes { get; }
        public void Create(Note note);
        public void Edit(Note note);
    }
}
