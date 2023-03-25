using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class FoodCount : MonoBehaviour , IDataPersistence
{

    public Text foodcounText;   
    public int foodcount=0;
    // Start is called before the first frame update
    void Start()
    { 
       
        
    }

    // Update is called once per frame
    void Update()
    {
        foodcounText.text = " " + foodcount;
      
    }
   public void addcount()
    {
        foodcount++;
    }

    public void LoadData(GameData data)
    {
        foreach(KeyValuePair<string, bool> pair in data.foodsColleceted)
        {
            if(pair.Value)
            {
                foodcount++;
            }
        }
        this.foodcount=data.foodcount;
    }

    public void SaveData( GameData data)
    {
        data.foodcount = this.foodcount;
    }

 
}
