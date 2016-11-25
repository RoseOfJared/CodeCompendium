using UnityEngine;
using System.Collections;

public class SaveLoadEventSystem : MonoBehaviour
{
	public delegate void SaveDelegate(object sender, EventArgs args);
	
	//public event SaveDelegate SaveEvent;
	/*Declares a public event, anyone can subscribe
	 * to the event, which accepts functions as 
	 * described by SaveDelegate and its called SaveEvent
	*/
}

[Serializable]
public class PlayerState()
{
	public int SceneID;
	public float PositionX, PositionY, PositionZ;
	public float ammo;
	public float health;
	public float experience;
	public int money;
}

[Serializable]
public class OptionsState()
{
	public int FieldOfView;
	public int MainVolume;
	public int MusicVolume;
	public int EffectVolume;
	public bool SubtitleCheck;
}

//in the example of PotionDroppable's Start or awake functions
// GlobalObject Instance saveEvent += SaveFunction;
//
//In PotionDroppable's OnDestroy() function
// GlobalObject Instance SaveEvent -= SaveFunction;
//
//[...]
//public void SaveFunction(object sender, EventArgs args)
//{
//	here is code that saves this instance of an bject	
//}


