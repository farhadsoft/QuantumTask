using System;
using System.ComponentModel.DataAnnotations;

namespace QuantumTask.Data
{
    public class Note
    {
        [Key]
        public int Id { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Title { get; set; }
        [Required]
        public string NoteText { get; set; }
        public DateTime Created { get; set; }
    }
}
