using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    class Program
    {
        const string FILES_PATH = @"C:\Users\Alex\Desktop\Books";
        const string SAVE_DESTINATION = @"C:\Users\Alex\Desktop\dictionary.txt";

        static void Main(string[] args)
        {
            Dictionary d = new Dictionary(FILES_PATH);

            var watch = System.Diagnostics.Stopwatch.StartNew();

            d.SaveDictionary(SAVE_DESTINATION);

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            Console.WriteLine(elapsedMs / 1000.0 + "s");
        }
    }
}
