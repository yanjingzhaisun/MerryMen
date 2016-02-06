using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class StoryController : MonoBehaviour {
	[HideInInspector]
	public static StoryController instance;

	Text dialogue;

	bool[] archievement;

	// Use this for initialization

	void Awake(){
		instance = this;
	}
	void Start () {
		dialogue = transform.FindChild ("Dialogue").GetComponent<Text>();
		//
		SetDialogue("Hey my Merrymen, I need some arrow.");

		archievement = new bool[20];
		for (int i = 0; i < 20; i++) {
			archievement [i] = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (GameLogic.instance.arrowNumber > 9*10-1) {
			if (!archievement [8]) {
				SetDialogue ("I'm so rich with these 90 arrows.");
				archievement [8] = true;
			}
		}
		else if (GameLogic.instance.arrowNumber > 8*10-1) {
			if (!archievement [7]) {
				SetDialogue ("Since I've got an army, why am I killing sheriff Notthingham?");
				archievement [7] = true;
			}
		}
		else if (GameLogic.instance.arrowNumber > 7*10-1) {
			if (!archievement [6]) {
				SetDialogue ("Nearly an Army with 70 arrows.");
				archievement [6] = true;
			}
		}
		else if (GameLogic.instance.arrowNumber > 6*10-1) {
			if (!archievement [5]) {
				SetDialogue ("With these 60 arrows I feel like captalist.");
				archievement [5] = true;
			}
		}
		else if (GameLogic.instance.arrowNumber > 5*10-1) {
			if (!archievement [4]) {
				SetDialogue ("50 Arrows? Capitalism.");
				archievement [4] = true;
			}
		}
		else if (GameLogic.instance.arrowNumber > 4*10-1) {
			if (!archievement [3]) {
				SetDialogue ("Why don't we just sell these 40 arrows and celebrate.");
				archievement [3] = true;
			}
		}
		else if (GameLogic.instance.arrowNumber > 3*10-1) {
			if (!archievement [2]) {
				SetDialogue ("30 Arrows! I can kill 2 Sheriff of Nottingham.");
				archievement [2] = true;
			}
		}
		else if (GameLogic.instance.arrowNumber > 2*10-1) {
			if (!archievement [1]) {
				SetDialogue ("20 Arrows. Good Job.");
				archievement [1] = true;
			}
		}
		else if (GameLogic.instance.arrowNumber > 10-1) {
			if (!archievement [0]) {
				SetDialogue ("Ow you've collet 10 Arrows. Nice.");
				archievement [0] = true;
			}
		}
	}

	public void SetDialogue(string dialogueString){
		StopCoroutine (dialgueFadeOut ());
		dialogue.text = dialogueString;
		StartCoroutine (dialgueFadeOut ());
	}

	IEnumerator dialgueFadeOut(){
		Color end = new Color (dialogue.color.r, dialogue.color.g, dialogue.color.b, 0);
		dialogue.color = new Color (dialogue.color.r, dialogue.color.g, dialogue.color.b, 1);
		while (dialogue.color.a > 0.01){
			dialogue.color = Color.Lerp (dialogue.color, end, 0.1f);
			Debug.Log (dialogue.color);
			yield return new WaitForSeconds(0.1f);
		}
		dialogue.color = end;
	}

}
