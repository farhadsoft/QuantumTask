using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuantumTask.Data
{
    public class Note
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string NoteText { get; set; }
        public string Created { get; set; }

        public IEnumerable<Note> Notes { get; set; }
    }
}
