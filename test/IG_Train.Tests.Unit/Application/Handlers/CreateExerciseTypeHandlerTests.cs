using AutoFixture;
using IG_Train.Application.Handlers.ExerciseType;
using IG_Train.Domain.Services;
using Xunit;
using Moq;
using IG_Train.Domain.Entities;
using FluentAssertions;

namespace IG_Train.Tests.Unit.Application.Handlers
{
    public class CreateExerciseTypeHandlerTests
    {
        [Fact]
        public async Task HandleAsync_CreateExerciseTypeRequest_ReturnCreateExerciseTypeResponse()
        {
            // Arrange
            int id = 1;
            var request = new Fixture().Create<CreateExerciseTypeRequest>();
            var response = new CreateExerciseTypeResponse(id);            

            Mock<IExerciseTypeService> mock = new Mock<IExerciseTypeService>();
            mock.Setup(s => s.CreateExerciseType
                (It.IsAny<ExerciseTypeEntity>(), It.IsAny<CancellationToken>())).ReturnsAsync(id);
            
            var sut = new CreateExerciseTypeHandler(mock.Object);

            // Act
            var result = await sut.Handle(request, new CancellationToken());

            // Assert
            result.Should().NotBeNull();
            result.Should().Be(response);
        }
    }
}
