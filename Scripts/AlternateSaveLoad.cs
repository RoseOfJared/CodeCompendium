using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

//Should be in a Global Object
public static class AlternateSaveLoad
{
	public PlayerStatistics LocalCopyOFData;
	public bool IsSceneBeingLoaded = false;
	
	public void SaveData()
	{
		if(Directory.Exists("Saves"))
			Directory.CreateDirectory("Saves");
		
		BinaryFormatter formatter = new BinaryFormatter();
		FileStream saveFile = File.Create("Saves/save.sf");
		
		LocalCopyOFData = PlayerState.Instance.localPlayerData;
		formatter.Serialize(saveFile, LocalCopyOFData);
		
		saveFile.Close();
	}
	
	public void LoadData()
	{
		BinaryFormatter formatter = new BinaryFormatter();
		FileStream saveFile File.Open("Saves/save.sf", FileMode.Open);
		LocalCopyOFData = (PlayerStatistics)formatter.Deserialize(saveFile);
		saveFile.Close();
	}
	
}