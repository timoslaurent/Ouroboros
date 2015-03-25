using UnityEngine;
using System.Collections;
public class PlayerManager : MonoBehaviour {
	//Porte de téléportation
	private Vector3 teleportingTo;
	private float teleportationTimer;
	private float timeToTeleport;
	public bool isTeleporting { get; private set; }

	//Vitesse de déplacement du vieux et du jeune
	public float speedOld, speedYoung;

	//Activation des piliers (Action du jeune)
	public bool isManipulating { get; set; }
	public GameObject piliers;

	//Dalle perspective
	public bool isPerspective { get; set; }
	//public Perspective dalleperspective;
	public GameObject dalleperspec;
	//public GameObject dalleperspec2;

	//Animation des personnages
	private Animator thisAnimator;
	
	//Mettre en pause le jeu
	bool isPaused = false;
	bool pauseGUI = false;

	// Use this for initialization
	void Start () {
		speedOld = 15f;
		speedYoung = 15f;

		thisAnimator = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {
		Movement();
		InputUser ();
	}

	void Movement() {




		//Left Joystick
		if (CompareTag ("p1")) {
			if (!isTeleporting)
			{
				transform.Translate (-Input.GetAxis ("L_Horizontal") * Time.deltaTime* speedOld,0,0, Space.World);
				transform.Translate (0,0,-Input.GetAxis ("L_Vertical") * Time.deltaTime * speedOld, Space.World);

				//Debug.DrawRay(transform.position, new Vector3(-Input.GetAxis ("L_Horizontal") * Time.deltaTime* speedOld, 0f, -Input.GetAxis ("L_Vertical") * Time.deltaTime * speedOld) * 10f, Color.yellow);

				transform.forward = new Vector3(-Input.GetAxis ("L_Horizontal") * Time.deltaTime* speedOld, 0f, -Input.GetAxis ("L_Vertical") * Time.deltaTime * speedOld);
			}
			else
			{
				if (transform.position != teleportingTo)
				{
					teleportationTimer += Time.deltaTime;
					if (teleportationTimer >= timeToTeleport)
					{
						transform.position = teleportingTo;
						teleportationTimer = 0;
						isTeleporting = false;
					}
				}
			}

			if (Input.GetAxis ("L_Horizontal") != 0 || Input.GetAxis ("L_Vertical") != 0)
			{
				thisAnimator.SetBool("stop", false);
				Debug.Log ("Horizontal " + Input.GetAxis ("L_Horizontal") + " " + "Vertical " + Input.GetAxis ("L_Vertical"));
			}
			else
			{
				thisAnimator.SetBool("stop", true);
			}
		}

		if (Input.GetAxis ("R_Horizontal") != 0 || Input.GetAxis ("R_Vertical") != 0)
		{
			thisAnimator.SetBool("stop", false);
		}
		else
		{
			thisAnimator.SetBool("stop", true);
		}
		//Right Joystick
		if (CompareTag ("p2")) {
			if (!isTeleporting)
			{
				transform.Translate (-Input.GetAxis ("R_Horizontal") * Time.deltaTime* speedYoung,0,0, Space.World);
				transform.Translate (0,0,-Input.GetAxis ("R_Vertical") * Time.deltaTime * speedYoung, Space.World);

				transform.forward = new Vector3(-Input.GetAxis ("R_Horizontal") * Time.deltaTime* speedYoung, 0f, -Input.GetAxis ("R_Vertical") * Time.deltaTime * speedYoung);
			}
			else
			{
				if (transform.position != teleportingTo)
				{
					teleportationTimer += Time.deltaTime;
					if (teleportationTimer >= timeToTeleport)
					{
						transform.position = teleportingTo;
						teleportationTimer = 0;
						isTeleporting = false;
					}
				}
			}
		}
	}

	void InputUser (){
		//Action du vieillard
		if (Input.GetButtonDown ("360_LB") && CompareTag ("p1")){

		}
		if (Input.GetAxis ("360_Triggers")< -0.5 && CompareTag ("p1")){
			if (isPerspective){
				if (dalleperspec.GetComponent<Perspective>().rotation !=0){
					dalleperspec.GetComponent<Perspective>().Plan.eulerAngles = new Vector3 (30,dalleperspec.GetComponent<Perspective>().rotation,0);
				}
				/*if (dalleperspec2.GetComponent<Perspective1>().rotation !=0){
					dalleperspec2.GetComponent<Perspective1>().Plan.eulerAngles = new Vector3 (30,dalleperspec2.GetComponent<Perspective>().rotation,0);
				}*/
				//dalleperspective.GetComponent<Perspective>().Plan.eulerAngles = new Vector3(30,75,0);
				//dalleperspective.rotation = 175;
				//dalleperspective.Plan.eulerAngles = new Vector3 (30,dalleperspective.rotation,0);
				//dalleperspective.Plan.eulerAngles = new Vector3 (30,160,0);
				/*if (dalleperspec.tag == "dallepers"){
					dalleperspec.GetComponent<Perspective>().rotation = 175;
					dalleperspec.GetComponent<Perspective>().Plan.eulerAngles = new Vector3 (30,dalleperspec.GetComponent<Perspective>().rotation,0);
				}*/
			} /*else if (isPerspective = false){
				if (dalleperspec.GetComponent<Perspective>().rotation ==175){
					dalleperspec.GetComponent<Perspective>().rotation = 135;
					dalleperspec.GetComponent<Perspective>().Plan.eulerAngles = new Vector3 (30, dalleperspec.GetComponent<Perspective>().rotation, 0);
				}
			}*/

			//Debug.Log ("isPerspective : " + isPerspective);
		}
		//Action de l'adolescent
		if (Input.GetButtonDown ("360_RB")&& CompareTag ("p2")){

		}
		if (Input.GetAxis ("360_Triggers")> 0.5 && CompareTag ("p2")) {
			speedYoung = 15f;
			if (isManipulating){
				Debug.Log ("Mécanisme activé");
				Debug.Log (isManipulating);
				piliers.GetComponent <Pilier>().pilier.animation["pilier"].speed = 1;;
				piliers.GetComponent <Pilier>().pilier.animation.Play ("pilier");
			 	/*p.animation["pilier"].speed = 1;
				p.animation.Play ("pilier");*/
			 }
		}

		if (Input.GetButtonDown ("360_StartButton")) {
			Debug.Log("Pause");
			Debug.Log(isPaused);
			if (!isPaused){
				isPaused = true;
				Time.timeScale = 0f;
				pauseGUI = true;
			} else{
				isPaused = false;
				Time.timeScale = 1.0f;
				pauseGUI = false;
			}
		}

	}

	public void teleport (float time, Vector3 target)
	{
		isTeleporting = true;
		teleportingTo = target;
		teleportationTimer = 0f;
		timeToTeleport = time;
	}

	void OnGUI (){
		if (pauseGUI) {
			GUI.Box(new Rect (Screen.width/2-90, Screen.height-50,180,25), "Suis-je devenu fou ?");
		}
	}
}