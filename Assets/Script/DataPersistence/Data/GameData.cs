using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] 
public class GameData 
{
    public string currentSceneName;

    public int foodcount;
    
    public Vector3 PlayerPosition;
   
    public float Health;
    

    public SerializableDictionary<string, bool> foodsColleceted;

    public GameData()
    {
        this.Health = 0;
     
        PlayerPosition = Vector3.zero;

        foodsColleceted = new SerializableDictionary<string, bool>();

        currentSceneName = "";

    }
}
