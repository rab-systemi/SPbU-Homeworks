using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircularList
{
    internal static class CircleListExtensions
    {
        //Any<TSource>(IEnumerable<TSource>) – Проверяет,
        //содержит ли последовательность какие-либо элементы
        public static bool Any<TSource>(this IEnumerable<TSource> source)
        {
            foreach (var item in source)
            {
                if (item != null)
                {
                    return true;
                }
            }
            return false;
        }

        //Append<TSource>(IEnumerable<TSource>, TSource) – Добавляет
        //значение в конец последовательности
        public static IEnumerable<TSource> Append<TSource>(this IEnumerable<TSource> list, TSource data) //MAY BE TO FINISH
        {
            var newList = ((CircleList<TSource>)list).MyMemberwiseClone();
            newList.AddLast(data);
            return newList;
        }

        //Concat<TSource>(IEnumerable<TSource>, IEnumerable<TSource>) – Объединяет две последовательности
        public static void Concat<TSource>(this IEnumerable<TSource> list1, IEnumerable<TSource> list2) //TO FINISH
        {

        }

        //Contains<TSource>(IEnumerable<TSource>, TSource) – Определяет, содержится ли указанный элемент
        //впоследовательности,используя компаратор проверки на равенство по умолчанию
        public static void Contains<TSource>(this IEnumerable<TSource> list, TSource data) //TO FINISH
        {

        }

        //Count<TSource>(IEnumerable<TSource>) – Возвращает количество элементов в последовательности
        public static int Count<TSource>(this IEnumerable<TSource> list)
        {
            int count = 0;
            foreach (var item in list)
            {
                if (item != null)
                {
                    count++;
                }
            }
            return count;
        }

        //Count<TSource>(IEnumerable<TSource>, Func<TSource,Boolean>) – Возвращает число,представляющее
        //количество элементов последовательности, удовлетворяющих заданному условию
        public static int Count<TSource>(this IEnumerable<TSource> list, Func<TSource, Boolean> f)
        {
            int count = 0;
            foreach (var item in list)
            {
                if (item != null && f(item))
                {
                    count++;
                }
            }
            return count;
        }

        //ElementAt<TSource>(IEnumerable<TSource>, Int32) – Возвращает элемент по указанному индексу в последовательности
        public static TSource ElementAt<TSource>(this IEnumerable<TSource> list, int index)
        {
            int counter = 0;
            foreach (var item in list)
            {
                if (counter == index)
                {
                    return item;
                }
                counter++;
            }

            throw new ArgumentOutOfRangeException();
        }

        //ElementAt<TSource>(IEnumerable<TSource>, Index) – Возвращает элемент по указанному индексу в последовательности
        public static TSource ElementAt<TSource>(this IEnumerable<TSource> list, Index index)
        {
            if (index.IsFromEnd == true)
            {
                TSource item = list.ElementAt(index.Value);
                return item;
            }
            else
            {
                var newList = list.Reverse();
                TSource item = newList.ElementAt(index.Value);
                return item;
            }
        }

        //ElementAtOrDefault<TSource>(IEnumerable<TSource>, Int32) – Возвращает элемент последовательности
        //по указанному индексу  или значение по умолчанию, если индекс вне допустимого диапазона
        public static TSource ElementAtOrDefault<TSource>(this IEnumerable<TSource> list, int index)
        {
            int counter = 0;
            foreach (var item in list)
            {
                if (counter == index)
                {
                    return item;
                }
                counter++;
            }

            return default;
        }

        //ElementAtOrDefault<TSource>(IEnumerable<TSource>, Index) – Возвращает элемент последовательности
        //по указанному индексу  или значение по умолчанию, если индекс вне допустимого диапазона
        public static TSource ElementAtOrDefault<TSource>(this IEnumerable<TSource> list, Index index)
        {
            if (list.Count() >= index.Value)
            {
                return default;
            }
            else
            {
                return list.ElementAt(index);
            }
        }

        //First<TSource>(IEnumerable<TSource>) – Возвращает первый элемент последовательности
        public static TSource First<TSource>(this IEnumerable<TSource> list)
        {
            foreach (var item in list)
            {
                return item;
            }
            throw new ArgumentNullException();
        }

        //FirstOrDefault<TSource>(IEnumerable<TSource>) – Возвращает первый элемент последовательности
        //или значение по умолчанию, если последовательность не содержит элементов
        public static TSource FirstOrDefault<TSource>(this IEnumerable<TSource> list)
        {
            foreach (var item in list)
            {
                return item;
            }
            return default;
        }

        //Last<TSource>(IEnumerable<TSource>) – Возвращает последний элемент последовательности
        public static TSource Last<TSource>(this IEnumerable<TSource> list)
        {
            int count = 0;
            TSource lastItem = default;

            foreach (var item in list)
            {
                lastItem = item;
            }

            if (count == 0)
            {
                throw new ArgumentNullException();
            }

            return lastItem;
        }

        //LastOrDefault<TSource>(IEnumerable<TSource>) – Возвращает последний элемент последовательности
        //или значение по умолчанию, если последовательность не содержит элементов
        public static TSource LastOrDefault<TSource>(this IEnumerable<TSource> list)
        {
            int count = 0;
            TSource lastItem = default;

            foreach (var item in list)
            {
                lastItem = item;
            }

            if (count == 0)
            {
                return default;
            }

            return lastItem;
        }

        //Max<TSource>(IEnumerable<TSource>) – Возвращает максимальное значение, содержащееся в универсальной последовательности
        public static TSource Max<TSource>(this IEnumerable<TSource> list) where TSource : IComparable
        {
            if (list.Count() == 0)
            {
                throw new ArgumentNullException();
            }

            var maxItem = list.First();
            foreach (var item in list)
            {
                if (item.CompareTo(maxItem) > 0)
                {
                    maxItem = item;
                }
            }

            return maxItem;
        }

        //Min<TSource>(IEnumerable<TSource>) – Возвращает минимальное значение, содержащееся в универсальной последовательности
        public static TSource Min<TSource>(this IEnumerable<TSource> list) where TSource : IComparable
        {
            if (list.Count() == 0)
            {
                throw new ArgumentNullException();
            }

            var minItem = list.First();
            foreach (var item in list)
            {
                if (item.CompareTo(minItem) < 0)
                {
                    minItem = item;
                }
            }

            return minItem;
        }

        //OrderBy<TSource,TKey>(IEnumerable<TSource>, Func<TSource,TKey>) - 
        //Сортирует элементы последовательности в порядке возрастания ключа
        public static IEnumerable<TSource> OrderBy<TSource, TKey>(this IEnumerable<TSource> list, Func<TSource, TKey> f)
        {
            if (list == null || f == null)
            {
                throw new ArgumentNullException();
            }
            var items = list.ToArray();
            var keys = items.Select(f).ToArray();
            Array.Sort(keys, items);
            foreach (var item in items)
            {
                yield return item;
            }
        }

        //OrderByDescending<TSource,TKey>(IEnumerable<TSource>, Func<TSource,TKey>) –
        //Сортирует элементы последовательности в порядке убывания ключа
        public static IEnumerable<TSource> OrederByDescending<TSource, TKey>(this IEnumerable<TSource> list, Func<TSource, TKey> f)
        {
            if (list == null || f == null)
            {
                throw new ArgumentNullException();
            }
            var items = list.ToArray();
            var keys = items.Select(f).Reverse().ToArray();
            Array.Sort(keys, items);
            foreach (var item in items)
            {
                yield return item;
            }
        }

        //Prepend<TSource>(IEnumerable<TSource>, TSource) – Добавляет значение в начало последовательности
        public static IEnumerable<TSource> Prepend<TSource>(this IEnumerable<TSource> list, TSource data)
        {
            var newList = ((CircleList<TSource>)list).MyMemberwiseClone();
            newList.AddFirst(data);
            return newList;
        }

        //Reverse<TSource>(IEnumerable<TSource>) – Изменяет порядок элементов последовательности на противоположный
        public static IEnumerable<TSource> Reverse<TSource>(this IEnumerable<TSource> list)
        {
            if (list.Count() == 0)
            {
                throw new ArgumentNullException();
            }

            IEnumerable<TSource> newList = new CircleList<TSource>();
            TSource newElement = default;
            foreach (var item in list)
            {
                newElement = item;
            }
            newList.Append(newElement);
            TSource lastAppend = newElement;
            int itemsCount = list.Count();

            for (int i = 1; i < itemsCount; i++)
            {
                foreach (var item in list)
                {
                    if (!item.Equals(lastAppend))
                    {
                        newElement = item;
                    }
                    else
                    {
                        newList.Append(newElement);
                        lastAppend = newElement;
                        break;
                    }
                }
            }
            return newList;
        }
    }
}
