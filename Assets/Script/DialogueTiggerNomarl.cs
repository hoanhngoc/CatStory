using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DialogueTiggerNomarl : MonoBehaviour
{
    public Dialogue1 dialogueScript;
    [SerializeField] private Player player;
    private bool PlayerDectedted;

    private void Start()
    {
        PlayerDectedted = false;
        
    }
    private void Update()
    {
        if (PlayerDectedted && Input.GetKeyDown(KeyCode.E))
        {
            dialogueScript.Startdialogue();
        }
       if (player.health == 100)
        {
            PlayerDectedted = true;
            dialogueScript.ToggleIndicator(PlayerDectedted);
            
        }
       
    }
 
}
