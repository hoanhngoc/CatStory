using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadScene : MonoBehaviour
{
    public float changeTime;
    public string sceneName;    
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        changeTime-= Time.deltaTime;
        if(changeTime <= 0)
        {

            SceneManager.LoadScene(sceneName);
         

        }

    }


}
