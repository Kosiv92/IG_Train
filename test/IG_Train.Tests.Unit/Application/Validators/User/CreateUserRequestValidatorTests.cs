
using FluentAssertions;
using IG_Train.Application.Handlers.ExerciseType;
using IG_Train.Application.Handlers.User;
using IG_Train.Application.Validators;
using IG_Train.Tests.Unit.Application.TestData;
using Xunit;

namespace IG_Train.Tests.Unit.Application.Validators
{
    public class CreateUserRequestValidatorTests
    {
        [Theory]
        [ClassData(typeof(CreateUserRequestTestData))]
        public void Validate_CreateUserRequest_ReturnExpectedResult(
            string name, string email, string password, bool expectedResult)
        {
            // Arrange
            CreateUserRequestValidator sut = new CreateUserRequestValidator();
            var request = new CreateUserRequest(name, email, password);

            // Act
            var result = sut.Validate(request);

            // Assert
            result.IsValid.Should().Be(expectedResult);
        }

        [Theory]
        [ClassData(typeof(CreateUserRequestTestData))]
        public async Task ValidateAsync_CreateUserRequest_ReturnExpectedResult(
            string name, string email, string password, bool expectedResult)
        {
            // Arrange
            CreateUserRequestValidator sut = new CreateUserRequestValidator();
            var request = new CreateUserRequest(name, email, password);

            // Act
            var result = await sut.ValidateAsync(request);

            // Assert
            result.IsValid.Should().Be(expectedResult);
        }
    }
}
