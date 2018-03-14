using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polinom
{
    public class Node
    {
        public Summand value;
        public Node next;

        public Node(Summand value)
        {
            this.value = value;
        }
    }
}
