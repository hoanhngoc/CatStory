using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject deathPanel;
    public void toggleDeathpanel()
    {
        deathPanel.SetActive(!deathPanel.activeSelf);
    }
}
