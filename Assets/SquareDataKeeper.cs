using UnityEngine;
using System.Collections;

public class SquareDataKeeper : MonoBehaviour {
	[HideInInspector]
	public int rowNumber, columnNumber;
	[HideInInspector]
	public bool [,] MapConstructable;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetSquareData(int a, int b){
		rowNumber = a;
		columnNumber = b;
		MapConstructable = new bool[rowNumber, columnNumber];
		for (int i = 0; i < a; i++)
			for (int j = 0; j < b; j++)
				MapConstructable [i, j] = true;
		//TODO
		MapConstructable [0, 0] = false;
		
	}
}
