using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Курсова
{
    public class UniqueNumbers
    {
        private int[] arr;
        public UniqueNumbers(int first, int last, int len)
        {
            arr = GetUniqueNums(first, last, len);
        }
        public int this[int i] => arr[i];
        private int[] GetUniqueNums(int first, int last, int len)
        {
            HashSet<int> indexes = new HashSet<int>();
            while (indexes.Count != len)
                indexes.Add(new Random().Next(first, last)); // генерує включно від first до last - 1 
            return indexes.ToArray();
        }
        public int[] ToIntArr() => arr;
        public int Length => arr.Length;
    }
}
