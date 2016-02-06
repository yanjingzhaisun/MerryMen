using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class InfoSpriteController : MonoBehaviour {
	
	public Transform[] prefabInfoSprites;
	List<Transform> infoSprites;

	[HideInInspector]
	public int spriteType = 0;
	Vector3 velocity = new Vector3(0f, 0.05f, 0f);

	// Use this for initialization

	void Awake(){
		infoSprites = new List<Transform> ();
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < infoSprites.Count; i++) {
			infoSprites [i].position += velocity;
			if (infoSprites [i].position.y > 5f) {
				Transform t = infoSprites[i];
				infoSprites.Remove (infoSprites [i]);
				GameObject.Destroy (t.gameObject);
			}
		}
	}

	public void SetSpriteType(int TP){
		spriteType = TP;
	}

	public void AddSprite(int TP, Vector3 pos){
		Debug.Log ("Entered AddSprite");
		try{
			Transform t = Instantiate (prefabInfoSprites [TP], pos, Quaternion.identity) as Transform;
			infoSprites.Add (t);
			t.parent = transform;
		} catch(Exception e){
			Debug.LogError (e);	
		}
	}
	public void AddSprite(Vector3 pos){
		Transform t = Instantiate (prefabInfoSprites [spriteType], pos, Quaternion.identity) as Transform;
		infoSprites.Add (t);
	}
}
