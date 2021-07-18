using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dance : MonoBehaviour
{
    public GameObject[] arrowObject;
    private IEnumerator coroutine;
    private GameObject circle;
    private GameObject player;
    private GameObject spawnManager;
    public int arrowsClicked = 0;
    void Start()
    {
        spawnManager = GameObject.Find("EnemySpawner");
    }
    // Update is called once per frame
    public void StartDance()
    {
        circle = GameObject.Find("Circle");
        player = GameObject.Find("PlayerSprite");
        circle.GetComponent<SpriteRenderer>().enabled = true;
        coroutine = CreateArrows(2.4f);
        GameObject.Find("DancingMusic").GetComponent<AudioSource>().Play(0);
        GameObject.Find("MainCamera").GetComponent<AudioSource>().Pause();
        StartCoroutine(coroutine);
    }
    private IEnumerator CreateArrows(float waitTime)
     {
         while(true)
        {
            yield return new WaitForSeconds(waitTime);
            Vector3 spawnPoint = new Vector3(10.98f, -3.77f , 0f);
            int spawnObjectIndex = Random.Range(0,arrowObject.Length);
            Vector3 spawnPosition = spawnPoint;
            GameObject Arrow= Instantiate(arrowObject[spawnObjectIndex],spawnPosition,arrowObject[spawnObjectIndex].transform.rotation, gameObject.transform);
        }
    }
    public void StopDance(bool win = true)
    {
        removeAllArrow();
        StopCoroutine(coroutine);
        circle.GetComponent<SpriteRenderer>().enabled = false;
        PlayerMovement playerScript = player.GetComponent<PlayerMovement>();
        Spawner spawner = spawnManager.GetComponent<Spawner>();
        Enemy enemyScript = playerScript.DanceWith.GetComponent<Enemy>();
        enemyScript.Dancing = false;
        playerScript.playerDancing = false;
        GameObject.Find("DancingMusic").GetComponent<AudioSource>().Pause();
        GameObject.Find("MainCamera").GetComponent<AudioSource>().Play();
        arrowsClicked = 0;
        if(win)
        {
            playerScript.score += 10;
            enemyScript.dance = true;
        }else{
            playerScript.DamagePlayer(1);
        }
        spawner.SpawnEnemy();
    }
    public void removeAllArrow()
    {
        foreach (Transform child in gameObject.transform) {
            GameObject.Destroy(child.gameObject);
        }
    }
    void Update()
    {
        
    }
}
