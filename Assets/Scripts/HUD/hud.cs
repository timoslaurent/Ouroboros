using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class hud : MonoBehaviour {
	public GameObject serpents;

	// Use this for initialization
	void Start () {
		Text serpent = serpents.GetComponent<Text>();
		serpent.text = "Serpents : ";
		serpent.alignment = TextAnchor.UpperLeft;
		 
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
