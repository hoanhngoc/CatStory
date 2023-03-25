using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    
    public GameObject[] PopUps;
    private int popUpIndex;
    public GameObject Player;
    public float waitTime = 20f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      
            for (int i = 0; i < PopUps.Length; i++)
            {

                if (i == popUpIndex)
                {
                    PopUps[i].SetActive(true);

                }
                else
                {
                    PopUps[i].SetActive(false);
                }
            }
            if (popUpIndex == 0)
            {
                if (waitTime <= 20f)
                {
                    if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A))
                    {

                        popUpIndex++;
                    }
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }

            }
            else if (popUpIndex == 1)
            {
                if (waitTime <= 15f)
                {
                    if (Input.GetKeyDown(KeyCode.LeftShift))
                    {
                        popUpIndex++;
                    }
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
            }
             else if (popUpIndex == 2)
        {
            if(waitTime<=10f)
            {
                if(Input.GetKeyDown(KeyCode.K))
                {
                    popUpIndex++;
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
            }
        }
        }
    
}
