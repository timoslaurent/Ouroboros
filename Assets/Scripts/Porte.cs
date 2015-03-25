using UnityEngine;
using System.Collections;

public class Porte : MonoBehaviour {
	//public AudioClip sound;
	//audio.PlayOneShot (sound);
	public GameObject porte;

	void OnTriggerEnter (Collider other){
		if (other.tag =="p1"){
			porte.animation.Play ("porte");
			Destroy (this);
			//target.position = new Vector3 (target.position.x,target.position.y - 2.5f,target.position.z);
			//target.Rotate (0, 2*Time.deltaTime,0);
		}
	}



	/*//Transform push;
	void OnTriggerEnter (Collider other){
		if (other.tag == "p1") {
			transform.rotation = new Vector3(transform.rota.x, transform.position.y,transform.position.z + 2.5f);
		}
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}*/
}
