using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;

public class ChangeCSV : MonoBehaviour {

	
	public Dictionary<string, string> filelist = new Dictionary<string, string> ();
	Button[] csv = new Button[5];
	bool ran = false;
	int number = 0;
	void getFiles() {
		var info = new DirectoryInfo(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\VR Dashboard CSVs\\");
		var files = info.GetFiles ("*.csv");
		foreach (var file in files) {
			filelist.Add(file.Name,file.FullName);
			number++;
		}
	}

	void Awake() {
		getFiles ();
		if (number > 5)
			number = 5;
		for (int i = 0; i < number; i++) {
			csv[i] = GameObject.Find("LoadCSV"+i).GetComponentInChildren<Button>();
		}
		int csvi = 0;
		foreach (KeyValuePair<string,string> file in filelist) {
			csv[csvi].GetComponentInChildren<CanvasRenderer>().SetAlpha(1);
			Text candText = csv[csvi++].GetComponentInChildren<Text>();
			candText.color = Color.black;
			candText.text = file.Key;
			print (candText.text);
		}
	}

	public void onClick(int but) {
		if (but < number) {
			CSVReader.parse(filelist[csv[but].GetComponentInChildren<Text>().text]);
		}
	}

	/*void OnGUI () {
		if (!ran) {
			getFiles ();
			ran = true;
		}
		GUI.Box (new Rect (10, 10, 160, 70 + (20 * number)), "Choose CSV");

		int one = 20, two = 40, three = 140, four = 20;
		foreach (KeyValuePair<string,string> file in filelist) {
			if (GUI.Button (new Rect (one, two, three, four), file.Key)) {
				CSVReader.parse(file.Value);
			}
			two += 30;
		}
	}*/
}