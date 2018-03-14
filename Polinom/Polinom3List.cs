using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polinom
{
    public class Polinom3List
    {
        //private int count = 0;
        Node Root;
        Node Tail;

        public Polinom3List()
        {
            Root = null;
            Tail = null;
        }

        public Polinom3List(string file)
        {
            var cd = file.Split(' ');
            Summand summand = new Summand(int.Parse(cd[0]), int.Parse(cd[1]), int.Parse(cd[2]), int.Parse(cd[3]));
            Root = new Node(summand);
            var current = Root;
            var currentPrevios = Root;

            for (int i = 4; i < cd.Length; i += 4)
            {
                summand = new Summand(int.Parse(cd[i]), int.Parse(cd[i + 1]), int.Parse(cd[i + 2]), int.Parse(cd[i + 3]));
                current = new Node(summand);
                Tail = current;
                currentPrevios.next = current;
                currentPrevios = current;
                current = current.next;
            }
        }




        public override String ToString()
        {
            StringBuilder polinom = new StringBuilder();
            Node current = Root;
            while (current != null & current.next != null)
            {
                if (current.next != null)
                {
                    polinom.Append(current.value).Append(" + ");
                    current = current.next;
                }
            }

            polinom.Remove((polinom.Length - 3), 3);
            return polinom.ToString();
        }

        //inserting an element
        public void Insert(int coef, int degX, int degY, int degZ)
        {
            Summand summand = new Summand(coef, degX, degY, degZ);
            Node node = new Node(summand);
            Node CurrentNode = Root;

            if (Root == null)
            {
                Root = node;
            }
            else
            {
                while (CurrentNode.next != null && Compare(node.value, CurrentNode.value) < 0)
                {
                    CurrentNode = CurrentNode.next;
                }
                int compareValue = Compare(node.value, CurrentNode.value);
                if (compareValue == 0)//если мономы совпали,то заменить. а если только степени, но не коэффициенты совпали?
                {
                    CurrentNode.value.coef = coef;
                }
                else
                {
                    if (CurrentNode == Root)
                    {
                        if (compareValue < 0)
                        {
                            node.next = Root.next;
                            Root.next = node;
                        }
                        else
                        {
                            Summand value = Root.value;
                            Root.value = node.value;
                            node.value = value;
                            node.next = Root.next;
                            Root.next = node;
                        }
                    }
                    else
                    {
                        if (compareValue < 0)
                        {
                            node.next = CurrentNode.next;
                            CurrentNode.next = node;
                        }
                        else
                        {
                            Summand value = CurrentNode.value;
                            CurrentNode.value = node.value;
                            node.value = value;
                            node.next = CurrentNode.next;
                            CurrentNode.next = node;
                        }
                    }
                }
            }
        }

        //comparison of terms
        private int Compare(Summand a, Summand b)
        {
            if (a.degs[0] == b.degs[0])
            {
                if (a.degs[1] == b.degs[1])
                {
                    return a.degs[2] - b.degs[2];
                }

                return a.degs[1] - b.degs[1];
            }

            return a.degs[0] - b.degs[0];
        }

        //removing an item
        public void Delete(int deg1, int deg2, int deg3)
        {

            Node node = Root;
            while (node.next != null) //maybe node.next
            {
                if (ComparisonOfDegrees(node, deg1, deg2, deg3))
                {
                    Summand value = node.value;
                    node.value = node.next.value;
                    node.next.value = value;
                    node.next = node.next.next;
                    break;
                }
                node = node.next;
            }
        }

        //polynomial calculation
        public int Value(int x, int y, int z)
        {
            int sum = 0;
            Node current = Root;
            while (current != null)
            {
                sum += current.value.coef * current.value.SummandValue(x, y, z);
                current = current.next;
            }

            return sum;
        }

        //partial differential calculation
        public void Derivate(int i)
        {
            Node current = Root;
            while (current != null)
            {
                current.value.coef *= current.value.degs[i];
                current.value.degs[i]--;
                current = current.next;
            }

            Console.WriteLine();
        }

        //addition of a polynomial to a polynomial
        public void Add(Polinom3List p2)
        {             
            Node current = p2.Root;
            while (current != null)
            {
                Insert(current.value.coef, current.value.degs[0], current.value.degs[1], current.value.degs[2]);
                current = current.next;
            }
        }

        //auxiliary method of comparison of degrees
        private bool ComparisonOfDegrees(Node n, int deg1, int deg2, int deg3)
        {
            return (n.value.degs[0] == deg1 && n.value.degs[1] == deg2 && n.value.degs[2] == deg3);
        }
    }
}
