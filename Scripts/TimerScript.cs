using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour {
	public Text timerLabel;
	public float time;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () 
	{
		if(time != 0.00)
		{
			time -= Time.deltaTime;
			var seconds = time % 60;
			var fraction = (time * 100) % 100;
			
			//update the label value
			timerLabel.text = string.Format ("{0:00} : {1:00}", seconds, fraction);
		}
	}
}
