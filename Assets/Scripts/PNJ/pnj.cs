using UnityEngine;
using System.Collections;

public class pnj : MonoBehaviour {
	bool visibleGUI = false;
	public string Dialogue;
	void OnTriggerEnter (Collider other){
		if (other.tag == "p1") {
			visibleGUI = true;
			//audio.Play();
		}
	}

	void OnTriggerExit (){
		visibleGUI = false;
	}

	void OnGUI(){
		if (visibleGUI) {
			GUI.Box(new Rect (Screen.width/2-90, Screen.height-50,180,25), Dialogue);
		}
	}
}
