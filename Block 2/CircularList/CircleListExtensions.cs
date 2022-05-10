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
