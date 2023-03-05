using System.Collections;

namespace Hero_net.Models;

public static class DataFixture
{
    public class RemoveDuplicateData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {new int[] {1, 1, 2}, 2};
            yield return new object[] {new int[] {0, 0, 1, 1, 1, 2, 2, 3, 3, 4}, 5};
            yield return new object[] {new int[] {0, 0, 1, 1, 1, 2, 2, 3, 3, 4, 5, 5}, 6};
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public class LargestNumberData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {new int[] {10, 2}, "210"};
            yield return new object[] {new int[] {3, 31, 5}, "5331"};
            yield return new object[] {new int[] {3, 23, 5, 12}, "532312"};
            yield return new object[] {new int[] {30, 3, 34, 9, 5}, "9534330"};
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
}