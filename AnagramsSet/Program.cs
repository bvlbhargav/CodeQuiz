using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AnagramsSet
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hi !");
            Console.WriteLine("Program will display list of words in the file");

            string fileName = "words_alpha.txt";
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", fileName);
            var strContent = "";

            //Read text file from the provided URL
            var webRequest = WebRequest.Create(path);
            using (var response = webRequest.GetResponse())
            using (var content = response.GetResponseStream())
            using (var reader = new StreamReader(content))
            {
                strContent = reader.ReadToEnd();
            }

            //Splitting string into the words and pushing it to List
            var wordsCollection = strContent.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None).ToList();

            //Displaying count and all the words 
            Console.WriteLine("Numbe rof words are {0}", wordsCollection.Count);
            int i = 1;
            foreach (var word in wordsCollection)
            {
                Console.WriteLine("{0} : {1}", i, word);
                i++;
            }
            Console.Read();
        }
    }
}
