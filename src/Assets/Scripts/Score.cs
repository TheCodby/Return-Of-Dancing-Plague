using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    private PlayerMovement playerScript;
    private TextMeshProUGUI score;
    void Start()
    {
        player = GameObject.Find("PlayerSprite");
        playerScript = player.GetComponent<PlayerMovement>();
        score = gameObject.GetComponent<TextMeshProUGUI>(); 
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + playerScript.score.ToString();
    }
}
