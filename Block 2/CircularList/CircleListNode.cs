using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircularList
{
    internal class CircleListNode<T>
    {
        public CircleListNode(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public CircleListNode<T> Next { get; set; }
    }
}
