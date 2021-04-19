using System;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using Moq;
using BarbershopWebApp.BLL.Contracts;
using BarbershopWebApp.BLL.Implementation;
using BarbershopWebApp.DAL.Contracts;
using BarbershopWebApp.Domain;
using BarbershopWebApp.Domain.Models;
using NUnit.Framework;

namespace BarbershopWebApp.BLL.Tests.Unit
{
    [TestFixture]
    public class NoteServiceTest
    {
        [Test]
        public async Task CreateAsync_NoteValidationSucceed_CreatesNote()
        {
            // Arrange
            var note = new NoteUpdateModel();
            var expected = new Note();
            
            var consumerService = new Mock<IConsumerService>();
            consumerService.Setup(x => x.ValidateAsync(note));
            var barberService = new Mock<IBarberService>();
            barberService.Setup(x => x.ValidateAsync(note));
            var haircutService = new Mock<IHaircutService>();
            haircutService.Setup(x => x.ValidateAsync(note));
            
            var noteDAL = new Mock<INoteDAL>();
            noteDAL.Setup(x => x.InsertAsync(note)).ReturnsAsync(expected);

            var noteService = new NoteService(noteDAL.Object, consumerService.Object, barberService.Object,haircutService.Object);
            
            // Act
            var result = await noteService.CreateAsync(note);
            
            // Assert
            result.Should().Be(expected);
        }
        
        [Test]
        public async Task CreateAsync_NoteValidationconsumerFailed_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var note = new NoteUpdateModel();
            var expected = fixture.Create<string>();
            
            var consumerService = new Mock<IConsumerService>();
            consumerService.Setup(x => x.ValidateAsync(note))
                .Throws(new InvalidOperationException(expected));
            var barberService = new Mock<IBarberService>();
            barberService.Setup(x => x.ValidateAsync(note));
            var haircutService = new Mock<IHaircutService>();
            haircutService.Setup(x => x.ValidateAsync(note));

            
            var noteDAL = new Mock<INoteDAL>();
            
            var noteService = new NoteService(noteDAL.Object, consumerService.Object, barberService.Object,haircutService.Object);
            
            var action = new Func<Task>(() => noteService.CreateAsync(note));
            
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>().WithMessage(expected);
            noteDAL.Verify(x => x.InsertAsync(note), Times.Never);
        }
        
        [Test]
        public async Task CreateAsync_NoteValidationbarberFailed_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var note = new NoteUpdateModel();
            var expected = fixture.Create<string>();
            
            var consumerService = new Mock<IConsumerService>();
            consumerService.Setup(x => x.ValidateAsync(note));
            var barberService = new Mock<IBarberService>();
            barberService.Setup(x => x.ValidateAsync(note)) 
                .Throws(new InvalidOperationException(expected));
            var haircutService = new Mock<IHaircutService>();
            haircutService.Setup(x => x.ValidateAsync(note));

            
            var noteDAL = new Mock<INoteDAL>();
            
            var noteService = new NoteService(noteDAL.Object, consumerService.Object, barberService.Object,haircutService.Object);
            
            var action = new Func<Task>(() => noteService.CreateAsync(note));
            
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>().WithMessage(expected);
            noteDAL.Verify(x => x.InsertAsync(note), Times.Never);
        }
        
        [Test]
        public async Task CreateAsync_NoteValidationhaircutFailed_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var note = new NoteUpdateModel();
            var expected = fixture.Create<string>();
            
            var consumerService = new Mock<IConsumerService>();
            consumerService.Setup(x => x.ValidateAsync(note));
            var barberService = new Mock<IBarberService>();
            barberService.Setup(x => x.ValidateAsync(note));
            var haircutService = new Mock<IHaircutService>();
            haircutService.Setup(x => x.ValidateAsync(note))
                .Throws(new InvalidOperationException(expected));

            
            var noteDAL = new Mock<INoteDAL>();
            
            var noteService = new NoteService(noteDAL.Object, consumerService.Object, barberService.Object,haircutService.Object);
            
            var action = new Func<Task>(() => noteService.CreateAsync(note));
            
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>().WithMessage(expected);
            noteDAL.Verify(x => x.InsertAsync(note), Times.Never);
        }
    }
}