using Microsoft.EntityFrameworkCore;
using Moq;
using QuantumTask.Data;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace QuantumTask.Tests
{
    public class EFNoteRepositoryTests
    {
        private readonly EFNoteRepository sut;
        private readonly Mock<IDataContext> mockContext = new();

        public EFNoteRepositoryTests()
        {
            sut = new EFNoteRepository(mockContext.Object);
        }

        [Fact]
        public void Notes_GetAllNotes()
        {
            var mockSet = new Mock<DbSet<Note>>();

            mockContext.Setup(m => m.Notes).Returns(mockSet.Object);
            var actual = sut.Notes;

            Assert.NotNull(actual);
        }

        [Fact]
        public void Create_ShouldAddValidNote()
        {

        }

        [Fact]
        public void Edit_ShouldEditExistNote()
        {

        }

        private static IQueryable<Note> GetList()
        {
            List<Note> notes = new()
            {
                new Note { Id = 1, Title = "", NoteText = "", Created = System.DateTime.Now },
                new Note { Id = 1, Title = "", NoteText = "", Created = System.DateTime.Now }
            };

            return notes.AsQueryable();
        }
    }
}
