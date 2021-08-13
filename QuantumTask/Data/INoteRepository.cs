using System.Linq;

namespace QuantumTask.Data
{
    public interface INoteRepository
    {
        IQueryable<Note> Notes { get; }
    }
}
