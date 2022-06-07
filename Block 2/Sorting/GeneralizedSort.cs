using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    internal class GeneralizedSort
    {
        public delegate void SortChoice<T>(T[] array, int low, int high, bool reverse) where T : IComparable;
        public void Sort<T>(T[] array, int low, int high, bool reverse, SortChoice<T> sortChoice) where T : IComparable
        {
            sortChoice(array, low, high, reverse);
        }
        
        private int Partition<T>(T[] array, int low, int high, bool reverse) where T : IComparable<T>
        {
            var i = low;
            for (var j = low; j <= high; j++)
            {
                if (reverse)
                {
                    if (array[j].CompareTo(array[high]) < 0) continue;
                }
                else
                {
                    if (array[j].CompareTo(array[high]) > 0) continue;
                }
                (array[i], array[j]) = (array[j], array[i]);
                i++;
            }

            return i - 1;
        }
        public void DefaultQSort<T>(T[] array, int low, int high, bool reverse) where T : IComparable<T>
        {
            if (low >= high) return;
            var c = Partition(array, low, high, reverse);
            DefaultQSort(array, low, c - 1, reverse);
            DefaultQSort(array, c + 1, high, reverse);
        }
        
        public void DictionarySort(string[] array, int low, int high, bool reverse)
        {
            DefaultQSort(array, 0, array.Length - 1, false);
            var sorted = from a in array
                         orderby a.Length ascending
                         select a;
            var i = 0;
            if (reverse)
            {
                foreach (var item in sorted.Reverse())
                {
                    array[i] = item;
                    i++;
                }
            }
            else
            {
                foreach (var item in sorted)
                {
                    array[i] = item;
                    i++;
                }
            }
        }
    }
}
