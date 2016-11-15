using UnityEngine;
using System.Collections;

public class FallTrigger : MonoBehaviour {

    bool IsInTrigger;
    public GameObject Player;
    public GameObject StartPoint;

	// Use this for initialization
	void Start ()
    {
        IsInTrigger = false;
	}
	
    void OnTriggerEnter()
    {
        IsInTrigger = true;
    }


    // Update is called once per frame
    void Update ()
    {
	   if(IsInTrigger)
        {
            Player.transform.position = StartPoint.transform.position;
            IsInTrigger = false;
        } 
	}
}
