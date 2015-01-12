using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	float speed, mX, moveX, mY, moveY;

	// Use this for initialization
	void Start () {
		speed = 20;

	}
	
	// Update is called once per frame
	void Update () {
		Movement ();
	}

	void Movement () {
		//Left Joystick
		mX = Input.GetAxis ("L_Horizontal") * speed * Time.deltaTime;
		transform.Translate (mX, 0, 0);
		mY = Input.GetAxis ("L_Vertical") * speed * Time.deltaTime;
		transform.Translate (0, mY, 0);

		//Right Joystick
		moveX = Input.GetAxis ("R_Horizontal") * speed * Time.deltaTime;
		transform.Translate (moveX, 0, 0);
		moveY = Input.GetAxis ("R_Vertical") * speed * Time.deltaTime;
		transform.Translate (0, moveY, 0);
	}
}
