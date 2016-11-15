using UnityEngine;
using System.Collections;

public class EventTriggerTest : MonoBehaviour
{
	void Update()
	{
		if(Input.GetKeyDown("Q"))
		{
			EventManager.TriggerEvent("test");
		}
		
		if(Input.GetKeyDown("o"))
		{
			EventManager.TriggerEvent("Spawn");
		}
		
		if(Input.GetKeyDown("p"))
		{
			EventManager.TriggerEvent("Destroy")
		}
	}

}