using UnityEngine;
using System.Collections;
using UnityEngine.UI;

using System.Collections.Generic;

public class GameLogic : MonoBehaviour {
	[HideInInspector]
	public static GameLogic instance;
	[HideInInspector]
	public int woodNumber;
	[HideInInspector]
	public int labourLimit;
	[HideInInspector]
	public int labourInUse;

	[HideInInspector]
	public int arrowNumber;

	[HideInInspector]
	public Text textAlert;

	void Awake(){
		instance = this;
		labourLimit = 10;
		woodNumber = 10;
		labourInUse = 0;
		arrowNumber = 0;
		textAlert = GameObject.Find ("AlertText").GetComponent<Text> ();
	}

	// Use this for initialization
	void Start () {
		UpdateResource ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public int CheckResourseIsOkToBuild(int costInWood, int costInLabour){
		if (costInWood > woodNumber)
			return -1;
		if (costInLabour + labourInUse > labourLimit)
			return -2;

		return 1;
	}

	public void UpdateResource(){
		Text t;
		t = GameObject.Find ("ResourceWood").GetComponent<Text> ();
		t.text = woodNumber.ToString();
		t = GameObject.Find ("ResourceLabour").GetComponent<Text> ();
		t.text = labourInUse + " / " + labourLimit;
		t = GameObject.Find ("ResourceArrow").GetComponent<Text> ();
		t.text = arrowNumber.ToString ();
	}

	public void ShowAlert(string alertContent){
		StopCoroutine (AlertColorFading());
		Debug.Log ("StopAlertFading");
		textAlert.text = alertContent;

		textAlert.color = new Color (textAlert.color.r, textAlert.color.g, textAlert.color.b, 1);
		Debug.Log ("StartAlertFading");
		StartCoroutine (AlertColorFading());
	}

	IEnumerator AlertColorFading(){
		Color end = new Color (textAlert.color.r, textAlert.color.g, textAlert.color.b, 0);
		while (textAlert.color.a > 0.01){
			textAlert.color = Color.Lerp (textAlert.color, end, 0.1f);
			Debug.Log (textAlert.color);
			yield return new WaitForSeconds(0.1f);
		}
		textAlert.color = end;

	}

	public void OnDestroy(){
		StopCoroutine (AlertColorFading ());
	}
}
