using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TestConsoleReadFile
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Donnez le chemin d'accès du fichier map : ");
            StreamReader sr = new StreamReader(Console.ReadLine());
            string text = sr.ReadToEnd();
            int iTemp = 0;
            int returnText;

            for (int i = 0; i < text.Length; i++)
            {
                returnText = 0;
                if (text[i] == ' ')
                {
                    for (int j = iTemp; j < i; j++)
                    {
                        if (j < i - 1)
                        {
                            returnText += j;
                            returnText = returnText * 10;
                        }
                        else
                        {
                            returnText += j;
                        }
                    }
                }
                iTemp = text[i];
                Console.WriteLine(returnText);
            }

            sr.Close();
            Console.ReadLine();
        }
    }
}
