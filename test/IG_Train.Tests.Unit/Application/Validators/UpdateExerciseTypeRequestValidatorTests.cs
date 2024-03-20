using AutoFixture.Xunit2;
using AutoFixture;
using IG_Train.Application.Handlers.ExerciseType;
using IG_Train.Application.Validators;
using Xunit;
using FluentAssertions;
using IG_Train.Tests.Unit.Application.Validators.ClassData;

namespace IG_Train.Tests.Unit.Application.Validators
{
    public class UpdateExerciseTypeRequestValidatorTests
    {

        [Theory]
        [ClassData(typeof(UpdateExerciseTypeRequestTestData))]

        public void Validate_UpdateExerciseTypeRequest_ReturnExpectedResult(int id, string name, string description, bool expectedResult)
        {
            // Arrange
            UpdateExerciseTypeRequestValidator sut = new UpdateExerciseTypeRequestValidator();
            var request = new UpdateExerciseTypeRequest(id, name, description);                

            // Act
            var result = sut.Validate(request);

            // Assert
            result.IsValid.Should().Be(expectedResult);
        }

        [Theory]
        [ClassData(typeof(UpdateExerciseTypeRequestTestData))]

        public async Task ValidateAsync_UpdateExerciseTypeRequest_ReturnExpectedResult(int id, string name, string description, bool expectedResult)
        {
            // Arrange
            UpdateExerciseTypeRequestValidator sut = new UpdateExerciseTypeRequestValidator();
            var request = new UpdateExerciseTypeRequest(id, name, description);

            // Act
            var result = await sut.ValidateAsync(request);

            // Assert
            result.IsValid.Should().Be(expectedResult);
        }


    }
}
