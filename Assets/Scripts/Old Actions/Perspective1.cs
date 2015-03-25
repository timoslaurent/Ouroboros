using UnityEngine;
using System.Collections;

public class Perspective1 : MonoBehaviour {
	public Transform Plan;
	public float rotation;
	bool visibleGUI = false;

	void OnTriggerEnter (Collider other){
		if (other.tag == "p1") {
			rotation = 135;
			Plan.eulerAngles = new Vector3 (30,rotation, 0);
		}
	}
	void OnTriggerExit (){
		//visibleGUI = false;
	}
	void OnGUI(){
		if (visibleGUI) {
			GUI.Box(new Rect (Screen.width/2-90, Screen.height-50,180,25), "Appuyer sur LT");
		}
	}
}