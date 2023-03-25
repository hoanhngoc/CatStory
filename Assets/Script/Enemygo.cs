using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemygo : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D;
    public float speed=5f;
    // Start is called before the first frame update
    void Start()
    {   
        Rigidbody2D = GetComponent<Rigidbody2D>();  
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime, 0f);
    }
}
