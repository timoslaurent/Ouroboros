using UnityEngine;
using System.Collections;

public class HubScript : MonoBehaviour {
	
	GameObject cube;
	GameObject cu;
	Transform destination;
	bool contact;
	// Use this for initialization
	void Start () {
		cube = GameObject.FindGameObjectWithTag ("p1");
		cu = GameObject.FindGameObjectWithTag ("p2");
		contact = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter (Collider other) {
		contact = true;
		//Marche avec seulement un seul perso qui rentre en contact avec le trigger 
		if ((contact != false) && (other.tag == "p1")) {
			Debug.Log ("Changement");
			Application.LoadLevel ("Fontaine");
			// Détruire les clones des players au moment de revenir sur la précédente scène
			Destroy (cube);
			Destroy (cu);
		}
	}
}
