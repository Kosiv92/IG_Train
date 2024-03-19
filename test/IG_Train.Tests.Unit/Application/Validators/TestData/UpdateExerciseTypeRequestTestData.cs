using System.Collections;


namespace IG_Train.Tests.Unit.Application.Validators.ClassData
{
    public class UpdateExerciseTypeRequestTestData : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator()
        {
            yield return new object?[] { 1, "name", "description", true };
            yield return new object?[] { 1, "name", "", true };
            yield return new object?[] { 1, "name", null, true };
            yield return new object?[] { default, null, null, false };
            yield return new object?[] { default, null, "description", false };
            yield return new object?[] { default, "name", "description", false };
            yield return new object?[] { 1, null, "description", false };
            yield return new object?[] { 1, "", "description", false };
            yield return new object?[] { 0, "name", "description", false };
            yield return new object?[] { -1, "name", "description", false };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();                
    }
}