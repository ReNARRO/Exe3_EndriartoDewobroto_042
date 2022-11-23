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
        public void addnode()
        {
            int nim;
            string nm;
            Console.WriteLine("\nEnter the roll number of the student: ");
            nim = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nEnter the name of the student: ");
            nm = Console.ReadLine();
            Node newNode = new Node();
            newNode.StudentNumber = nim;
            newNode.StudentName = nm;

            //Check if the list empty
            if (LAST == null || nim <= LAST.StudentNumber)
            {
                if ((LAST != null) && (nim == LAST.StudentNumber))
                {
                    Console.WriteLine();
                    return;
                }
                newNode.next = LAST;
                LAST = newNode;
                return;
            }
            Node previous, current;


        }
        //Searches for the specified node
        public bool Search(int nim, ref Node previous, ref Node current)
        {
            for (previous = current = LAST.next; current != LAST; previous = 
                current, current = current.next)
            {
                if(nim == current.StudentNumber)
                    return(true);//return if the node id found 
            }
            if(nim == LAST.StudentNumber)
                return true;//if the node is present at the end
            else
                return false;//returns dalse if the node is not found
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
