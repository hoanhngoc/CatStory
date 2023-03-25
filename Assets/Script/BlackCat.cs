using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlackCat : MonoBehaviour
{
    Rigidbody2D Rigidbody2D;
    public FoodCount foodtome;

    public bool catdie = false;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(foodtome.foodcount<5)
            {
                Debug.Log("not enough food");
            }
            if(foodtome.foodcount>=5)
            {
                SceneManager.LoadScene("Cutscene 1");
              
            }

        }
    }
  
}
