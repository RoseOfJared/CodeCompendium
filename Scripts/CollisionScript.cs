using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CollisionScript : MonoBehaviour {

	public Text HarrasmentMessage;

	private bool Triggered;

	void OnTriggerExit()
	{

	}

	void OnTriggerEnter()
	{
		Triggered = true;
	}

	void OnCollisionStay()
	{
	}


	// Use this for initialization
	void Start () 
	{
		Triggered = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Triggered == true)
		{
			HarrasmentMessage.text = "I am fucking triggered, Patreon pls";
			Debug.Log("I am fucking triggered, Patreon pls");
		}
	}
}
