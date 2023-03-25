using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StamiaBar : MonoBehaviour
{
    private Player player;
    public Image Stamiapic;
    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();

    }
    private void Update()
    {
        Stamiapic.fillAmount = player.stamina / player.maxStamina;
    }
}
