using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class PauseMenu : MenuHandler
{

    public static PauseMenu Instance;
    public GameObject[] Menus;
    GameObject m_PreviousMenu;
    GameObject m_CurrentMenu;


    // Use this for initialization
    void Start ()
    {
        m_CurrentMenu = Menus[0];
        //OnLevelWasLoaded(SceneManager.GetActiveScene().buildIndex);

        if (Instance == null)
        {
            //This tells unity not to delete the object when you load another scene
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
   
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown("Escape"))
        {
            BackPreviousMenu();
        }
        
    }

    public override void SaveGame()
    {
        
    }

    public override void SetAllFalse()
    {
        for (int i = 0; i < Menus.Length; i++)
        {
            Menus[i].SetActive(false);
        }
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


    //void OnLevelWasLoaded(int level)
    //{
    //    //PauseMenu = GameObject.FindGameObjectWithTag("Pause Menu");
    //    GameManager.Instance.PauseMenuPtr = this;
    //}

}
