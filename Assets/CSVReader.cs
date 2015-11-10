//Usage: Put CSV file in a text asset named csvFile, attach this to an object named CSVReader, 
//Format: date, number of voters, candidate 1 name, candidate 1 percent, ... , candidate 9 name, candidate 9 percent
using UnityEngine;
using System;
using System.Linq;
using System.Collections.Generic;

public class CSVReader : MonoBehaviour
{
	public static string[,] rawGrid;
	public static string[,] intermediarySet;
    public static PollObject[,] candidateSet;
    public static DateTime[] datesRepresented;
	public static List<Candidate> candidates = new List<Candidate>();
	public static Dictionary<DateTime, Poll> pollByDate = new Dictionary<DateTime, Poll>();
	public static string rawData;
	public static int lines;
	public static int categories;

	void Awake()
	{
        TextAsset csvFile = Resources.Load("statesData") as TextAsset;
        rawData = csvFile.text;
	    makeArray();
        buildCandidateStructure();
        printPolls();
	}
	//Reads data in from CSV file, returns array of raw data, where each row is a line and each column is a category.
	static void makeArray()
	{
		string[] lineData = rawData.Split('\n');
		lines = lineData.Length - 1;
		categories = lineData[1].Count(c => c == ',');
		string[,] arr = new string[lines, categories];
		for (int i = 1; i < lines - 1; i++)
		{
			string[] temp = splitLine(lineData[i]);
			for (int j = 0; j < categories; j++)
			{
				arr[i-1, j] = temp[j];
			}
		}
		rawGrid = arr;
	}
	//Utility used to split a line upon the delimiter ','.
	static string[] splitLine(string line)
	{
		return line.Split(',');
	}
	//Utility used to print out the raw data array.
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
	//Filters out information that is not being used.
	//cmx - Categories - 8 = we are not using eight categories from HP Pollster.
	//Currently not used: 1. Polling Agency 2. Method 3. Source 4. Affiliation 5. Survey Houses 6. Sponsors 7. Questions 10. Voter Stats
	//Returns new array containining only relevant data.
	//Currently relevant data: 1. State 2. End Date 3. Number of Voters 4. Candidate 1 5. Candidate 1 Percent ... N-1. Candidate N N. Candidate N Percent
	static void intermediaryGenerator()
	{
		string[,] daySort;
		string[] dates = new string[lines];
		int cmx = categories - 8;
		for (int i = 0; i < lines-1; i++) {
			dates[i] = rawGrid[i, 2];
		}
		intermediarySet = new string[lines - 1, cmx];
		Array.Sort(dates);
		daySort = new string[lines - 1, cmx];
		List<string> ignore = new List<string>();
		//remove ignore - move functionality for date merge
		for (int i = 0; i < lines - 1; i++)
		{
			for (int j = 0; j < lines - 1; j++)
			{
				if (dates[i] != null && rawGrid[j, 2] != null)
				{
					if (dates[i].Equals(rawGrid[j, 2]))
					{
						if (!ignore.Contains(rawGrid[j, 2]))
						{
							//date, state, numvoters, c, p, c, p ... c, p
							intermediarySet[i, 0] = rawGrid[j, 2];
                            intermediarySet[i, 1] = rawGrid[j, 0];
							for (int k = 2; k < cmx; k++)
							{
                                intermediarySet[i, k] = rawGrid[j, k + 8];
							}
							ignore.Add(rawGrid[j, 2]);
							break;
						}
					}
				}
			}
		}
	}
    static void buildCandidateStructure()
    {
		intermediaryGenerator();
        Dictionary<string, int> nameOccurrences = new Dictionary<string, int>();
        Dictionary<string, int> dateOccurrences = new Dictionary<string, int>();

        int numAttributes = (intermediarySet.GetUpperBound(1) - 1) / 2;
        for (int i = 0; i <= intermediarySet.GetUpperBound(0); i++)
        {
            //build date occurrence dictionary
            string date = intermediarySet[i, 0];
            if (date != null)
            {
                if (dateOccurrences.ContainsKey(date))
                {
                    dateOccurrences[date] += 1;
                }
                else
                {
                    dateOccurrences.Add(date, 1);
                }
            }
            //build name occurrence dictionary
            for (int j = 0; j < numAttributes; j++)
            {
                string key = intermediarySet[i, (j + j + 3)];
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
		int ccc = 0;
		foreach (KeyValuePair<string, int> c in nameOccurrences.OrderByDescending(key => key.Value))
		{
			candidates.Add(new Candidate(c.Key, ccc++));
		}
		for (int i = 0; i <= intermediarySet.GetUpperBound(0); i++)
	    {
				//build poll container, key value pair with key date and value poll occurring on that date
				Score[] scores = new Score[numAttributes];
				for (int j = 0; j < numAttributes-1; j++) {
					var candidate = candidates.FirstOrDefault(c => c.name == intermediarySet[i, (j+j+3)]);
//				print("Num attributes: " + numAttributes);
//				print("J: " + j + " J+J+4: " + (j+j+4));
					string percent = intermediarySet[i, (j + j + 4)];
					if (candidate != null && percent != null) {
						//print (percent);
						if (percent != "")
							scores[j] = new Score(percent, candidate);
					}
				}
				if (intermediarySet[i, 0] != null) {
					Poll poll = new Poll(intermediarySet[i, 1],intermediarySet[i, 0],scores);
					//print (poll.date);
					pollByDate.Add(poll.date, poll);
				}
		}
				        
        //go through and combine same date objects - state overlap? different poll, same state overlap?
        foreach (KeyValuePair<string, int> date in dateOccurrences.OrderByDescending(key => key.Value))
        {

        }

		//foreach (KeyValuePair<DateTime,Poll> poll in 
        //build candidate set, of format: all candidates sorted by occurence order, holding one poll object for each occurrence, sorted by datetime
        /*candidateSet = new PollObject[nameOccurrences.Count, (intermediarySet.GetUpperBound(0) + 1)];
        int candidateIterator = 0;
        foreach (KeyValuePair<string,int> candidate in nameOccurrences.OrderByDescending(key => key.Value))
        {
            int pollIterator = 0;
            for (int i = 0; i <= intermediarySet.GetUpperBound(0); i++)
            {
                string date = intermediarySet[i, 0];
                string state = intermediarySet[i, 1];
                string numPollers = intermediarySet[i, 2];
                for (int j = 0; j < numAttributes; j++)
                {
                    string name = intermediarySet[i, (j + j + 3)];
					string percent = intermediarySet[i, (j + j + 4)];
                    if (!String.IsNullOrEmpty(name) && !String.IsNullOrEmpty(percent))
                    {
                        if (candidate.Key.Equals(name))
                        {
                            
                            candidateSet[candidateIterator, pollIterator++] = new PollObject(candidate.Key, state, date, numPollers, percent);
                        }
                    }
                }
            }
            candidateIterator++;
        }*/
    }
	public static void printPolls() {
		foreach (KeyValuePair<DateTime, Poll> poll in pollByDate)
		{
			string msg = poll.Value.date + " " + poll.Value.state;
			for (int i = 0; i < poll.Value.scores.Length; i++) {
				if (poll.Value.scores[i] != null)
					msg += " " + poll.Value.scores[i].candidate.name + " " + poll.Value.scores[i].percent;
			}
			print(msg);
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
                    msg += candidateSet[i, j].name + " " + candidateSet[i, j].date + " " + candidateSet[i,j].percent + " ";
                }
            }
            print(msg);
        }
    }
}
