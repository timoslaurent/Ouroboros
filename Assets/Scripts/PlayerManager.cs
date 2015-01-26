using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	float speed, mX, moveX, mY, moveY;

	// Use this for initialization
	void Start () {
		speed = 2;
		//mX = mY = moveX = moveY = 0;
	}
	
	// Update is called once per frame
	void Update () {
		Movement ();
		InputUser ();
	}

	void Movement () {
		//Left Joystick
		if (CompareTag ("Player")) {
			//mX = Input.GetAxis ("L_Horizontal") * Time.deltaTime* speed;
			transform.Translate (Input.GetAxis ("L_Horizontal") * Time.deltaTime* speed, 0, 0);
			//mY = Input.GetAxis ("L_Vertical") * Time.deltaTime * speed;
			transform.Translate (0, 0, Input.GetAxis ("L_Vertical") * Time.deltaTime * speed);
		}
		//Right Joystick
		if (CompareTag ("Player2")) {
			//moveX = Input.GetAxis ("R_Horizontal") * Time.deltaTime * speed;
			transform.Translate (Input.GetAxis ("R_Horizontal") * Time.deltaTime * speed, 0, 0);
			//moveY = Input.GetAxis ("R_Vertical") * Time.deltaTime * speed;
			transform.Translate (0, 0, Input.GetAxis ("R_Vertical") * Time.deltaTime * speed);
		}
	}

	void InputUser (){
		//Serpent à gauche
		if (Input.GetButtonDown ("360_LB")){
			Debug.Log ("LB");
		}
		//Serpent à droite
		if (Input.GetButtonDown ("360_RB")) {
			Debug.Log ("RB");
		}
	}
}