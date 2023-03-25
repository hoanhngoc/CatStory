using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    
    public Dialogue1 dialogueScript;
    private bool PlayerDectedted;
  

// Detect tigger Player
    private void OnTriggerEnter2D(Collider2D collision)
    {
            // if tigger Player enabale playerdected and show indicator
            if (collision.tag == "Player")
            {
                PlayerDectedted = true;
                dialogueScript.ToggleIndicator(PlayerDectedted);
            }
        
        
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerDectedted = false;
            dialogueScript.ToggleIndicator(PlayerDectedted);
        }
      
    }

    private void Update()
    {
        if (PlayerDectedted && Input.GetKeyDown(KeyCode.E))
        {
            dialogueScript.Startdialogue();
        }


    }
}



