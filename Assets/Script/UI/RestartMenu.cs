using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartMenu : MonoBehaviour
{
    [SerializeField] GameObject DEadmune;

    // Start is called before the first frame update
    void Start()
    {
        DEadmune.SetActive(false);
       
    }

    // Update is called once per frame
    void Update()
    {
        
      
    }

    public void RestartTheGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        DEadmune.SetActive(false);

    }
    public void Menudead()
    {
        DEadmune.SetActive(true);
    }

}
