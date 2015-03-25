using UnityEngine;
using System.Collections;

public class Teleportation : MonoBehaviour {

	public Transform otherSide;
	GameObject old;
	GameObject young;

	// Use this for initialization
	void Start () {
		old = GameObject.FindGameObjectWithTag ("p1");
		young = GameObject.FindGameObjectWithTag ("p2");
		//contact = false;
	}

	void OnTriggerEnter (Collider other) {
		if (other.tag == "p1" && !old.GetComponent<PlayerManager>().isTeleporting) {
			old.transform.position = otherSide.position;
			old.GetComponent<PlayerManager>().teleport(0.5f, otherSide.position + otherSide.forward);
		} 
		if (other.tag == "p2" && !young.GetComponent<PlayerManager>().isTeleporting) {
			young.transform.position = otherSide.position;
			young.GetComponent<PlayerManager>().teleport(0.5f, otherSide.position + otherSide.forward);
		} 
	}
}
