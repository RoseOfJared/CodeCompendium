using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class PlayerStateControl : MonoBehaviour
{
	public static PlayerStateControl control;
	
	public float health;
	public float experience;
	public float money;
	
	void Awake()
	{
		if(control == null)
		{
			DontDestroyOnLoad(gameObject);
			control = this;
		}
		else if(control != this)
		{
			Destroy(gameObject);
		}
		
	}
	
	public void Save()
	{
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = file.Open(Application.persistentDataPath + "/playerState.dat", FileMode.Open);
		
		PlayerData data = new PlayerData();
		data.health = health;
		data.experience = experience;
		data.money = money;
		
		bf.Serialize(file, data);
		file.Close();
	}
	
	public void Load()
	{
		if(File.Exists(Application.persistentDataPath + "/playerState.dat"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = file.Open(Application.persistentDataPath + "/playerState.dat");
			PlayerData data = (PlayerData)bf.Deserialize(file);
			file.Close();
			
			health = data.health;
			experience = data.experience;
			money = data.money;
		}
	}
	
	
}
[Serializable]
class PlayerData
{
	public float health;
	public float experience;
	public int money;
}

