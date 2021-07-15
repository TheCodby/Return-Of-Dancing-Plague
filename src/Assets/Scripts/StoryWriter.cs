using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoryWriter : MonoBehaviour
{
    [SerializeField] private TextWriter textWriter;
    private Text messageText;
    private void Awake ()
    {
        messageText = GameObject.Find("/MainMenu/Text").GetComponent<Text>();
        Application.targetFrameRate = 10;
    }
    // Start is called before the first frame update
    private void Start()
    {
        textWriter.AddWriter(messageText, "The dancing plague of 1518 was a dancing mania case that occurred during the the Holy Roman Empire in Strasbourg, Alsace (modern-day France) from July 1518 to September 1518. Somewhere between 50 and 400 people kept dancing uncontrollably. Some people said that the first dancer was a woman.", 1f);
    }

}
