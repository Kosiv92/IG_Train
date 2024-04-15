using AutoFixture;
using FluentAssertions;
using IG_Train.Application.Handlers.ExerciseType;
using IG_Train.Domain.Services;
using Moq;
using Xunit;

namespace IG_Train.Tests.Unit.Application.Handlers
{
    public class DeleteExerciseTypeHandlerTests
    {
        [Fact]
        public async Task HandleAsync_DeleteExerciseTypeRequest_ReturnDeleteExerciseTypeResponse()
        {
            // Arrange            
            var request = new Fixture().Create<DeleteExerciseTypeRequest>();
            var response = new DeleteExerciseTypeResponse();

            Mock<IExerciseTypeService> mock = new Mock<IExerciseTypeService>();
            mock.Setup(s => s.DeleteExerciseType
                (It.IsAny<int>(), It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);

            var sut = new DeleteExerciseTypeHandler(mock.Object);

            // Act
            var result = await sut.Handle(request, new CancellationToken());

            // Assert
            result.Should().NotBeNull();
            result.Should().Be(response);
        }
    }
}
