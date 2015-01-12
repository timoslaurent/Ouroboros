using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

	// Use this for initialization
	void Start () {
		camera.orthographic = true;
	}
	
	// Update is called once per frame
	void Update () {
		camera.orthographicSize = 5;
	}
}
