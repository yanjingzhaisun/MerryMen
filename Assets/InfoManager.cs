using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InfoManager : MonoBehaviour {

	[HideInInspector]
	public int BuildingType;
	//1: wood generator
	//2: room maker;
	[HideInInspector]
	public float[] BuildingTypeEffects;

	public void BT1_WoodStartUpdate(){
		if ((BuildingType & 1) != 0) {
			StartCoroutine (BT1_WoodUpdateIEnumerator());
		}
	}

	bool exist = true;

	IEnumerator BT1_WoodUpdateIEnumerator(){
		float timePeriod = 1f / BuildingTypeEffects [0];
		while (exist) {
			GameLogic.instance.woodNumber += 1;
			GameLogic.instance.UpdateResource ();

			//TODO 
			//Animation
			yield return new WaitForSeconds (timePeriod);
		}
	}

	public void BT2_AddLabourLimit(){
		if ((BuildingType & 2) != 0) {
			GameLogic.instance.labourLimit += Mathf.RoundToInt(BuildingTypeEffects [1]);
		}
	}

	public void StartEffects(){
		BT1_WoodStartUpdate ();
		BT2_AddLabourLimit ();
	}

	public void SetValue(int TP, float a, float b, float c){
		BuildingType = TP;
		BuildingTypeEffects = new float[3];
		BuildingTypeEffects [0] = a;
		BuildingTypeEffects [1] = b;
		BuildingTypeEffects [2] = c;
	}

	public void OnDestroy(){
		//Stop All IEnumerator
		StopCoroutine (BT1_WoodUpdateIEnumerator ());
	}



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
