using AutoFixture;
using AutoFixture.Xunit2;
using FluentAssertions;
using IG_Train.Application.Handlers.ExerciseType;
using IG_Train.Application.Validators;
using Xunit;

namespace IG_Train.Tests.Unit.Application.Validators
{
    public class CreateExerciseTypeRequestValidatorTests
    {
        [Theory]
        [AutoData]
        public void Validate_CorrectRequest_NoErrors(
            Fixture fixture,
            CreateExerciseTypeRequestValidator sut)
        {
            // Arrange
            var request = fixture
                .Build<CreateExerciseTypeRequest>()
                .With(x => x.Name, fixture.Create<string>())
                .With(x => x.Description, fixture.Create<string>())
                .Create();

            // Act
            var result = sut.Validate(request);

            // Assert
            result.IsValid.Should().BeTrue();
        }

        [Theory]
        [AutoData]
        public void Validate_IncorrectRequest_NotValida(
            Fixture fixture,
            CreateExerciseTypeRequestValidator sut)
        {
            // Arrange
            var request = new CreateExerciseTypeRequest(string.Empty, string.Empty);

            // Act
            var result = sut.Validate(request);

            // Assert
            result.IsValid.Should().BeFalse();
        }
    }
}
