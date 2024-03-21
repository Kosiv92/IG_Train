using System.Collections;


namespace IG_Train.Tests.Unit.Application.Validators.ClassData
{
    public class CreateExerciseTypeRequestTestData : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator()
        {
            yield return new object?[] { "name", "description", true };
            yield return new object?[] { "name", "", true };
            yield return new object?[] { "name", null, true };
            yield return new object?[] { null, null, false };
            yield return new object?[] { null, "description", false };
            yield return new object?[] { "", "description", false };
            yield return new object?[] { "", "", false };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();                
    }
}