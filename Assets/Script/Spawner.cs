using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] GameObject[] NPC;
    [SerializeField] float secandSpawn = 1f;
    [SerializeField] float minTras;
    [SerializeField] float maxTras;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(NPCspawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator NPCspawn()
    {
        while(true)
        {
            var wanted= Random.Range(minTras, maxTras);
            var position= new Vector3(transform.position.x, wanted);
            GameObject gameObject = Instantiate(NPC[Random.Range(0,NPC.Length)],position,Quaternion.identity);
            yield return new WaitForSeconds(secandSpawn);


        }
    }
}
