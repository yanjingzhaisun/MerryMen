using UnityEngine;
using System.Collections;
using System;

public class BuildingDataParser : MonoBehaviour {

	// Use this for initialization
	public string fileName;

	void Awake(){
		try {
			TextAsset myData = Resources.Load("building_data/" + fileName) as TextAsset;
			string txt = myData.text;
			string[] lines = txt.Split('\n');
			//Debug.Log(txt);
			string[] entries = lines[0].Split(' ');
			int rowNumber = int.Parse(entries[0]);
			int columnNumber = int.Parse(entries[1]);
			GetComponent<SquareDetection>().SetData(rowNumber, columnNumber);

			//Debug.Log(fieldResources);

		} catch (Exception e) {
			Debug.Log ("Not succesfully read text");
			Debug.LogError (e);

		}
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
