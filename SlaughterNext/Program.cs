using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlaughterNext
{
    class Program
    {
        static void Main(string[] args)
        {

            int warriorsCount = 0;
            int intialExecutorNumber = 0;
            List<Warrior> warriorCollectionTemp = new List<Warrior>();
            IEnumerable<Warrior> warriorCollection;
            Console.Out.WriteLine("Welcome to Slaughter Execution !");
            Console.Out.WriteLine("Enter Number Of Warriors !");
            warriorsCount = int.Parse(Console.ReadLine());

            Console.Out.WriteLine("Enter Intial Warrior Number !");
            intialExecutorNumber = int.Parse(Console.ReadLine());

            for (int i = 1; i <= warriorsCount; i++)
            {
                if (i == 1)
                {
                    warriorCollectionTemp.Add(new Warrior { previousWarriorID = warriorsCount, warriorValue = i, nextWarriorID = i + 1, isCurrentWarrior = false });
                }
                else
                {
                    if (i == warriorsCount)
                    {
                        warriorCollectionTemp.Add(new Warrior { previousWarriorID = i - 1, warriorValue = i, nextWarriorID = 1, isCurrentWarrior = false });
                    }
                    else
                    {
                        warriorCollectionTemp.Add(new Warrior { previousWarriorID = i - 1, warriorValue = i, nextWarriorID = i + 1, isCurrentWarrior = false });
                    }

                }
            }

            warriorCollection = warriorCollectionTemp.ToList();
            Console.Out.WriteLine("Warrior Group");
            foreach (var singleWarrior in warriorCollection)
            {
                Console.Out.WriteLine("{0} -- {1} -- {2}", singleWarrior.previousWarriorID, singleWarrior.warriorValue, singleWarrior.nextWarriorID);
            }
            Console.Out.WriteLine("Slaughter Starts");
            warriorCollection.Where(m => m.warriorValue == intialExecutorNumber).First().isCurrentWarrior = true;
            while (warriorCollection.Where(m => !m.isKilled).Count() > 1)
            {
                // Kill the next warrior

                var currentWarrior = warriorCollection.Where(m => m.isCurrentWarrior).First();
                var nextwarrirorID = currentWarrior.nextWarriorID;
                var successor = warriorCollection.Where(m => m.previousWarriorID == nextwarrirorID).First();
                //Killing the WArrior
                var deadWarrior = warriorCollection.Where(m => m.warriorValue == nextwarrirorID).First();
                deadWarrior.isKilled = true;deadWarrior.previousWarriorID = 0;deadWarrior.nextWarriorID = 0;
                Console.Out.WriteLine("warrior {0} killed  {1}", currentWarrior.warriorValue, nextwarrirorID);
                currentWarrior.nextWarriorID = successor.warriorValue;
                currentWarrior.isCurrentWarrior = false;
                successor.previousWarriorID = currentWarrior.warriorValue;
                successor.isCurrentWarrior = true;
                
            }
            foreach (var singleWarrior in warriorCollection)
            {
                if (!singleWarrior.isKilled)
                {
                    Console.Out.WriteLine("{0} -- {1} -- {2}", singleWarrior.previousWarriorID, singleWarrior.warriorValue, singleWarrior.nextWarriorID);
                }
            }

            Console.Read();
        }
    }

    public class Warrior
    {
        public int previousWarriorID { get; set; }

        public int warriorValue { get; set; }

        public int nextWarriorID { get; set; }

        public bool isCurrentWarrior { get; set; }
        public bool isKilled { get; set; }
    }
}
