using System.Collections.Generic;
using System.Linq;

namespace QuantumTask.Data
{
    public interface INoteRepository
    {
        IEnumerable<Note> Notes { get; }
        public void Create(Note note);
        public void Edit(Note note);
        public void SaveChanges(DataContext context);
    }
}
