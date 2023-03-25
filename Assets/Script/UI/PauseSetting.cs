using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PauseSetting : MonoBehaviour
{
    [SerializeField] GameObject SettingButton;
    [SerializeField] GameObject QuitButton;
    [SerializeField] GameObject settingmenu;
    [SerializeField] GameObject QuitsaveMenu;
   
    // Start is called before the first frame update
    void Start()
    {   QuitsaveMenu.SetActive(false);
        settingmenu.SetActive(false);

        SettingButton.SetActive(true);
        QuitButton.SetActive(true);
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void pausegame()
    {      
        Time.timeScale = 0f;

        settingmenu.SetActive(true);
        SettingButton.SetActive(false);

    }
    public void quitsavebutton()
    {
        QuitsaveMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Quitgame()
    {
       Application.Quit();
    }
    public void turnofquitbutton()
    {
        QuitsaveMenu.SetActive(false);
        Time.timeScale = 1f;
    }
}

