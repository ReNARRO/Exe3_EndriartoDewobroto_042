using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exe3_EndriartoDewobroto_042
{
    class Node
    {
        //create nodes for the circular nexted list
        public int StudentNumber;
        public string StudentName;
        public Node next;
    }
    class CircularList
    {
        Node LAST;
        public CircularList()
        {
            LAST = null;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
