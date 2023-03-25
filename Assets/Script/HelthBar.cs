using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class HelthBar : MonoBehaviour
{
    private Player player;
    public Image Hpbar;
    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();

    }
    private void Update()
    {
       Hpbar.fillAmount= player.health/player.maxHealth;
    }
}
