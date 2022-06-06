using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BashAnalogue
{
    internal class KeyValue<Key, Value>
    {
        public Key Id { get; set; }
        public Value Text { get; set; }

        public KeyValue() { }

        public KeyValue(Key key, Value val)
        {
            this.Id = key;
            this.Text = val;
        }
    }
}
