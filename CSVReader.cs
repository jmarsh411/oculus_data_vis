using UnityEngine;
using System.Collections;
using System.Linq; 
 
public class CSVReader : MonoBehaviour 
{
	public TextAsset csvFile;
	public void Awake() {
		string[,] grid = makeArray(csvFile.text);
	}
	static public string[,] makeArray(string csvText) {
		string lines[] = csvText.Split("\n"[0]);
		int categories = 29;
		string[,] arr = new string[categories, lines.length-1];
		for (int i = 0; i < lines.length-1, i++) {
			string[] temp = splitLine(lines[i]);
			for (int j = 0; j < categories; j++) {
				arr[i,j] = temp[j];
			}
		}
		return arr;
	}
	static public string[] splitLine(string line) {
		return line.Split(',').Select(Convert.ToSingle).ToArray();
	}
}