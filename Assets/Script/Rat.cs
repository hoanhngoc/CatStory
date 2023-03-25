using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rat : MonoBehaviour
{
    [SerializeField] float movespeed = 3f;
    Rigidbody2D body2d;
    public float MaxHealth = 10;
    public float currentHealth ;
    public HealthBarSYStem Healthbar;


    private bool collected = false;
    [SerializeField] private AudioClip enemyhitsound;
    private SpriteRenderer visual;
  


    // Start is called before the first frame update
    void Start()
    {       
        body2d = GetComponent<Rigidbody2D>();

        currentHealth=MaxHealth;
        Healthbar.Sethealth(currentHealth, MaxHealth);
        
    }

    // Update is called once per frame
    private void Awake()
    {
        visual = this.GetComponentInChildren<SpriteRenderer>();
    }
    void Update()

    { 
        
        if(IsInvokingright())
        {

            // move right
            body2d.velocity = new Vector2(movespeed, 0f);

        }
        else 
        {// move left
          body2d.velocity = new Vector2(-movespeed, 0f);}
        }
        private void OnTriggerEnter2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(body2d.velocity.x)),transform.localScale.y);
        if(collision.gameObject.tag=="AttackArea")
        {
            SoundManager.instance.PlaySound(enemyhitsound);
            currentHealth = currentHealth - 3;
            Healthbar.Sethealth(currentHealth, MaxHealth);

            if (currentHealth <= 0)
            { 
                   
                Destroy(gameObject);
                if (!collected)
                { 
                    
                    CollectFood();
                   
                }
            }

        }
    }
    private bool IsInvokingright()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }
    private void CollectFood()
    {
        collected = true;
        visual.gameObject.SetActive(false);

    }
}
