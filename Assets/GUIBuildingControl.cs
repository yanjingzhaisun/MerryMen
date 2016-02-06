using UnityEngine;
using System.Collections;

public class GUIBuildingControl : MonoBehaviour {
	
	[HideInInspector]
	public static GUIBuildingControl instance;
	[HideInInspector]
	public int currentBuildingID;

	public Transform[] prefabBuildingMarker;

	Transform currentTransform;


	public void SetCurrentBuildingID(int ID){
		if (currentTransform != null) {
			GameObject.Destroy (currentTransform.gameObject);
		}
		currentTransform = Instantiate (prefabBuildingMarker [ID], Vector3.zero, Quaternion.identity) as Transform;
		currentTransform.parent = GameObject.Find ("BuildingMarkers").transform;
	}


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
