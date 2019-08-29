using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_DiagramBuilder
{
    class NodeComparer : Comparer<Node>
    {
        public override int Compare(Node x, Node y)
        {
            if (x.value > y.value)
                return -1;
            else if (x.value < y.value)
                return 1;
            return 0;
        }
    }
}
