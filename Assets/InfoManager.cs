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

	bool exist = true;

	public void BT1_WoodStartUpdate(){
		if ((BuildingType & 1) != 0) {
			StartCoroutine (BT1_WoodUpdateIEnumerator());
			Debug.Log ("Type is " + BuildingType + " and 1 bit is true");
		}
	}


	public void BT2_AddLabourLimit(){
		if ((BuildingType & 2) != 0) {
			GameLogic.instance.labourLimit += Mathf.RoundToInt(BuildingTypeEffects [1]);
			Debug.Log ("Type is " + BuildingType + " and 2 bit is true");
		}
	}

	public void BT3_ArrowStartUpdate(){
		if ((BuildingType & 4) != 0) {
			StartCoroutine (BT3_ArrowUpdateIEnumerator());
			Debug.Log ("Type is " + BuildingType + " and 3 bit is true");
		}
	}



	IEnumerator BT1_WoodUpdateIEnumerator(){
		float timePeriod = 1f / BuildingTypeEffects [0];
		while (exist) {
			GameLogic.instance.woodNumber += 1;
			GameLogic.instance.UpdateResource ();
			GetComponent<InfoSpriteController> ().AddSprite (0, transform.position + new Vector3(0, 2f, 0));
			//TODO 
			//Animation
			yield return new WaitForSeconds (timePeriod);
		}
	}


	IEnumerator BT3_ArrowUpdateIEnumerator(){
		bool OK = false;
		float timePeriod = 1f / Mathf.Abs (BuildingTypeEffects [2]);
		while (exist) {
			OK = false;
			if (GameLogic.instance.woodNumber >= Mathf.Abs (BuildingTypeEffects [0])) {
				GameLogic.instance.arrowNumber += 1;
				GameLogic.instance.woodNumber += Mathf.RoundToInt (BuildingTypeEffects [0]);
				GetComponent<InfoSpriteController> ().AddSprite (1, transform.position + new Vector3(0, 2f, 0));
				OK = true;
				yield return new WaitForSeconds (timePeriod);
			}
			if (!OK)
				yield return new WaitForSeconds (0.1f);
		}
	}

	public void StartEffects(){
		BT1_WoodStartUpdate ();
		BT2_AddLabourLimit ();
		BT3_ArrowStartUpdate ();
		//Debug.Log ("Type is " + BuildingType);
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
