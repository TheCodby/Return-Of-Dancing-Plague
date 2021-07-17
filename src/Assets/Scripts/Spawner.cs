using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] spawnObject;
    int numEnemies = 3;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy();
    }

    void SpawnEnemy () 
     {
        Vector3 spawnPoint = new Vector3(10f, 0.57f, 0f);
        int Order = 1;
        bool thereNormal = false;
        for(int i = 0; i < numEnemies; i++)
        {
            int spawnObjectIndex = Random.Range(0,spawnObject.Length);

            Vector3 spawnPosition = spawnPoint;
            GameObject Enemy= Instantiate(spawnObject[spawnObjectIndex],spawnPosition,spawnObject[spawnObjectIndex].transform.rotation);
            Enemy.gameObject.GetComponent<SpriteRenderer>().sortingOrder = Order;
            if (Random.value >= 0.5 && !thereNormal)
            {
                Enemy.gameObject.GetComponent<Enemy>().dance = false;
                thereNormal = true;
            }
            if (i == 2 && !thereNormal)
            {
                Enemy.gameObject.GetComponent<Enemy>().dance = false;
                thereNormal = true;
            }
            Enemy.gameObject.GetComponent<Enemy>().unit = i;
            spawnPoint.x -= .4f;
            spawnPoint.y -= 1.11f;
            Order += 1;
        }
    }
}
