using UnityEngine;
using System.Collections;

public enum CurrentMainMenu
{
    MainMenu,
    GraphicsMenu,
    CreditsMenu,
    ControlsMenu

};

public class MainMenu : MenuHandler {

    public GameObject[] Menus;
    public GameObject ExitPrompt;
    GameObject m_PreviousMenu;
    GameObject m_CurrentMenu;


	// Use this for initialization
	void Start ()
    {
        m_CurrentMenu = Menus[0];
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown("Escape")) { BackPreviousMenu(); } 
        
	}

    public override void SetAllFalse()
    {
        for (int i = 0; i < Menus.Length; i++)
        {
            Menus[i].SetActive(false);
        }
    }

    public override void LoadGame()
    {
        
    }

    public override void BackPreviousMenu()
    {
        m_CurrentMenu.SetActive(false);
        m_CurrentMenu = m_PreviousMenu;
        m_CurrentMenu.SetActive(true);
    }

    public override void MenuChange(int menuNumerator)
    {
        m_PreviousMenu = m_CurrentMenu;
        SetAllFalse();
        m_CurrentMenu = Menus[menuNumerator];
        m_CurrentMenu.SetActive(true);
    }

    public override void AreYouSurePrompt()
    {
        ExitPrompt.SetActive(true);
    }

    public override void ExitGameProtocol(bool DidTheyExit)
    {
        if (DidTheyExit)
        {
            Application.Quit();
        }
        else
        {
            ExitPrompt.SetActive(false);
        }
    }

}
