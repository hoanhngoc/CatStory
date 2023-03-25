using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private  Animator animator;
    [SerializeField] private AudioClip TrapSound;

    // Start is called before the first frame update
    void Start()
    {
     
       animator = GetComponent<Animator>();
        
     }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            animator.SetBool("istrap", true);
            SoundManager.instance.PlaySound(TrapSound);
          
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
       Destroy(this.gameObject);
    }
}
