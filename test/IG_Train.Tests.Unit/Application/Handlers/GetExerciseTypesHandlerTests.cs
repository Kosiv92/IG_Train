using AutoFixture;
using FluentAssertions;
using IG_Train.Application.Handlers.ExerciseType;
using IG_Train.Domain.Entities;
using IG_Train.Domain.Services;
using Moq;
using Xunit;

namespace IG_Train.Tests.Unit.Application.Handlers
{
    public class GetExerciseTypesHandlerTests
    {
        [Fact]
        public async Task HandleAsync_GetExerciseTypesRequest_ReturnGetExerciseTypesResponse()
        {
            // Arrange            
            var fixture = new Fixture();

            var exerciseTypes = fixture
                .CreateMany<ExerciseTypeEntity>();
            var request = fixture
                .Create<GetExerciseTypesRequest>();

            var response = new GetExerciseTypesResponse(exerciseTypes);                

            Mock<IExerciseTypeService> mock = new Mock<IExerciseTypeService>();
            mock.Setup(s => s.GetAllExerciseTypes
                (It.IsAny<CancellationToken>())).ReturnsAsync(exerciseTypes);

            var sut = new GetExerciseTypesHandler(mock.Object);

            // Act
            var result = await sut.Handle(request, new CancellationToken());

            // Assert
            result.Should().NotBeNull();
            result.Should().Be(response);
        }
    }
}
