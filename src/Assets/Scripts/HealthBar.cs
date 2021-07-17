using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public Sprite fullhp;
    public Sprite lesshp;
    public Sprite halfhp;
    public Sprite nonhp;
    private Image sr;
    private GameObject player;
    
    void Awake() {
        sr = GetComponent<Image>();
    }
   void Update() {
        player = GameObject.Find("PlayerSprite");
        int hearts = player.GetComponent<PlayerMovement>().playerHearts;
        if (hearts == 3) {
            sr.sprite = fullhp;
        }
        else if (hearts == 2) {
            sr.sprite = lesshp;
        }
        else if (hearts == 1) {
            sr.sprite = halfhp;
        }
        else {
            sr.sprite  = nonhp;
        }
    }
}