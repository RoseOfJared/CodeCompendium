using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class BasicSaveLoad
{
	public static List<Game> savedGames = new List<Game>();
	
	public static void Save()
	{
		savedGames.Add(Game.current);
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = file.Create(Application.persistentDataPath + "/savedGames.sf");
		bf.Serialize(file, BasicSaveLoad.savedGames);
		file.Close();
	}
	
	public static void Load()
	{
		if(File.Exists(Application.persistentDataPath + "/savedGames.sf"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = file.Open(Application.persistentDataPath + "/savedGames.sf", FileMode.Open);
			BasicSaveLoad.savedGames= (List<Game>)bf.Deserialize(file);
			file.Close();
		}
	}
}