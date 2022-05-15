using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircularList
{
    internal class CircleList<T> : IEnumerable<T> where T : IComparable
    {
        public CircleListNode<T> First;
        public CircleListNode<T> Last;
        private int count;
        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }

        public CircleList() { }
        
        public CircleList(IEnumerable<T> list)
        {
            count = 0;
            foreach (var item in list)
            {
                AddLast(item);
            }
        }

        //AddAfter(CircleListNode<T>, CircleListNode<T>) – Добавляет заданный новый узел
        //после заданного существующего узла в CircleList<T>
        //Если заданного узла не существует, или список пуст, то ничего не происходит
        public bool AddAfter(CircleListNode<T> afterNode, CircleListNode<T> newNode)
        {
            CircleListNode<T> current = First;

            if (current == null) return false;
            do
            {
                if (current.Data.Equals(afterNode.Data))
                {
                    if (current == Last)
                    {
                        newNode.Next = First;
                        Last.Next = newNode;
                        Last = newNode;
                        count++;
                        return true;
                    }
                    else
                    {
                        newNode.Next = current.Next;
                        current.Next = newNode;
                        count++;
                        return true;
                    }
                }
                current = current.Next;
            }
            while (current != First);
            return false;
        }

        //AddAfter(CircleListNode<T>, T) – Добавляет новый узел,
        //содержащий заданное значение, после заданного существующего узла в CircleList<T>
        //Если заданного узла не существует, или список пуст, то ничего не происходит
        public void AddAfter(CircleListNode<T> afterNode, T data)
        {
            CircleListNode<T> newNode = new CircleListNode<T>(data);
            AddAfter(afterNode, newNode);
        }

        //AddBefore(CircleListNode<T>, CircleListNode<T>) – Добавляет заданный новый узел
        //перед заданным существующим узлом в CircleList<T>
        //Если заданного узла не существует, или список пуст, то ничего не происходит
        public bool AddBefore(CircleListNode<T> beforeNode, CircleListNode<T> newNode)
        {
            CircleListNode<T> current = First;
            CircleListNode<T> previous = null;

            if (current == null) return false;
            do
            {
                if (current.Data.Equals(beforeNode.Data))
                {
                    if (current == First)
                    {
                        newNode.Next = current;
                        First = newNode;
                        Last.Next = newNode;
                        count++;
                        return true;
                    }
                    else
                    {
                        newNode.Next = previous.Next;
                        previous.Next = newNode;
                        count++;
                        return true;
                    }
                }
                previous = current;
                current = current.Next;
            }
            while (current != First);
            return false;
        }

        //AddBefore(CircleListNode<T>, T) – Добавляет новый узел,
        //содержащий заданное значение, перед заданным существующим узлом в CircleList<T>
        //Если заданного узла не существует, или список пуст, то ничего не происходит
        public void AddBefore(CircleListNode<T> beforeNode, T data)
        {
            CircleListNode<T> newNode = new CircleListNode<T>(data);
            AddBefore(beforeNode, newNode);
        }

        //AddFirst(CircleListNode<T>) – Добавляет заданный
        //новый узел в начало CircleList<T>
        public void AddFirst(CircleListNode<T> newNode)
        {
            if (First == null)
            {
                First = newNode;
                Last = newNode;
                Last.Next = First;
            }
            else
            {
                newNode.Next = First;
                First = newNode;
                Last.Next = newNode;
            }
            count++;
        }

        //AddFirst(T) – Добавляет новый узел, содержащий
        //заданное значение, в начало CircleList<T>
        public void AddFirst(T data)
        {
            CircleListNode<T> newNode = new CircleListNode<T>(data);
            AddFirst(newNode);
        }

        //AddLast(CircleListNode<T>) – Добавляет заданный новый узел в конец CircleList<T>
        public void AddLast(CircleListNode<T> newNode)
        {
            if (First == null)
            {
                First = newNode;
                Last = newNode;
                Last.Next = First;
            }
            else
            {
                newNode.Next = First;
                Last.Next = newNode;
                Last = newNode;
            }
            count++;
        }

        //AddLast(T) – Добавляет новый узел, содержащий
        //заданное значение, в конец CircleList<T>
        public void AddLast(T data)
        {
            CircleListNode<T> newNode = new CircleListNode<T>(data);
            AddLast(newNode);
        }

        //Clear() – Удаляет все узлы из CircleList<T>
        public void Clear()
        {
            First = null;
            Last = null;
            count = 0;
        }

        //Contains(T) – Определяет, принадлежит ли значение объекту CircleList<T>
        public bool Contains(T data)
        {
            CircleListNode<T> current = First;

            if (current == null) return false;
            do
            {
                if (current.Data.Equals(data))
                {
                    return true;
                }
                current = current.Next;
            }
            while (current != First);
            return false;
        }

        //Equals(Object) – Определяет, равен ли указанный
        //объект текущему объекту. (Унаследовано от Object)
        public bool Equals(Object obj)
        {
            CircleList<T> list;
            list = (CircleList<T>)obj;

            var current = list.First;
            foreach (var item in this)
            {
                if (current.Data.CompareTo(item) != 0)
                {
                    return false;
                }
            }
            return true;
        }

        //Find(T) – Находит первый узел, содержащий указанное значение.
        //Если такого узла нет, или список пуст, ничего не происходит.
        public CircleListNode<T> Find(T data)
        {
            CircleListNode<T> current = First;

            if (current == null) return null;
            do
            {
                if (current.Data.Equals(data))
                {
                    return current;
                }
                current = current.Next;
            }
            while (current != First);
            return null;
        }

        //FindLast(T) – Находит последний узел, содержащий указанное значение.
        //Если такого узла нет, или список пуст, ничего не происходит.
        public CircleListNode<T> FindLast(T data)
        {
            CircleListNode<T> returnNode = null;
            CircleListNode<T> current = First;

            if (current == null) return null;
            do
            {
                if (current.Data.Equals(data))
                {
                    returnNode = current;
                }
                current = current.Next;
            }
            while (current != First);
            if (returnNode != null)
            {
                return returnNode;
            }
            else
            {
                return null;
            }
        }

        //GetType() - Возвращает объект Type для текущего экземпляра.
        public Type ListGetType()
        {
            return this.GetType();
        }

        //MemberwiseClone() – Создает неполную копию текущего объекта Object. (Унаследовано от Object)
        public CircleList<T> MyMemberwiseClone()
        {
            var list = (object)this;
            return (CircleList<T>)list;
        }

        //Remove(CircleListNode<T>) – Удаляет заданный узел из объекта CircleList<T>
        public bool Remove(CircleListNode<T> node)
        {
            CircleListNode<T> current = First;
            CircleListNode<T> previous = null;

            if (IsEmpty) return false;

            do
            {
                if (current.Equals(node))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;
                        if (current == Last)
                        {
                            Last = previous;
                        }
                    }
                    else
                    {
                        if (count == 1)
                        {
                            First = Last = null;
                        }
                        else
                        {
                            Last.Next = current.Next;
                            First = current.Next;
                        }
                    }
                    count--;
                    return true;
                }
                previous = current;
                current = current.Next;
            }
            while (current != First);
            return false;
        }

        //Remove(T) – Удаляет первое вхождение заданного значения из CircleList<T>.
        //Если заданного узла не существует, ничего не происходит.
        public bool Remove(T data)
        {
            CircleListNode<T> current = First;
            CircleListNode<T> previous = null;

            if (IsEmpty) return false;

            do
            {
                if (current.Data.Equals(data))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;
                        if (current == Last)
                        {
                            Last = previous;
                        }
                    }
                    else
                    {
                        if (count == 1)
                        {
                            First = Last = null;
                        }
                        else
                        {
                            Last.Next = current.Next;
                            First = current.Next;
                        }
                    }
                    count--;
                    return true;
                }
                previous = current;
                current = current.Next;
            }
            while (current != First);
            return false;
        }

        //RemoveFirst()	– Удаляет узел в начале CircleList<T>
        public void RemoveFirst()
        {
            if (IsEmpty) return;
            else
            {
                Last.Next = First.Next;
                First = First.Next;
                count--;
            }
        }

        //RemoveLast()	– Удаляет узел в конце CircleList<T>
        public void RemoveLast()
        {
            CircleListNode<T> current = First;
            CircleListNode<T> previous = null;

            if (IsEmpty) return;
            else
            {
                while (current != Last)
                {
                    previous = current;
                    current = current.Next;
                }
                previous.Next = First;
                Last = previous;
                count--;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            CircleListNode<T> current = First;
            do
            {
                if (current != null)
                {
                    yield return current.Data;
                    current = current.Next;
                }
            }
            while (current != First);
        }
    }
}