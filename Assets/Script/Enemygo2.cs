using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemygo2 : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D;
    public  float movespeed=3;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
       transform.Translate (Vector2.right*movespeed * Time.deltaTime,0f);
    }
}
