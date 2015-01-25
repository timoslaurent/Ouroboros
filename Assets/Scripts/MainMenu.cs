using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
		
	void OnGUI (){
		if (GUI.Button (new Rect (300, 150, 250, 50), "Play")) {
			Application.LoadLevel ("Ouroboros");
		}
		if (GUI.Button (new Rect (300,250, 250, 50), "Quitter")) {
			Debug.Log ("Bye Bye");
			Application.Quit ();
		}
	}




}