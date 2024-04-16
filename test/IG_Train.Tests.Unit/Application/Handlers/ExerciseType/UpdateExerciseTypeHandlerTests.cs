using AutoFixture;
using IG_Train.Application.Handlers.ExerciseType;
using IG_Train.Domain.Services;
using Xunit;
using Moq;
using IG_Train.Domain.Entities;
using FluentAssertions;
using AutoMapper;
using IG_Train.Application;

namespace IG_Train.Tests.Unit.Application.Handlers
{
    public class UpdateExerciseTypeHandlerTests
    {
        [Fact]
        public async Task HandleAsync_UpdateExerciseTypeRequest_ReturnUpdateExerciseTypeResponse()
        {
            // Arrange            
            var request = new Fixture().Create<UpdateExerciseTypeRequest>();
            var response = new UpdateExerciseTypeResponse(request.Id);
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(typeof(IApplicationAssembly).Assembly);
            });
            var mapper = mockMapper.CreateMapper();

            Mock<IExerciseTypeService> mock = new Mock<IExerciseTypeService>();
            mock.Setup(s => s.UpdateExerciseType
                (It.IsAny<ExerciseTypeEntity>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(request.Id);
            
            var sut = new UpdateExerciseTypeHandler(mock.Object, mapper);

            // Act
            var result = await sut.Handle(request, new CancellationToken());

            // Assert
            result.Should().NotBeNull();
            result.Should().Be(response);
            mock.Verify(d => d.CreateExerciseType(It.IsAny<ExerciseTypeEntity>(), default), Times.Never);
            mock.Verify(d => d.GetExerciseType(It.IsAny<int>(), default), Times.Never);
            mock.Verify(d => d.GetAllExerciseTypes(default), Times.Never);
            mock.Verify(d => d.UpdateExerciseType(It.IsAny<ExerciseTypeEntity>(), default), Times.Once);
            mock.Verify(d => d.DeleteExerciseType(It.IsAny<int>(), default), Times.Never);
        }
    }
}
