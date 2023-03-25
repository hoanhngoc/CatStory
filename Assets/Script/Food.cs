using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Food : MonoBehaviour, IDataPersistence
{
    [SerializeField] private string id;

    [ContextMenu("Generate guid for id")]
    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }


    private bool collected = false;

    private SpriteRenderer visual;




    private void Awake()
    {
        visual = this.GetComponentInChildren<SpriteRenderer>();


    }


    private void CollectFood()
    {
        collected = true;
        visual.gameObject.SetActive(false);


    }

    public void LoadData(GameData data)
    {
        data.foodsColleceted.TryGetValue(id, out collected);
        if (collected)
        {
            visual.gameObject.SetActive(false);

        }
    }

    public void SaveData(GameData data)
    {
        if (data.foodsColleceted.ContainsKey(id))
        {
  
                data.foodsColleceted.Remove(id);
            
        }
        data.foodsColleceted.Add(id, collected);
    }
    private void OnTriggerEnter2D()
    {
        if (!collected)
        {
            CollectFood();
        }
         
    }
}
  
