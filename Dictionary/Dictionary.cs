using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Dictionary
{
    class Dictionary
    {
        private string filesPath;
        string[] files;
        StreamWriter saver;
        List<string> collection;

        public Dictionary(string filesPath)
        {
            this.filesPath = filesPath;
            files = Directory.GetFiles(filesPath);
            collection = new List<string>();
        }

        public void SaveDictionary(string path)
        {
            saver = new StreamWriter(path);

            foreach (var file in files)
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(file);

                XmlNodeList elemList = doc.GetElementsByTagName("p");

                foreach (XmlNode elem in elemList)
                {
                    foreach (var word in GetWords(elem.InnerText))
                    {
                        collection.Add(word.ToLower());
                    }
                }
            }

            collection = collection.Distinct().ToList();
            collection.Sort();

            foreach (var str in collection)
            {
                saver.WriteLine(str);
            }

            saver.Close();

            Console.WriteLine("Done");

        }

        private string[] GetWords(string input)
        {
            MatchCollection matches = Regex.Matches(input, @"\w+");

            var words = from m in matches.Cast<Match>()
                        where !string.IsNullOrEmpty(m.Value)
                        select m.Value;

            return words.ToArray();
        }

    }
}
