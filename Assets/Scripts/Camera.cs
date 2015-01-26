using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

	public float follow = 0.15f;
	private Vector3 velocity = Vector3.zero;
	public Transform target;

	// Use this for initialization
	void Start () {
		camera.orthographic = true;
	}
	
	// Update is called once per frame
	void Update () {
		camera.orthographicSize = 6;
		//Camera follows snakes
		if (target) {
			Vector3 point = camera.WorldToViewportPoint (target.position);
			Vector3 distance = target.position - camera.ViewportToWorldPoint (new Vector3 (0.5f, 0.5f, point.z));
			Vector3 pointdes = transform.position + distance;
			transform.position = Vector3.SmoothDamp (transform.position, pointdes, ref velocity, follow); //Pourquoi ref ????
		}
	}
}
