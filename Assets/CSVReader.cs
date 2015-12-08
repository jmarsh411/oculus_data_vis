//Usage: Put CSV file in a text asset named csvFile, attach this to an object named CSVReader, 
//Format: date, number of voters, candidate 1 name, candidate 1 percent, ... , candidate 9 name, candidate 9 percent
//Data is read in to string rawData. It is then accessed by makeArray to make it into rawGrid. intermediaryGenerator
//takes this raw set and removes all unused information, handling merging as well, to build intermerdiaryCoaster and
//intermediaryMap. buildCandidateStructure then takes the processed data and builds the complete usable data in
//proper format for both visualizations: pollByDate for map, including states, and pollByDate for coaster, excluding
//states.
using UnityEngine;
using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class CSVReader : MonoBehaviour
{
	public static string[,] rawGrid;
	public static string[,] intermediarySet;
	public static string[,] intermediaryCoaster;
	public static string[,] intermediaryMap;
    public static PollObject[,] candidateSet;
    public static DateTime[] datesRepresented;
	public static List<Candidate> candidates;
	public static Dictionary<DateTime, List<Poll>> pollByDate;
	public static Dictionary<DateTime, Poll> pollByDateCoaster;
	public static string rawData;
	public static int lines;
	public static int categories;
	public static string[] topThreeCandidates = new string[3];

	void Awake()
	{
        TextAsset csvFile = Resources.Load("statesData") as TextAsset;
        rawData = csvFile.text;
		init ();
	}

	static void clear() {
		rawData = null;
		rawGrid = null;
		intermediarySet = null;
		intermediaryCoaster = null;
		intermediaryMap = null;
		candidateSet = null;
		datesRepresented = null;
		candidates = null;
		pollByDate = null;
		pollByDateCoaster = null;
		lines = 0;
		categories = 0;
		Candidate.candidateList = null;
	}

	static void init() {
		print ("!!!!!!!!!!!!");
		candidates = new List<Candidate>();
		pollByDate = new Dictionary<DateTime, List<Poll>> ();
		pollByDateCoaster = new Dictionary<DateTime, Poll> ();
		Candidate.candidateList = new Dictionary<string, Candidate> ();
		Candidate.setupColors ();
		makeArray();
		intermediaryGenerator();
		buildCandidateStructure();
	}

	public static void parse(string path) {
		//print (path);
		try {
			StreamReader reader = new StreamReader (path, Encoding.Default);
			clear ();
			using (reader) {
				rawData += reader.ReadToEnd();
			}
			reader.Close ();
			init ();
		}
		catch (Exception e) {
			print ("error loading file: " + e);
		}
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
		string[] dates = new string[lines];
		int cmx = categories - 8;
		for (int i = 0; i < lines-1; i++) {
			dates[i] = rawGrid[i, 2];
		}
		intermediarySet = new string[lines - 1, cmx];
		Array.Sort(dates);
		List<int> ignore = new List<int>();
		//Arranges intermediarySet by sorted date.
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
							//date, state, numvoters, c, p, c, p ... c, p
							intermediarySet[i, 0] = rawGrid[j, 2];
                            intermediarySet[i, 1] = rawGrid[j, 0];
							for (int k = 2; k < cmx; k++)
							{
                                intermediarySet[i, k] = rawGrid[j, k + 8];
							}
							ignore.Add(j);
							break;
						}
					}
				}
			}
		}
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


		//build candidate list
		int ccc = 0;
		int topt = 0;
		foreach (KeyValuePair<string, int> c in nameOccurrences.OrderByDescending(key => key.Value))
		{
			if (!c.Key.Equals("") && topt < 3) {
				topThreeCandidates[topt++] = c.Key;
				//print (c.Key + " " + c.Value);
			}
			Candidate addCan = new Candidate(c.Key, ccc++);
			candidates.Add(addCan);
			//print ("Candidate " + addCan.candNum + ": " + addCan.name + " " + addCan.color);

		}
		//get total poll listing - for map, this is summation of dateOccurrence values, for rollercoaster, length of dateOccurrence
		int totalPolls = 0;
		foreach (KeyValuePair<string, int> d in dateOccurrences.OrderByDescending(key => key.Value)) {
			totalPolls += d.Value;
		}
		//build intermediaryMap
		intermediaryMap = new string[totalPolls, cmx];
		int iMCur = 0;
		foreach (KeyValuePair<string, int> d in dateOccurrences.OrderByDescending(key => key.Value)) {	
			Dictionary<string, List<int>> stateLookup = new Dictionary<string, List<int>>();
			for (int i = 0; i <= intermediarySet.GetUpperBound(0); i++) {
				string date = intermediarySet[i, 0];
				string state = intermediarySet[i, 1];
				if (date != null & state != null) {
					if (date.Equals(d.Key)) {
						if (stateLookup.ContainsKey(state)) {
							stateLookup[state].Add(i);
						}
						else {
							List<int> locs = new List<int>();
							locs.Add(i);
							stateLookup.Add(state, locs);
						}
					}
				}
			}
			Dictionary<string, int> cands = new Dictionary<string, int>();
			foreach (KeyValuePair<string, List<int>> s in stateLookup) {
				int tVoters = 0;
				foreach (int loc in s.Value) {
					int voters = Int32.Parse(intermediarySet[loc, 2]);
					tVoters += voters;
					for (int j = 0; j < numAttributes-1; j++)
					{
						string cand = intermediarySet[loc, (j + j + 3)];
						string percent = intermediarySet[loc, (j + j + 4)];
						if (cand != null && percent != null && percent != "")
						{
							int perc = Int32.Parse(percent); 
							if (cands.ContainsKey(cand))
							{
								cands[cand] += ((perc * voters) / 100);
							}
							else
							{
								cands.Add(cand, ((perc * voters) / 100));
							}
						}
					}
				}
				intermediaryMap[iMCur, 0] = d.Key;
				intermediaryMap[iMCur, 1] = s.Key;
				intermediaryMap[iMCur, 2] = tVoters.ToString();
				int nACur = 0;
				foreach (KeyValuePair<string, int> c in cands.OrderByDescending(key => key.Value)) {
					if (nACur < numAttributes-1) {
						intermediaryMap[iMCur, (nACur + nACur + 3)] = c.Key;
						intermediaryMap[iMCur, (nACur + nACur + 4)] = c.Value.ToString();
						nACur++;
					}
				}
				iMCur++;
			}
		}
		//build intermediaryCoaster
		iMCur = 0;
		intermediaryCoaster = new string[dateOccurrences.Count, cmx];
		foreach (KeyValuePair<string, int> d in dateOccurrences.OrderByDescending(key => key.Value)) {
			Dictionary<string, int> cands = new Dictionary<string, int> ();
			int tVoters = 0;
			for (int i = 0; i <= intermediaryMap.GetUpperBound(0); i++) {
				string date = intermediaryMap [i, 0];
				if (date != null) {
					if (date.Equals (d.Key)) {
						int voters = Int32.Parse (intermediaryMap [i, 2]);
						tVoters += voters;
						for (int j = 0; j < numAttributes-1; j++) {
							string cand = intermediaryMap [i, (j + j + 3)];
							string percent = intermediaryMap [i, (j + j + 4)];
							if (cand != null && percent != null && percent != "") {
								int perc = Int32.Parse (percent); 
								if (cands.ContainsKey (cand)) {
									cands [cand] += perc;
								} else {
									cands.Add (cand, perc);
								}
							}
						}
					}
				}
			}
			int nACur = 0;
			intermediaryCoaster[iMCur, 0] = d.Key;
			intermediaryCoaster[iMCur, 1] = tVoters.ToString();
			foreach (KeyValuePair<string, int> c in cands.OrderByDescending(key => key.Value)) {
				if (nACur < numAttributes - 1) {
					intermediaryCoaster [iMCur, (nACur + nACur + 2)] = c.Key;
					intermediaryCoaster [iMCur, (nACur + nACur + 3)] = c.Value.ToString ();
					nACur++;
				}
			}
			iMCur++;
		}
	}
    static void buildCandidateStructure()
    {
		//build map Dictionary
		int numAttributes = (intermediaryMap.GetUpperBound(1) - 1) / 2;
		for (int i = 0; i <= intermediaryMap.GetUpperBound(0); i++)
	    {
				//build poll container, key value pair with key date and value poll occurring on that date
				Score[] scores = new Score[numAttributes];
				for (int j = 0; j < numAttributes-1; j++) {
					var candidate = candidates.FirstOrDefault(c => c.name == intermediaryMap[i, (j+j+3)]);
					string v = intermediaryMap[i, 2];
					string percent = intermediaryMap[i, (j + j + 4)];
					if (candidate != null && percent != null && v != null) {
						if (percent != "" && v != "") {
							float voters = float.Parse(v);
							float perc = float.Parse(percent);
							//if (voters <= perc)
								//print(intermediaryMap[i, 0] + " " + intermediaryMap[i,1] + " " + candidate.name + ": Votes: " + percent + " out of " + voters);
							scores[j] = new Score(((perc/voters)*100).ToString(), candidate);
						}
					}
				}
				if (intermediaryMap[i, 0] != null) {
				//print (intermediaryMap[i, 0]);
				//print (intermediaryMap[i, 1]);
					Poll poll = new Poll(intermediaryMap[i, 1],intermediaryMap[i, 0],scores);
					//print (poll.date);
					if (pollByDate.ContainsKey(poll.date)) {
						pollByDate[poll.date].Add(poll);
					} else {
						List<Poll> list = new List<Poll>();
						list.Add(poll);
						pollByDate.Add(poll.date, list);
					}
				}
		}
		//build coaster Dictionary
		numAttributes = (intermediaryCoaster.GetUpperBound(1) - 1) / 2;
		for (int i = 0; i <= intermediaryCoaster.GetUpperBound(0); i++)
		{
			//build poll container, key value pair with key date and value poll occurring on that date
			Score[] scores = new Score[numAttributes];
			for (int j = 0; j < numAttributes-1; j++) {
				var candidate = candidates.FirstOrDefault(c => c.name == intermediaryCoaster[i, (j+j+2)]);
				string v = intermediaryCoaster[i, 1];
				string percent = intermediaryCoaster[i, (j + j + 3)];
				if (candidate != null && percent != null && v != null) {
					if (percent != "" && v != "") {
						float voters = float.Parse(v);
						float perc = float.Parse(percent);
						//if (voters <= perc)
						//print(intermediaryMap[i, 0] + " " + intermediaryMap[i,1] + " " + candidate.name + ": Votes: " + percent + " out of " + voters);
						//if (intermediaryCoaster[i, 0].Equals("2010-10-28"))
						//	print(intermediaryCoaster[i, 0] + " " + candidate.name + " " + perc + " " + voters + " " + (perc/voters)*100);
						scores[j] = new Score(((perc/voters)*100).ToString(), candidate);
					}
				}
			}
			if (intermediaryCoaster[i, 0] != null) {
				Poll poll = new Poll("USA",intermediaryCoaster[i, 0],scores);
				//print (poll.date);
				if (pollByDateCoaster.ContainsKey(poll.date)) {
					pollByDateCoaster[poll.date] = poll;
				} else {
					pollByDateCoaster.Add(poll.date, poll);
				}
			}
		}
    }
	public static void printIntermediaryCoaster() {
		for (int i = 0; i <= intermediaryCoaster.GetUpperBound(0); i++) {
			string msg = "";
				for (int j = 0; j <= intermediaryCoaster.GetUpperBound(1); j++) {
					msg += intermediaryCoaster[i, j] + " ";
			}
			print(msg);
		}
	}
	public static void printPollByDateCoaster() {
		foreach (KeyValuePair<DateTime, Poll> poll in pollByDateCoaster) {
			string msg = poll.Key + " ";

			for (int i = 0; i < poll.Value.scores.Length; i++) {
				//print (poll.Value.scores[i]);
				if (poll.Value.scores[i] != null)
					msg += " " + poll.Value.scores [i].candidate.name + " " + poll.Value.scores [i].percent;
			}
			print (msg);
		}
	}

	public static void printPollByDate() {
		foreach (KeyValuePair<DateTime, List<Poll>> pollList in pollByDate)
		{
			foreach (Poll poll in pollList.Value) {
				string msg = poll.date + " " + poll.state;
				for (int i = 0; i < poll.scores.Length; i++) {
					if (poll.scores[i] != null)
						msg += " " + poll.scores[i].candidate.name + " " + poll.scores[i].percent;
				}
				print(msg);
			}
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
	public static void printPollByDate(DateTime dt)
	{
		foreach (KeyValuePair<DateTime, Poll> poll in pollByDateCoaster.OrderBy(key => key.Key))
		{
			if (poll.Key.Equals(dt)) {
					string msg = poll.Value.date + " " + poll.Value.state;
					for (int i = 0; i < poll.Value.scores.Length; i++) {
						if (poll.Value.scores[i] != null)
							msg += " " + poll.Value.scores[i].candidate.name + " " + poll.Value.scores[i].percent;
					}
					print(msg);
			}
		}
	}
	/*public static void six() {
		foreach (KeyValuePair<DateTime, Poll> poll in pollByDateCoaster.OrderBy(key => key.Key)) {
			if (poll.Key.Equals (new DateTime (2010, 06, 20))) {
				for (int i = 0; i < poll.Value.scores.Length; i++) {
					if (poll.Value.scores [i] != null) {
						print (poll.Key + " " + poll.Value.scores [i].candidate.name + " " + poll.Value.scores [i].percent);
					}
				}
			}
		}
	}*/
}
