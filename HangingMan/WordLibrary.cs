using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HangingMan
{
    public class WordLibrary
    {
        static string[] ReadWordsFromFile()
        {
            return File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "words.txt"));
        }
    }
}
