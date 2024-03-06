
using System.Collections;

namespace IG_Train.Tests.ClassData.ExerciseType
{
    public class ExerciseTypeIds : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 1 };
            yield return new object[] { 2 };
            yield return new object[] { 3 };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();       
    }
}
