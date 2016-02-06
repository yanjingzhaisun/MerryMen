using UnityEngine;
using System.Collections;

public class GUIControl : MonoBehaviour {

	[HideInInspector]
	public static GUIControl instance;

	//HideInInspector]
	//public int currentBuildingConstruction;

	void Awake(){
		instance = this;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
		
}
