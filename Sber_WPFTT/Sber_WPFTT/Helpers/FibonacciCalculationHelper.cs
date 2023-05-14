using Sber_WPFTT.Entities;
using System.Linq;

namespace Sber_WPFTT.Helpers
{
    public class FibonacciCalculationHelper
    {
        public FibonacciCalculationHelper() { }
        public int[] GetFibonacciSequenceByRange(int range)
        {
            int[] fibonacciArray = new int[range];
            for (int i = 0; i < range; i++)
            {
                fibonacciArray[i] = GetFibonacciNumberByIndex(i);
            }
            return fibonacciArray;
        }
        public int GetFibonacciNumberByIndex(int n)
        {
            if (n == 0 || n == 1) return n;

            return GetFibonacciNumberByIndex(n - 1) + GetFibonacciNumberByIndex(n - 2);
        }

        public FibonacciCalculatedData GetFibonacciCalculatedData(FibonacciCalculatedData data)
        {
            var fibonacciArray = GetFibonacciSequenceByRange(data.TargetNumber);
            data.FibonacciSequence = fibonacciArray;
            data.FibonacciSequenceSum = fibonacciArray.Sum();
            return data;
        }
    }
}
