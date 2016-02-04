using UnityEngine;
using System.Collections;

public class SquareDetection : MonoBehaviour {


	[HideInInspector]
	public int rowNumber = 0;
	[HideInInspector]
	public int columnNumber = 0;

	int totalRowNumber = 0;
	int totalColumnNumber = 0;

	GameObject gameLogic;

	// Use this for initialization
	void Start () {
		gameLogic = GameObject.Find ("GameLogic");
		totalRowNumber = gameLogic.GetComponent<GridGenerator> ().rowNumber;
		totalColumnNumber = gameLogic.GetComponent<GridGenerator> ().columnNumber;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetData(int a, int b){
		rowNumber = a;
		columnNumber = b;
	}

	public bool IsOKToBuild(){
		int rowStart = (int)transform.parent.position.x;
		int columnStart = (int)transform.parent.position.z;
		if (rowStart + rowNumber > totalRowNumber)
			return false;
		if (columnStart + columnNumber > totalColumnNumber)
			return false;
		
		for (int i = rowStart; i < rowStart + rowNumber; i++)
			for (int j = columnStart; j < columnStart + columnNumber; j++) {
				if (!gameLogic.GetComponent<SquareDataKeeper> ().MapConstructable [i, j])
					return false; 
			}
		return true;
	}
}
