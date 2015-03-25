using UnityEngine;
using System.Collections;

public class PickupSerpent : MonoBehaviour {
	void OnTriggerEnter (Collider other){
		if (other.tag == "Serpent") {
			other.renderer.enabled = false;
			Debug.Log ("Serpent récupéré");
		}
	}

	void OnGUI (){

	}
}
