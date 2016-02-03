using UnityEngine;
using System.Collections;
using System;

public class GridGenerator : MonoBehaviour {

	//[RequireComponent (typeof (SquareDataKeeper))]


	public Transform grassPrefab;
	public string fileName;

	// Use this for initialization
	[HideInInspector]
	public int rowNumber =  0;
	[HideInInspector]
	public int columnNumber = 0;
	[HideInInspector]
	public int[,] fieldResources;

	void Awake(){
		fieldResources = new int[200, 200];
		try {
			TextAsset myData = Resources.Load("level_text/" + fileName) as TextAsset;
			string txt = myData.text;
			string[] lines = txt.Split('\n');
			//Debug.Log(txt);
			string[] entries = lines[0].Split(' ');
			rowNumber = int.Parse(entries[0]);
			columnNumber = int.Parse(entries[1]);
			GetComponent<SquareDataKeeper>().SetSquareData(rowNumber, columnNumber);
			for (int i = 0; i < rowNumber; i++){
				entries = lines[i + 1].Split(' ');
				for (int j = 0; j < columnNumber; j++) {
					fieldResources[i, j] = int.Parse(entries[j]);
				}
			}
			//Debug.Log(fieldResources);

		} catch (Exception e) {
			Debug.Log ("Not succesfully read text");
			Debug.LogError (e);

		}
		for (int i = 0; i < 10; i++)
			for (int j = 0; j < 10; j++) {
				Vector3 posi = new Vector3 (i, 0, j);
				Transform t = Instantiate (grassPrefab, posi, Quaternion.identity) as Transform;
				t.parent = transform;
			}
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
