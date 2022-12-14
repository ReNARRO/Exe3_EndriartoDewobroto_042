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
            previous = LAST.next;
            current = LAST.next;
            while ((current != null) && (nim >= current.StudentNumber))
            {
                if(nim == current.StudentNumber)
                {
                    Console.WriteLine();
                    return ;
                }
                previous.next = current;
                previous.next = newNode;
            }
            newNode.next = LAST.next;
            LAST.next = newNode;
        }
        public void delNode(int studentNo)
        {
            Node previous, current;
            previous = current = null;
            if (Search(studentNo, ref previous, ref current) == false)
                return false;
            if (studentNo == LAST.next.StudentNumber)
            {
                current = LAST.next;
                LAST.next = current.next;
                return true;
            }

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
        public bool listEmpty()
        {
            if(LAST == null)
                return true ;
            else
                return false ;
        }
        public void traverse()//Traverses all the nodes of the list
        {
            if (listEmpty())
                Console.WriteLine("\nList is empty");
            else
            {
                Console.WriteLine("\nRecords in the list are: \n");
                Node currentNode;
                currentNode = LAST.next;
                while (currentNode != LAST)
                {
                    Console.Write(currentNode.StudentNumber +
                        "       " + currentNode.StudentName + "\n");
                    currentNode = currentNode.next;
                }
                Console.Write(LAST.StudentNumber + "     " + LAST.StudentName + "\n");
            }
        }
        public void firstNode()
        {
            if (listEmpty())
                Console.WriteLine("\nList is empty");
            else
                Console.WriteLine("\nThe first record in the list is: \n\n" +
                    LAST.next.StudentNumber + "      " + LAST.next.StudentName);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            CircularList obj = new CircularList();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("1. Add a record to the list");
                    Console.WriteLine("2. Delete a record from the list");
                    Console.WriteLine("3. View all the records in the list");
                    Console.WriteLine("4. Search for records in the list");
                    Console.WriteLine("5. Display the first record in the list");
                    Console.WriteLine("6. Exit\n");
                    Console.WriteLine("\nEnter your choice (1-6): ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.addnode();
                            }
                            break;
                        case '2':
                            {
                                if (obj.listEmpty())
                                {
                                    Console.WriteLine("\nList is empty");
                                    break;
                                }
                                Console.Write("Enter the roll number of the student" + "whose record is to be deleted: ");
                                int StudentNo = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (obj.deleteNode(StudentNo) == false)
                                    Console.WriteLine("record not found");
                                else
                                    Console.WriteLine("Record with roll number" + StudentNo + "deleted\n");
                            }
                            break;
                        case '3':
                            {
                                obj.traverse();
                            }
                            break;
                        case '4':
                            {
                                if(obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\nList is empty");
                                    break;
                                }
                                Node prev, curr;
                                prev = curr = null;
                                Console.Write("\nEnter the roll number of the student whose record you want to search: ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if(obj.Search(num, ref prev, ref curr) == false)
                                    Console.WriteLine("\nRecord not found");
                                else
                                {
                                    Console.WriteLine("\nRecord found");
                                    Console.WriteLine("\nRoll number: " + curr.StudentNumber);
                                    Console.WriteLine("\nName: " + curr.StudentName);
                                }

                            }
                            break ;
                        case '5':
                            {
                                obj.firstNode();
                            }
                            break;
                        case '6':
                            return;
                        default:
                            {
                                Console.WriteLine("Invalid option");
                                break ;
                            }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
    }
}
