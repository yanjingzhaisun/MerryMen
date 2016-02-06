using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour {

	// Use this for initialization

	//GameObject gameLogic;

	[HideInInspector]
	public bool isBuilt = false;

	public Transform builtPrefab;

	[HideInInspector]
	public int costInWood;
	[HideInInspector]
	public int costInLabour;

	[HideInInspector]
	public int buildingType;
	//1 : wood generator
	//2 : room maker
	[HideInInspector]
	public float[] typeEffect;
	Material mat;

	void Awake(){
		//gameLogic = GameObject.Find ("GameLogic");

	}
	void Start () {
//		mat = transform.FindChild ("WaterPoweredSawmillUpload").FindChild ("Floor").GetComponent<renderer> ();
		mat = transform.parent.FindChild("Material").GetComponent<Renderer>().sharedMaterials[0];

		//TODO
		//get those shared Material and change them as color changed.
	}

	public void SetValue(int TP, float a, float b, float c){
		typeEffect = new float[3];
		buildingType = TP;
		typeEffect [0] = a;
		typeEffect [1] = b;
		typeEffect [2] = c;
	}

	void Update_Position(){
		Ray toMouse = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit rhInfo;
		LayerMask layerMask = ~(LayerMask.NameToLayer ("Terrain"));

		//Debug.Log(rhInfo.collider.transform.position.x + " " + rhInfo.collider.transform.position.z);

		bool didHit = Physics.Raycast (toMouse, out rhInfo, 2000f, layerMask);
		if (didHit) {
			transform.parent.position = new Vector3 (Mathf.Round (rhInfo.collider.transform.position.x), transform.parent.position.y, Mathf.Round (rhInfo.collider.transform.position.z));
			//Debug.Log(rhInfo.collider.transform.position.x + " " + rhInfo.collider.transform.position.z);
		} else {
			//Debug.Log ("HitNothing");
		}
	}

	void Update_Color(){
		//if {}
		if (GetComponent<SquareDetection> ().IsOKToBuild ()) {
			//Debug.Log ("Ok to build");
			mat.color = new Color(0.1796875f, 0.796875f, 0.44140625f,0.5f);
			//#2ecc71
		} else {
			//Debug.Log ("Not Ok to build");
			mat.color = new Color(0.90234375f, 0.296875f, 0.234375f,0.5f);
			//#e74c3c
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (isBuilt)
			return;
		Update_Position ();
		Update_Color ();
		if (Input.GetMouseButtonDown (0)) {
			if (GetComponent<SquareDetection> ().IsOKToBuild ()) {
				if (GameLogic.instance.CheckResourseIsOkToBuild (costInWood, costInLabour) == 1) {
					Update_Color ();
					isBuilt = true;
					mat.color = Color.white;
					GameLogic.instance.woodNumber -= costInWood;
					GameLogic.instance.labourInUse += costInLabour;
					GameLogic.instance.UpdateResource ();
					GetComponent<SquareDetection> ().SetUnconstructable ();
					Transform t = Instantiate (builtPrefab, new Vector3 (transform.parent.position.x, transform.parent.position.y, transform.parent.position.z), Quaternion.identity) as Transform;
					t.parent = GameObject.Find ("Buildings").transform;
					InfoManager inf = t.FindChild ("InfoManager").GetComponent<InfoManager> ();
					inf.SetValue (buildingType, typeEffect [0], typeEffect [1], typeEffect [2]);
					inf.StartEffects ();
					Object.Destroy (transform.parent.gameObject);
				} else if (GameLogic.instance.CheckResourseIsOkToBuild (costInWood, costInLabour) == -1) {
					GameLogic.instance.ShowAlert ("Can't build due to the lack of Wood.");
				} else if (GameLogic.instance.CheckResourseIsOkToBuild (costInWood, costInLabour) == -2) {
					GameLogic.instance.ShowAlert ("Haven't enough space for the Labour you need.");
				}
			}
		} else if (Input.GetMouseButtonDown (1)) {
			Object.Destroy (transform.parent.gameObject);
		}
		//}

		//transform.parent.position = new Vector3 (Mathf.Round(mouseP.x), transform.parent.position.y, Mathf.Round( mouseP.z));
	}
}
