//Usage: Put CSV file in a text asset named csvFile, attach this to an object named CSVReader, assign a string[,] array to call CSVReader.rollerCoasterSet()
//Format: date, number of voters, candidate 1 name, candidate 1 percent, ... , candidate 9 name, candidate 9 percent
using UnityEngine;
using System;
using System.Linq;
using System.Collections.Generic;

public class CSVReader : MonoBehaviour
{
	public static string[,] rawGrid;
	public static string[,] rollerCoasterSet;
    public static PollObject[,] candidateSet;
	static string rawData;
	static int lines;
	static int categories = 29;

	void Awake()
	{
        TextAsset csvFile = Resources.Load("statesData") as TextAsset;
        rawData = csvFile.text;
	    makeArray();
	    rollerCoasterGenerator();
        buildCandidateStructure();
        printCS();
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
	public static void rollerCoasterGenerator()
	{
		string[,] daySort;
		string[] dates = new string[lines];
		for (int i = 0; i < lines-1; i++) {
			dates[i] = rawGrid[i, 2];
		}
        rollerCoasterSet = new string[lines - 1, 20];
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
							rollerCoasterSet[i, 0] = rawGrid[j, 2];
							for (int k = 1; k < 20; k++)
							{
                                rollerCoasterSet[i, k] = rawGrid[j, k + 9];
							}
							ignore.Add(j);
							break;
						}
					}
				}
			}
		}
	}
    public static void buildCandidateStructure()
    {
        Dictionary<string, int> nameOccurrences = new Dictionary<string, int>();
        int numAttributes = (rollerCoasterSet.GetUpperBound(1) - 1) / 2;
        for (int i = 0; i <= rollerCoasterSet.GetUpperBound(0); i++)
        {
            //build name occurrence dictionary
            for (int j = 0; j < numAttributes; j++)
            {
                string key = rollerCoasterSet[i, (j + j + 2)];
                if (key != null)
                {
                    if (nameOccurrences.ContainsKey(key))
                    {
                        nameOccurrences[key] += 1;
                    }
                    else
                    {
                        nameOccurrences.Add(key, 1);
                    }
                }
            }
        }
        //build candidate set, of format: all candidates sorted by occurence order, holding one poll object for each occurrence, sorted by datetime
        candidateSet = new PollObject[nameOccurrences.Count, (rollerCoasterSet.GetUpperBound(0) + 1)];
        int candidateIterator = 0;
        foreach (KeyValuePair<string,int> candidate in nameOccurrences.OrderByDescending(key => key.Value))
        {
            int pollIterator = 0;
            for (int i = 0; i <= rollerCoasterSet.GetUpperBound(0); i++)
            {
                string date = rollerCoasterSet[i, 0];
                string numPollers = rollerCoasterSet[i, 1];
                for (int j = 0; j < numAttributes; j++)
                {
                    string name = rollerCoasterSet[i, (j + j + 2)];
					string percent = rollerCoasterSet[i, (j + j + 3)];
                    if (!String.IsNullOrEmpty(name) && !String.IsNullOrEmpty(percent))
                    {
                        if (candidate.Key.Equals(name))
                        {
                            
                            candidateSet[candidateIterator, pollIterator++] = new PollObject(candidate.Key, date, numPollers, percent);
                        }
                    }
                }
            }
            candidateIterator++;
        }
    }
    public static void printCS()
    {
        for (int i = 0; i <= candidateSet.GetUpperBound(0); i++)
        {
            string msg = i + " ";
            for (int j = 0; j <= candidateSet.GetUpperBound(1); j++)
            {
                if (candidateSet[i,j] != null)
                {
                    msg += candidateSet[i, j].name + " " + candidateSet[i, j].date + " ";
                }
            }
            print(msg);
        }
    }
}
