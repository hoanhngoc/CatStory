using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMap : MonoBehaviour
{
    [SerializeField]
    private LevelConection _conection;

    [SerializeField]
    private string _SceneName;

    [SerializeField]
    private Transform _spawnpoint; 

   
    
    public string sceneName;
    // Start is called before the first frame update
    private void Start()
    {

       if(_conection == LevelConection.ActiveConnection)
        {
            FindObjectOfType<Player>().transform.position = _spawnpoint.position;
        }
      }



    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {      
        var Player = other.collider.GetComponent<Player>();
        if(Player != null)
        {
        LevelConection.ActiveConnection = _conection;
        SceneManager.LoadScene(_SceneName);

        }
    }
}
