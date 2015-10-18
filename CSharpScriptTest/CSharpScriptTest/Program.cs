using System;
using System.IO;
using System.Collections.Generic;

namespace CSharpScriptTest
{
    //public class CSVReader : MonoBehaviour
    public class Program
    {
        static string[,] rawGrid;
        static string rawData;
        static int lines;
        static int categories = 29;
        /*public TextAsset csvFile;

        public void Awake()
        {
            rawData = csvFile.text;
            makeArray();
        }*/

        static int Main(String[] args)
        {
            string path = "statesData.csv";
            if (File.Exists(path))
            {
                rawData = File.ReadAllText(path);
                makeArray();
                //debugRawOutput();
                string[,] test = rollerCoasterSet();
                for (int i = 0; i <= test.GetUpperBound(0); i++)
                {
                    for (int j = 0; j <= test.GetUpperBound(1); j++)
                    {
                        Console.Write(test[i, j] + " ");
                    }
                    Console.WriteLine();
                }
            }
            else
                Console.WriteLine("File not found");
            return 0;
        }
        static public void makeArray()
        {
            string[] lineData = rawData.Split('\n');
            lines = lineData.Length - 1;
            string[,] arr = new string[lines, categories];
            for (int i = 1; i < lines - 1; i++)
            {
                string[] temp = splitLine(lineData[i]);
                for (int j = 0; j < categories - 1; j++)
                {
                    arr[i-1, j] = temp[j];
                }
            }
            rawGrid = arr;
        }
        static public string[] splitLine(string line)
        {
            return line.Split(',');
        }
        static public void debugRawOutput()
        {
            for (int i = 0; i < lines; i++)
            {
                for (int j = 0; j < categories; j++)
                {
                    Console.Write(rawGrid[i,j]+", ");
                }
                Console.WriteLine();
            }
        }
        static public string[,] rollerCoasterSet()
        {
            string[,] daySort;
            string[] dates = new string[lines];
            for (int i = 0; i < lines-1; i++) {
                dates[i] = rawGrid[i, 2];
            }
            Array.Sort(dates);
            //daySort = new string[(dates.Distinct().Count()), 20];
            daySort = new string[lines - 1, 20];
            List<int> ignore = new List<int>();
            for (int i = 0; i < lines - 1; i++)
            {
                for (int j = 0; j < lines - 1; j++)
                {
                    if (dates[i] != null && rawGrid[j, 2] != null)
                    {
                        if (dates[i].Equals(rawGrid[j, 2]))
                        {
                            if (!ignore.Contains(j))
                            {
                                daySort[i, 0] = rawGrid[j, 2];
                                for (int k = 1; k < 20; k++)
                                {
                                    daySort[i, k] = rawGrid[j, k + 9];
                                }
                                ignore.Add(j);
                                break;
                            }
                        }
                    }
                }
            }
            return daySort;
        }
    }
}
