using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public float dampTime = 0.15f;
	private Vector3 velocity = Vector3.zero;

	public Transform target;
	public Transform target2;

	public float maxDistanceBeforeDeZoom;
	public float minSize; 

	Vector3 distance;
	// Update is called once per frame
	void Update ()
	{


		distance = target.position - target2.position;
		if (target)
		{
			Vector3 point = camera.WorldToViewportPoint(target.position);
			Vector3 delta = target.position - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
			Vector3 destination = transform.position + delta;
			transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
		}
		/*else if (target2)
		{
			Vector3 point = camera.WorldToViewportPoint(target2.position);
			Vector3 delta = target2.position - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
			Vector3 destination = transform.position + delta;
			transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
		}*/
		if (target2)
		{
			Vector3 point = camera.WorldToViewportPoint(target2.position);
			Vector3 delta = target2.position - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
			Vector3 destination = transform.position + delta;
			transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
		}

		if (distance.magnitude > maxDistanceBeforeDeZoom) {
			camera.orthographicSize = minSize + distance.magnitude - maxDistanceBeforeDeZoom;
			//target.GetComponentInChildren<SkinnedMeshRenderer>().renderer.material.color = Color.black;
			float alpha = 1-Mathf.Max(((distance.magnitude - maxDistanceBeforeDeZoom)/20f),0.30f); //Bloquer l'alpha à 0.30
			float alphaMax = 0.3f;
			//Debug.Log (alpha);
			if (alpha >= alphaMax){
				target.GetComponentInChildren<SkinnedMeshRenderer>().renderer.material.color = new Color (0,0,0,alpha);
			}

			target.GetComponent<PlayerManager>().speedOld = 5.0f;
		} else if (distance.magnitude < maxDistanceBeforeDeZoom) {
			target.GetComponent<PlayerManager>().speedOld = 15.0f;
			target.GetComponentInChildren<SkinnedMeshRenderer>().renderer.material.color = new Color (0,0,0,1);
		}
		//Debug.Log (distance.magnitude);
		//Debug.Log (camera.orthographicSize);
	}
}