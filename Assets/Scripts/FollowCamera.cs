using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {

	public GameObject target, target2;
	private Vector3 positionOffsetOld = Vector3.zero;
	private Vector3 positionOffsetYoung = Vector3.zero;
	public bool orbitY;
	void Start (){
		positionOffsetOld = transform.position - target.transform.position;
		positionOffsetYoung = transform.position - target.transform.position;
	}
	
	void Update (){
		if (target !=null){
			transform.LookAt (target.transform);
			if (orbitY){
				transform.Translate(target.transform.position.x,target.transform.position.y,target.transform.position.z);
			}
			transform.position = target.transform.position+positionOffsetOld;
		}
		if (target2 !=null){
			transform.LookAt (target2.transform);
			if (orbitY){
				transform.Translate(target2.transform.position.x,target2.transform.position.y,target2.transform.position.z);
			}
			transform.position = target2.transform.position+positionOffsetYoung;
		}
	}
	
}