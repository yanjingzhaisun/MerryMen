using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour {
	
	Vector3 up = new Vector3(1, 0 , Mathf.Sqrt(3)); // up
	Vector3 right = new Vector3(Mathf.Sqrt(3), 0 ,-1) /2; // right

	public void Update_MoveCamera(){
		Vector3 move = new Vector3(0, 0, 0);

		if (Input.mousePosition.x < 0.05 * Screen.width) {
			move -= right;
		}
		else if (Input.mousePosition.x > 0.95 * Screen.width) {
			move += right;
		}
		if (Input.mousePosition.y < 0.05 * Screen.height) {
			move -= up;
		} else if (Input.mousePosition.y > 0.95 * Screen.height) {
			move += up;
			//Debug.Log (Input.mousePosition);
		}
		move /= 10f;
		Camera.main.transform.position += move;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Update_MoveCamera ();
	}
}
