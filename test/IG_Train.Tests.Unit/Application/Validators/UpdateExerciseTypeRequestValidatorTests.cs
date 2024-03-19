﻿using AutoFixture.Xunit2;
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

        public void Validate_CorrectRequest_NoErrors(int id, string name, string description, bool expectedResult)
        {
            // Arrange
            UpdateExerciseTypeRequestValidator sut = new UpdateExerciseTypeRequestValidator();
            var request = new UpdateExerciseTypeRequest(id, name, description);                

            // Act
            var result = sut.Validate(request);

            // Assert
            result.IsValid.Should().Be(expectedResult);
        }


        //[Theory]
        //[AutoData]
        //public void Validate_CorrectRequest_NoErrors(
        //    Fixture fixture,
        //    UpdateExerciseTypeRequestValidator sut)
        //{
        //    // Arrange
        //    var request = fixture
        //        .Build<UpdateExerciseTypeRequest>()
        //        .With(x => x.id, fixture.Create<int>())
        //        .With(x => x.Name, fixture.Create<string>())
        //        .With(x => x.Description, fixture.Create<string>())
        //        .Create();

        //    // Act
        //    var result = sut.Validate(request);

        //    // Assert
        //    result.IsValid.Should().BeTrue();
        //}

        [Theory]
        [AutoData]
        public void Validate_IncorrectRequest_NotValid(
            Fixture fixture,
            UpdateExerciseTypeRequestValidator sut)
        {
            // Arrange
            var request = new UpdateExerciseTypeRequest(default, string.Empty, string.Empty);

            // Act
            var result = sut.Validate(request);

            // Assert
            result.IsValid.Should().BeFalse();
        }
    }
}