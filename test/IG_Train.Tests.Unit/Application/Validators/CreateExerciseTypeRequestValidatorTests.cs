using AutoFixture;
using AutoFixture.Xunit2;
using FluentAssertions;
using IG_Train.Application.Handlers.ExerciseType;
using IG_Train.Application.Validators;
using IG_Train.Tests.Unit.Application.Validators.ClassData;
using Xunit;

namespace IG_Train.Tests.Unit.Application.Validators
{
    public class CreateExerciseTypeRequestValidatorTests
    {
        [Theory]
        [ClassData(typeof(CreateExerciseTypeRequestTestData))]
        public void Validate_CreateExerciseTypeRequest_ReturnExpectedResult(
            string name, string description, bool expectedResult)
        {
            // Arrange
            CreateExerciseTypeRequestValidator sut = new CreateExerciseTypeRequestValidator();
            var request = new CreateExerciseTypeRequest(name, description);

            // Act
            var result = sut.Validate(request);

            // Assert
            result.IsValid.Should().Be(expectedResult);
        }

        [Theory]
        [ClassData(typeof(CreateExerciseTypeRequestTestData))]
        public async Task ValidateAsync_CreateExerciseTypeRequest_ReturnExpectedResult(
            string name, string description, bool expectedResult)
        {
            // Arrange
            CreateExerciseTypeRequestValidator sut = new CreateExerciseTypeRequestValidator();
            var request = new CreateExerciseTypeRequest(name, description);

            // Act
            var result = await sut.ValidateAsync(request);

            // Assert
            result.IsValid.Should().Be(expectedResult);
        }
    }
}
