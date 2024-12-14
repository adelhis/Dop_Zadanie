using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domashka
{
    internal class QueueZina
    {
        private Stack<Zhitel> queue = new Stack<Zhitel>();
        public void AddToStack(Zhitel zh)
        {
            queue.Push(zh); 
        }

        private Queue<Zhitel> queueProb1 = new Queue<Zhitel>();
        private Queue<Zhitel> queueProb2 = new Queue<Zhitel>();
        private Queue<Zhitel> queueProb3 = new Queue<Zhitel>();
        
        private Random rand = new Random();
        public void Raspred()
        {
            while (queue.Count > 0)
            {
                Zhitel zhitel = queue.Pop();

                if (zhitel.temp.mind == 0)
                {
                    byte n = (byte)rand.Next(1, 4);
                    Console.WriteLine(n);
                    AddToQueue(zhitel, n);
                }
                else
                {
                    if (zhitel.temp.scan >= 5)
                    {
                        if (zhitel.numProb == 1)
                        {
                            AddToQueueScan(queueProb1, zhitel);
                        }
                        else if (zhitel.numProb == 2)
                        {
                            AddToQueueScan(queueProb2, zhitel);
                        }
                        else if (zhitel.numProb == 3)
                        {
                            AddToQueueScan(queueProb3, zhitel);
                        }
                    }
                    else
                    {
                        AddToQueue(zhitel, zhitel.numProb);
                    }
                }
            }
        }
        public void AddToQueue(Zhitel zh, byte num)
        {
            if (num == 1)
            {
                queueProb1.Enqueue(zh);
            }
            else if (num == 2)
            {
                queueProb2.Enqueue(zh);
            }
            else if (num == 3)
            {
                queueProb3.Enqueue(zh);
            }
        }
        public void AddToQueueScan(Queue<Zhitel> qu, Zhitel zh)
        {
            List<Zhitel> list= new List<Zhitel>(qu);
            qu.Clear();
            qu.Enqueue(zh);
            foreach (Zhitel zhi in list)
            {
                qu.Enqueue(zhi);
            }
        }
        public void InfoQueues()
        {
            Console.WriteLine("\n Очередь к окну 1: ");
            foreach (Zhitel i in queueProb1)
            {
                i.InfoPrint();
            }
            Console.WriteLine("\n Очередь к окну 2: ");
            foreach (Zhitel i in queueProb2)
            {
                i.InfoPrint();
            }
            Console.WriteLine("\n Очередь к окну 3: ");
            foreach (Zhitel i in queueProb3)
            {
                i.InfoPrint();
            }
        }

    }
}
