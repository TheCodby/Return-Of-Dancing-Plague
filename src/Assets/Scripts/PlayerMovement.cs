using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 pos;
    private Transform tr;
    int PlayerUnit = 1;
    public int score = 0;
    public bool lost = false;
    public int playerHearts = 3;
    public bool playerDancing = false;
    private GameObject healthBar;
    private Object [] sprites;
    public Collider2D DanceWith;
    private Vector3 DistanceBetweenPoints = new Vector3(.4f, 1.11f, 0f);
    Animator m_Animator;
    private SpriteRenderer sr;
    private AudioSource audioLose;
    private Dance danceScript;
    private GameObject spawnManager;
    private PlayerMovement playerScript;
    // Update is called once per frame
    void Start ()
    {
        Cursor.visible = false;
        pos = transform.position;
        tr = transform;
        PlayerUnit = 1;
        m_Animator = gameObject.GetComponent<Animator>();
        healthBar = GameObject.Find("/Canvas/Health");
        sprites = Resources.LoadAll ("/Assests/Icons/Health");
        audioLose = GameObject.Find("LoseSound").GetComponent<AudioSource>();
        sr = GetComponent<SpriteRenderer>();
        danceScript = GameObject.Find("DanceManager").GetComponent<Dance>();
        spawnManager = GameObject.Find("EnemySpawner");
        playerScript = GameObject.Find("PlayerSprite").GetComponent<PlayerMovement>();
    }
    void Update()
    {
        if (((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && tr.position == pos && PlayerUnit > 0) && !playerDancing) {
            pos += DistanceBetweenPoints;
            PlayerUnit -= 1;
            gameObject.GetComponent<SpriteRenderer>().sortingOrder -= 1;
            m_Animator.SetBool("Jump", true);
        }
        else if (((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && tr.position == pos && PlayerUnit < 2) && !playerDancing) {
            pos -= DistanceBetweenPoints;
            PlayerUnit += 1;
            m_Animator.SetBool("Jump", true);
            gameObject.GetComponent<SpriteRenderer>().sortingOrder += 1;
        }
        transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);
        if (transform.position == pos)
        {
            m_Animator.SetBool("Jump", false);
        }
    }
    private void OnTriggerEnter2D(Collider2D Object)
    {
        Spawner spawner = spawnManager.GetComponent<Spawner>();
        Enemy enemyScript = Object.GetComponent<Enemy>();
        bool isDancer = enemyScript.dance;
        int unit = enemyScript.unit;
        if (unit == PlayerUnit)
        {
            if (isDancer)
            {
                Debug.Log("Lose");
                DamagePlayer(1);
                spawner.SpawnEnemy();
            }
            else
            {
                Debug.Log("Dance");
                enemyScript.Dancing = true;
                DanceWith = Object;
                danceScript.StartDance();
                playerDancing = true;
            }
        }
    }
    public void DamagePlayer(int Damage)
    {
        playerHearts -= Damage;
        audioLose.Play(0);
        if(playerHearts == 0)
        {
            EndGame();
        }
    }
    public void EndGame()
    {
        lost = true;
        GameObject.Find("MainCamera").GetComponent<AudioSource>().Pause();
        GameObject.Find("MusicOver").GetComponent<AudioSource>().Play(0);
        ImageFade fadeScript = GameObject.Find("/Canvas/GameOver").AddComponent<ImageFade>();
        GameObject.Find("/Canvas/PressSpace").GetComponent<TextMeshProUGUI>().enabled = true;
        GameObject.Find("/Canvas/GameOverText").GetComponent<TextMeshProUGUI>().enabled = true;
        GameObject.Find("/Canvas/YourScore").GetComponent<TextMeshProUGUI>().enabled = true;
        GameObject.Find("/Canvas/YourScore").GetComponent<TextMeshProUGUI>().text = "You Score: " + playerScript.score.ToString();
    }
}
