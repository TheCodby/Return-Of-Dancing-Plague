using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = .5f;
    int EnemyUnit;
    public bool dance = true;
    public int unit = 0;
    private Vector3 pos;
    Animator m_Animator;
    // Start is called before the first frame update
    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
        pos = transform.position;
        if (dance)
        {
            m_Animator.SetBool("Dance", true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        pos -= new Vector3(50, 0,0);
        transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);
    }
}
