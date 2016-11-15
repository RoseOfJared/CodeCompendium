using UnityEngine;
using System.Collections;

public class MenuHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public virtual void AreYouSurePrompt() {}
    public virtual void ExitGameProtocol(bool DidTheyExit){}

    public virtual void LoadGame(){}
    public virtual void SaveGame(){}
    public virtual void changeMode() { }
    public virtual void SetAllFalse() { }
    public virtual void BackPreviousMenu() { }
    public virtual void MenuChange(int menuNumerator) { }
}
