using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 pos;
    private Transform tr;
    int PlayerUnit = 1;
    public int playerHearts = 3;
    private GameObject healthBar;
    private Object [] sprites;
    private Vector3 DistanceBetweenPoints = new Vector3(.4f, 1.11f, 0f);
    Animator m_Animator;
    private SpriteRenderer sr;
    private AudioSource audioLose;
    // Update is called once per frame
    void Start ()
    {
        pos = transform.position;
        tr = transform;
        PlayerUnit = 1;
        m_Animator = gameObject.GetComponent<Animator>();
        healthBar = GameObject.Find("/Canvas/Health");
        sprites = Resources.LoadAll ("/Assests/Icons/Health");
        audioLose = GameObject.Find("LoseSound").GetComponent<AudioSource>();
        sr = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && tr.position == pos && PlayerUnit > 0) {
            pos += DistanceBetweenPoints;
            PlayerUnit -= 1;
            m_Animator.SetBool("Jump", true);
        }
        else if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && tr.position == pos && PlayerUnit < 2) {
            pos -= DistanceBetweenPoints;
            PlayerUnit += 1;
            m_Animator.SetBool("Jump", true);
        }
        transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);
        if (transform.position == pos)
        {
            m_Animator.SetBool("Jump", false);
        }
    }
    private void OnTriggerEnter2D(Collider2D Object)
    {
        Enemy enemyScript = Object.GetComponent<Enemy>();
        bool isDancer = enemyScript.dance;
        int unit = enemyScript.unit;
        if (unit == PlayerUnit)
        {
            if (isDancer)
            {
                Debug.Log("Lose");
                DamagePlayer(1);
            }
            else
            {
                Debug.Log("Dance");
            }
        }
    }
    private void DamagePlayer(int Damage)
    {
        playerHearts -= Damage;
        audioLose.Play(0);
    }
}
