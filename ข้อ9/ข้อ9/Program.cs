using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ข้อ9
{
    class Program
    {
        static void AddNode(ref Node node)
        {                       
                Console.WriteLine("Input skill name :");
                string Skillname = Console.ReadLine();
                Console.WriteLine("Add dependency for {0}? (Y/N)", Skillname);
                char answer = char.Parse(Console.ReadLine());


                if (answer == 'Y')
                {
                    string message = Console.ReadLine();
                    node = new QuestionNode(message);
                    AddNode(ref (node as QuestionNode).Left);
                    AddNode(ref (node as QuestionNode).Right);

                    Console.WriteLine("Add dependency for {0}? (Y/N)", Skillname);
                    answer = char.Parse(Console.ReadLine());
                }
                else if (answer == 'N')
                {
                    Console.WriteLine("Add dependency for {0}? (Y/N)", Skillname);
                    answer = char.Parse(Console.ReadLine());

                    Console.WriteLine("Input skill name :");
                    string message = Console.ReadLine();
                    node = new DeceaseNode(message);
                }            
        }
       static void Main(string[] args)
        {
            Node root = null;
            AddNode(ref root);

            Node ptr = root;
            while (true)
            {
                Console.WriteLine(ptr.Message);
                if (ptr is QuestionNode)
                {
                    char answer = char.Parse(Console.ReadLine());
                    if (answer == 'Y')
                    {
                        ptr = (ptr as QuestionNode).Left;
                    }
                    else
                    {
                        ptr = (ptr as QuestionNode).Right;
                    }
                }
                else
                {
                    break;
                }
            }
        }
    }

    class Node
    {
        public string Message;

        public Node(string messageValue)
        {
            Message = messageValue;
        }
    }

    class QuestionNode : Node
    {
        public Node Left;
        public Node Right;

        public QuestionNode(string messageValue) : base(messageValue) { }
    }
    class DeceaseNode : Node
    {
        public DeceaseNode(string messageValue) : base(messageValue) { }
    }
}
