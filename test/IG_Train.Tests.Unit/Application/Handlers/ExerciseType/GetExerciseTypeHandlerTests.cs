using AutoFixture;
using FluentAssertions;
using IG_Train.Application.Handlers.ExerciseType;
using IG_Train.Domain.Entities;
using IG_Train.Domain.Services;
using Moq;
using Xunit;

namespace IG_Train.Tests.Unit.Application.Handlers
{
    public class GetExerciseTypeHandlerTests
    {
        [Fact]
        public async Task HandleAsync_GetExerciseTypeRequest_ReturnGetExerciseTypeResponse()
        {
            // Arrange            
            var fixture = new Fixture();

            var exerciseType = fixture
                .Create<ExerciseTypeEntity>();                

            var request = fixture
                .Create<GetExerciseTypeRequest>();

            var response = new GetExerciseTypeResponse(exerciseType);                

            Mock<IExerciseTypeService> mock = new Mock<IExerciseTypeService>();
            mock.Setup(s => s.GetExerciseType
                (It.IsAny<int>(), It.IsAny<CancellationToken>())).ReturnsAsync(exerciseType);

            var sut = new GetExerciseTypeHandler(mock.Object);

            // Act
            var result = await sut.Handle(request, new CancellationToken());

            // Assert
            result.Should().NotBeNull();
            result.Should().Be(response);
            mock.Verify(d => d.CreateExerciseType(It.IsAny<ExerciseTypeEntity>(), default), Times.Never);
            mock.Verify(d => d.GetExerciseType(It.IsAny<int>(), default), Times.Once);
            mock.Verify(d => d.GetAllExerciseTypes(default), Times.Never);
            mock.Verify(d => d.UpdateExerciseType(It.IsAny<ExerciseTypeEntity>(), default), Times.Never);
            mock.Verify(d => d.DeleteExerciseType(It.IsAny<int>(), default), Times.Never);
        }
    }
}
