using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject setttingmenu;
    [SerializeField] GameObject Main;
    [Header("Menu Buttons")]
    [SerializeField] private Button newgamebutton;
    [SerializeField] private Button Continuebutton;


    
    // Start is called before the first frame update
    void Start()
    {
        if(!DataPersistenceManager.instance.HasGameData())
        {
            Continuebutton.interactable = false;
        }
        Main.SetActive(true);
        setttingmenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NewGame()
    {
        DisableMenubuton();


        DataPersistenceManager.instance.NewGame();
        SceneManager.LoadSceneAsync("Cutscene 0");
       
    }
    public void LoadSave()
    {
        DisableMenubuton();
        SceneManager.LoadSceneAsync(DataPersistenceManager.instance.GetsavedSceneName());
    }

    public void OpenSetting()
    {
        setttingmenu.SetActive(true);
        Main.SetActive(false);

    }
    public void CloseSetting()
    {

    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("quitting");
    }

    private void DisableMenubuton()
    {
        newgamebutton.interactable = false;
        Continuebutton.interactable=false;
    }
    public void OncontinueGameClick()
    {
        DisableMenubuton();
        DataPersistenceManager.instance.SaveGame();
        SceneManager.LoadSceneAsync(DataPersistenceManager.instance.GetsavedSceneName());

    }
}
