using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class youcantnotpass : MonoBehaviour
{
    [SerializeField] GameObject dialognotpass;
    // Start is called before the first frame update
    void Start()
    {
        dialognotpass.SetActive(false);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            dialognotpass.SetActive(true);
        }

    }


}
