using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour {

	// Use this for initialization

	GameObject gameLogic;

	[HideInInspector]
	public bool isBuilt = false;

	Material mat;

	void Awake(){
		gameLogic = GameObject.Find ("GameLogic");

	}
	void Start () {
//		mat = transform.FindChild ("WaterPoweredSawmillUpload").FindChild ("Floor").GetComponent<renderer> ();

		//TODO
		//get those shared Material and change them as color changed.
	}

	void Update_Position(){
		Ray toMouse = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit rhInfo;
		LayerMask layerMask = ~(LayerMask.NameToLayer ("Terrain"));
		bool didHit = Physics.Raycast (toMouse, out rhInfo, 2000f, layerMask);
		if (didHit) {
			transform.parent.position = new Vector3 (Mathf.Round (rhInfo.collider.transform.position.x), transform.parent.position.y, Mathf.Round (rhInfo.collider.transform.position.z));
			Debug.Log(rhInfo.collider.transform.position.x + " " + rhInfo.collider.transform.position.z);
		} else {
			//Debug.Log ("HitNothing");
		}
	}

	void Update_Color(){
		//if {}
		if (GetComponent<SquareDetection> ().IsOKToBuild ()) {
			
		} else {
			
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (isBuilt)
			return;
		Update_Position ();
		//}

		//transform.parent.position = new Vector3 (Mathf.Round(mouseP.x), transform.parent.position.y, Mathf.Round( mouseP.z));
	}
}
