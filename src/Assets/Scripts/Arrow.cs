using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Arrow : MonoBehaviour
{
    // Start is called before the first frame update
    public string side = "";
    public Sprite ClickedSprite;
    Vector3 startingPosition;
    private bool enter = false;
    public bool last = false; 
    private bool clicked = false;
    public float speed = 3f;
    Vector3 aPos;
    private Dance danceScript;
    private PlayerMovement playerScript;
    void Start()
    {
        playerScript = GameObject.Find("PlayerSprite").GetComponent<PlayerMovement>();
        danceScript = GameObject.Find("DanceManager").GetComponent<Dance>();
    }
    void Update ()
    {
        aPos = transform.position;
        aPos.y = aPos.z = 0;
        aPos.x = speed * Time.deltaTime;
        transform.position -= aPos;
        if(enter & !clicked)
        {
            if(side == "up")
            {
            if(Input.GetKeyDown(KeyCode.UpArrow)){
                clicked = true;
                danceScript.arrowsClicked += 1;
                GameObject.Find("ClickSound2").GetComponent<AudioSource>().Play(0);
                gameObject.GetComponent<SpriteRenderer>().sprite = ClickedSprite;
                if(danceScript.arrowsClicked == 10)
                {
                    danceScript.StopDance(true);
                }
            }else if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)) {
                clicked = true;
                danceScript.StopDance(false);
            }
        }else if(side == "down")
        {
            if(Input.GetKeyDown(KeyCode.DownArrow)){
            clicked = true;
            danceScript.arrowsClicked += 1;
            GameObject.Find("ClickSound2").GetComponent<AudioSource>().Play(0);
            gameObject.GetComponent<SpriteRenderer>().sprite = ClickedSprite;
            if(danceScript.arrowsClicked == 10)
                {
                    danceScript.StopDance(true);
                }

            }else if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)){
                clicked = true;
                danceScript.StopDance(false);
            }
        }else if(side == "left")
        {
            if(Input.GetKeyDown(KeyCode.LeftArrow)){
                clicked = true;
                danceScript.arrowsClicked += 1;
                GameObject.Find("ClickSound2").GetComponent<AudioSource>().Play(0);
                gameObject.GetComponent<SpriteRenderer>().sprite = ClickedSprite;
                if(danceScript.arrowsClicked == 10)
                {
                    danceScript.StopDance(true);
                }

            }else if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.RightArrow)){
                clicked = true;
                danceScript.StopDance(false);
            }
        }else if(side == "right")
        {
            if(Input.GetKeyDown(KeyCode.RightArrow)){
                clicked = true;
                danceScript.arrowsClicked += 1;
                GameObject.Find("ClickSound2").GetComponent<AudioSource>().Play(0);
                gameObject.GetComponent<SpriteRenderer>().sprite = ClickedSprite;
                if(danceScript.arrowsClicked == 10)
                {
                    danceScript.StopDance(true);
                }

            }else if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.UpArrow)){
                clicked = true;
                danceScript.arrowsClicked += 1;
                danceScript.StopDance(false);
            }
        }
        }
    }
    private void OnTriggerEnter2D(Collider2D Object)
    {
        if (Object.gameObject.name == "Circle")
        {
            enter = true;
        }
    }
    private void OnTriggerExit2D(Collider2D Object)
    {
        if (Object.gameObject.name == "Circle")
        {
            if(!clicked && enter){
                danceScript.StopDance(false);
            }
            enter = false;
        }
    }
}
