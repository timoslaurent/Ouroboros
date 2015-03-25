using UnityEngine;
using System.Collections;

public class Perspective : MonoBehaviour {
	public Transform Plan;
	public float rotation;
	bool visibleGUI = false;

	void OnTriggerEnter (Collider other){
		if (other.tag == "p1") {
			other.GetComponent<PlayerManager>().isPerspective = true;
			visibleGUI = true;
			/*if (rotation == 175){
				other.GetComponent<PlayerManager>().isPerspective = false;
			}*/
			//Plan.eulerAngles = new Vector3 (30,rotation, 0);
		}
	}
	void OnTriggerExit (Collider other){
		other.GetComponent<PlayerManager> ().isPerspective = false;
		visibleGUI = false;
		/*rotation = 135;
		Plan.eulerAngles = new Vector3 (30,rotation, 0);*/
	}
	void OnGUI(){
		if (visibleGUI) {
			GUI.Box(new Rect (Screen.width/2-90, Screen.height-50,180,25), "Appuyer sur LT");
		}
	}
}