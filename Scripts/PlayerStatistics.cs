using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[Serializable]
public class PlayerStatistics
{
	public int SceneID;
	public float PositionX, PositionY, PositionZ;
	
	public float Health;
	public float Ammo;
	public float XP;
	public int Cash;
	
	
}

