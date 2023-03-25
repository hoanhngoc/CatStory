using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DIALOGUE : MonoBehaviour
{
   
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    private int Index;
    public bool istalk;


    private void Awake()
    {
     gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }
  
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))

        {
            if (textComponent.text == lines[Index])

            {
                NextLine();
            }

            else
            {
                StopAllCoroutines();
                textComponent.text = lines[Index];  
            }
        }
    }

    public void StartDialogue()
    {
        
        Index=0;
        StartCoroutine(Typeline());
    }
    IEnumerator Typeline()
    {
        foreach(char c in lines[Index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed); 
        }
    }
    void NextLine()
    {
        if(Index<lines.Length-1)
        { Index++;
            textComponent.text = string.Empty;
            StartCoroutine(Typeline());
        }
        else
        {
            gameObject.SetActive(false);
            istalk = true;
        }
    }

}
