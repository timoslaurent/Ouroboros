using UnityEngine;
using System.Collections;

public class Obstacles : MonoBehaviour {
	//Transform push;
	public Transform cube;
	void OnTriggerEnter (Collider other){
		if (other.tag == "p2") {
			cube.position = new Vector3(cube.position.x, cube.position.y,cube.position.z + 2.5f);
			//Debug.Log (transform.position.z - 5f);
		}
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
