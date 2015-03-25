using UnityEngine;
using System.Collections;

public class Grille : MonoBehaviour {
	public GameObject grille;
	public GameObject s1;
	public GameObject s2;
	public GameObject s3;

	private string[] snakes = new string[3];
	private int index;

	void Update ()
	{
		if (index >= snakes.Length - 1)
		{
			//grille.animation["grille"].speed = 1;
			grille.animation.Play ("grille");
			grille.animation["grille"].time = 1;
			Destroy (this);
			Debug.Log (snakes [0]);
			Debug.Log (snakes [1]);
			Debug.Log (snakes [2]);
		}
		//Debug.Log ("N° serpent " + index);
		//Debug.Log (snakes.Length);
		//Debug.Log (snakes [index]);
	}

	void OnTriggerEnter (Collider other){
		/*if (other.tag == "p1" ) {
			target.position = new Vector3 (target.position.x,target.position.y + 6,target.position.z);
		}*/

		if (other.tag == "p1" ) {
			snakes[index] = "Serpent1";
			index++;
		}

		if (other.tag == "p1" ) {
			snakes[index] = "Serpent2";
			index++;
		}

		if (other.tag == "p2") {
			snakes[index] = "Serpent3";
			index++;
		}
		//Debug.Log (snakes [index]);
		//Debug.Log (snakes [index]);
	}
}
