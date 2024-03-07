using IG_Train.Application.Services;
using IG_Train.Domain.Entities;
using IG_Train.Domain.Services;
using IG_Train.Tests.ClassData.ExerciseType;
using Moq;
using Shouldly;

namespace IG_Train.Tests.Services
{
    public class ExerciseTypeServiceTests
    {
        [Fact]
        public async Task GetAllExerciseType_ShouldReturn_NotNull()
        {
            //ARRANGE
            var exerciseTypes = GetTestExerciseTypes();
            var mock = new Mock<IRepository<ExerciseType>>();
            mock.Setup(r => r.GetAllAsync()).ReturnsAsync(exerciseTypes);
            IExerciseTypeService exerciseTypeService = new ExerciseTypeService(mock.Object);

            //ACT
            var result = await exerciseTypeService.GetAllExerciseTypes();

            //ASSERT            
            result.ShouldNotBeNull();
            result.ShouldNotBeEmpty();
            result.ShouldBe(exerciseTypes);            
        }

        [Theory]
        [ClassData(typeof(ExerciseTypeIds))]
        public async Task GetExerciseType(int exerciseTypeId)
        {
            //ARRANGE            
            var (error, exerciseType) = ExerciseType.Create("Жим лежа", "Базовое упраженение на грудные мышцы");
            var mock = new Mock<IRepository<ExerciseType>>();
            mock.Setup(r => r.GetByIdAsync(exerciseTypeId)).ReturnsAsync(exerciseType);
            IExerciseTypeService exerciseTypeService = new ExerciseTypeService(mock.Object);

            //ACT
            var result = await exerciseTypeService.GetExerciseType(exerciseTypeId);

            //ASSERT            
            result.ShouldNotBeNull();            
            result.ShouldBe(exerciseType);
        }

        private IEnumerable<ExerciseType> GetTestExerciseTypes()
        {
            var (error1, first_exercise) = ExerciseType.Create("Жим лежа", "Базовое упраженение на грудные мышцы");
            var (error2, second_exercise) = ExerciseType.Create("Становая тяга", "Базовое упраженение на мышцы спины");
            var (error3, third_exercise) = ExerciseType.Create("Присед", "Базовое упраженение на мышцы ног");
            return new[] { first_exercise, second_exercise, third_exercise };
        }
    }
}
