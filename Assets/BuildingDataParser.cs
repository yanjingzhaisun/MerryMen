using UnityEngine;
using System.Collections;
using System;

public class BuildingDataParser : MonoBehaviour {

	// Use this for initialization
	public string fileName;

	void Awake(){
		try {

			// lines[0]: rowNumber columnNumber
			// lines[1]: costInWood costInLabour
			// lines[2]: Effect Genre:

			TextAsset myData = Resources.Load("building_data/" + fileName) as TextAsset;

			string txt = myData.text;
			string[] lines = txt.Split('\n');
			//Debug.Log(txt);
			string[] entries = lines[0].Split(' ');
			int rowNumber = int.Parse(entries[0]);
			int columnNumber = int.Parse(entries[1]);
			GetComponent<SquareDetection>().SetData(rowNumber, columnNumber);

			entries = lines[1].Split(' ');
			int costInWood = int.Parse(entries[0]);
			int costInLabour = int.Parse(entries[1]);
//			if (fileName == "sawmill") {
//				Debug.Log(fileName + ": Successfully into load");
//			}

			GetComponent<Building>().costInWood = costInWood;
			//Debug.Log(fileName + ": Successfully into load");
			GetComponent<Building>().costInLabour = costInLabour;

			int type = int.Parse(lines[2]);

			entries = lines[3].Split(' ');

			float e0 = float.Parse(entries[0]);
			float e1 = float.Parse(entries[1]);
			float e2 = float.Parse(entries[2]);

			GetComponent<Building>().SetValue(type, e0, e1, e2);


			//Debug.Log(fieldResources);

		} catch (Exception e) {
			Debug.Log ("Not succesfully read text");
			Debug.Log (fileName);
			Debug.LogError (e);

		}
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
