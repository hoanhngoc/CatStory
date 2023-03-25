using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue1 : MonoBehaviour
{
    public GameObject window;

    public GameObject Indicator;
    // Dialogue list
    public List<string> dialogues;

    private int index;

    //writing speed
    public float writingspeed;

    private int CharIndex;

    private bool started;

    // Text Component
    public TMP_Text dialogueText;

    // wait for next boolean
    private bool WaitforNext;

    private void Awake()
    {
        ToggleIndicator(false);
        ToggleWindown(false);
    }
    public void ToggleWindown(bool show)
    {
        window.SetActive(show);
    }

    public void ToggleIndicator(bool show)
    {
        Indicator.SetActive(show);
    }
    // Star Dialogue;
    public void Startdialogue()
    {
        if(started)
            return;
        started=true;
        window.SetActive(true);
        Indicator.SetActive(false);
        GetDialogue(0);

    }
    private void GetDialogue(int i)
    {
        //start index at zero
        index = i;

        CharIndex = 0;

        dialogueText.text = string.Empty;
        //Start Writing
        StartCoroutine(Writing());
    }  
    
    //End Dialogue; 
    public void EndDialogue()
    {
        started=false;
        WaitforNext=false;
        StopAllCoroutines();    
        ToggleWindown(false);
    }

    IEnumerator Writing()
    {
        yield return new WaitForSeconds(writingspeed);
        string currentDialogue = dialogues[index];
        dialogueText.text += currentDialogue[CharIndex];
        CharIndex++;
        // make sure end of chat
        if(CharIndex < currentDialogue.Length)
        {
          
          yield return new WaitForSeconds(writingspeed);
          StartCoroutine(Writing());

        }
        else
        {
            // end this chat
            WaitforNext = true;
        }

       
    }
    private void Update()
    {
        if (!started)
            return;
        if(WaitforNext && Input.GetKeyDown(KeyCode.Space))
        {
            WaitforNext = false;
            index++;

            if (index < dialogues.Count)
            {
                GetDialogue(index);
            }
            else
            {
                
                EndDialogue();
            }
        }
    }
}
