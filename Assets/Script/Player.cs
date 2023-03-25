using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour , IDataPersistence
{
    public float health;
    public float maxHealth=100;
    public float stamina = 6f;
    public float maxStamina = 6f;

    public float speed = 3f;
    public float Movespeed = 3f;
    public float Runspeed = 8f;
    public float fatigueTime = 0f;
    public float drainRate = 1f;
    public float reChange = 1f;

    public static Player Instance;

    bool isFatigued;
    bool isRunning;

  
    Rigidbody2D Rigidbody2D;
    Animator Anim;

    public FoodCount foodcountText;

    [SerializeField] private  Material flashMaterial;
    [SerializeField] private float flashSpeed;

    private SpriteRenderer spriteRenderer;
    private Material originalmaterial;
    private Coroutine flashroutine;

    [SerializeField] private AudioClip enemyhitsound;
    [SerializeField] private AudioClip foodcollectsound;

    private Vector2 moveDirection;
    private static bool PlayerExists;

    // Start is called before the first frame update
    void Start()
    {
                
        health =20;
       
        Rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalmaterial = spriteRenderer.material;
        Anim = GetComponent<Animator>();
                    
        if (!PlayerExists)
        {
            PlayerExists = true;
            DontDestroyOnLoad(transform.gameObject);

        }
       
        else
        { 
            Destroy(gameObject);
        }
        
        
    }


    // Update is called once per frame
    void Update()
    {
        UpdateHealth();
        StaminaSystem();
        Moving();
        SetAnimation();
        
    }

    private void FixedUpdate()
    {
        

    }

    public void LoadData(GameData data)
    {
        this.transform.position = data.PlayerPosition;
        this.health=data.Health;
    }
    public void SaveData(GameData data)
    {
        data.PlayerPosition = this.transform.position;
        if(health<=0)
        { data.Health = 50; }
        else
        {
            data.Health = this.health;
        }
       
    }
    private void Moving()
    {

        Rigidbody2D.velocity = moveDirection * speed;

        float MoveX = Input.GetAxisRaw("Horizontal");
        float MoveY = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(MoveX, MoveY);
        Vector3 characterScale = transform.localScale;//thay doi sprite trai phai
        if (MoveX < 0)
        {
            characterScale.x = -1;
        }
        if (MoveX > 0)
        {
            characterScale.x = 1;
        }
        transform.localScale = characterScale;
    }
    private void StaminaSystem()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (stamina > 0 && !isFatigued)
            {
                speed = Runspeed;
                isRunning = true;

            }
            else if (isRunning || isFatigued)
            {
                speed = Movespeed;
                isRunning = false;

            }

        }
        else
        {
            if (isRunning || isFatigued)
            {
                speed = Movespeed;
                isRunning = false;

            }
        }

        if (isRunning)
        {

            stamina -= Time.deltaTime * drainRate;

        }

        else if (!isRunning && stamina > 0 && stamina < 5)
        {
            stamina += Time.deltaTime * reChange;
        }
        if (stamina <= 0 && fatigueTime <= 3)
        {
            fatigueTime += Time.deltaTime;
            isFatigued = true;
        }
        else if (fatigueTime >= 3)
        {
            stamina += Time.deltaTime * reChange;
            isFatigued = false;
            fatigueTime = 0;
        }

    }


    private void SetAnimation()
    {
        if (moveDirection.magnitude > Mathf.Epsilon && speed == 3f)
        {
            Anim.SetBool("IsWalking", true);

        }
        else
        {
            Anim.SetBool("IsWalking", false);
        }
        if (moveDirection.magnitude > Mathf.Epsilon && speed == 8f)
        {
            Anim.SetBool("IsRunning", true);
        }
        else
        {
            Anim.SetBool("IsRunning", false);
        }
        if(Input.GetKeyDown(KeyCode.K))
        {
            Anim.SetBool("isAttack", true);
        }
        else
        {
            Anim.SetBool("isAttack", false);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Food")
        {   
            foodcountText.addcount();
            SoundManager.instance.PlaySound(foodcollectsound);

            if (health < maxHealth)
            { health = health + 20; }
        }

        if(collision.gameObject.tag== "Enemy")
        {
            SoundManager.instance.PlaySound(enemyhitsound);
            health = health - 10;
            Flash();
            
        }
        if (collision.gameObject.tag == "trap")
        {
            health = health - 10;
            Flash();
  
        }
    }
    public void Flash()
    {
        // If the flashRoutine is not null, then it is currently running.
        if (flashroutine != null)
        {
            // In this case, we should stop it first.
            // Multiple FlashRoutines the same time would cause bugs.
            StopCoroutine(flashroutine);
        }

        // Start the Coroutine, and store the reference for it.
        flashroutine = StartCoroutine(FlashRoutine());
    }

    private IEnumerator FlashRoutine()
    {
        // Swap to the flashMaterial.
        spriteRenderer.material = flashMaterial;

        // Pause the execution of this function for "duration" seconds.
        yield return new WaitForSeconds(flashSpeed);

        // After the pause, swap back to the original material.
        spriteRenderer.material = originalmaterial;

        // Set the routine to null, signaling that it's finished.
        flashroutine = null;
    }
    private void UpdateHealth()
    {
        if(health<=0)
        {
            health=0;
            Playerdie();
            health = 50;
        }
    }
    private void Playerdie()
    {
        LevelManager.instance.GameOver();
        Time.timeScale = 0f;
      
    }
}

