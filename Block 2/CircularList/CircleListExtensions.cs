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
            foreach(var item in source)
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
        public static void Append<TSource>(this IEnumerable<TSource> source, TSource data)
        {

        }
    }
}
