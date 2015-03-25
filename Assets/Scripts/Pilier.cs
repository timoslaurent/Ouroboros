using UnityEngine;
using System.Collections;

public class Pilier : MonoBehaviour {
	//public Transform pilier;
	public GameObject pilier;

	void Start()
	{

	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "p2") {
			other.GetComponent<PlayerManager>().isManipulating = true;
			//Debug.Log ("Animation activé");
			//pilier.animation["pilier"].speed = 1;
			//pilier.animation.Play ("pilier");
			//pilier.position =  new Vector3 (pilier.position.x,pilier.position.y + 31.255f,pilier.position.z);
		}
	}
	void OnTriggerExit (Collider other){
		if (other.tag == "p2") {
			//other.GetComponent<PlayerManager>().isManipulating = false;
			//pilier.position =  new Vector3 (pilier.position.x,pilier.position.y - 31.255f,pilier.position.z);
			//Debug.Log ("Animation return");
			pilier.animation["pilier"].speed = -1;
			pilier.animation["pilier"].time = pilier.animation["pilier"].length;
			//pilier.animation["pilier"].time = 10;
			pilier.animation.Play ("pilier");
		}
	}
}