using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Audio;

public class TextWriter : MonoBehaviour
{
    private Text uiText;
    private string textToWrite;
    private float timePerCharacter;
    private float timer;
    private int characterIndex;
    private StoryWriter storyWriter;
    private bool stopit;
    private Text messageText;
    private int storyNum = 0;
    void Awake ()
    {
        storyWriter = GetComponent<StoryWriter>();
    }
    public void AddWriter (Text uiText, string textToWrite, float timePerCharacter)
    {
        this.uiText = uiText;
        this.textToWrite = textToWrite;
        this.timePerCharacter = timePerCharacter;
        characterIndex = 0;
        GameObject.Find("WriteSound").GetComponent<AudioSource>().mute = false ;
        storyNum += 1;
        stopit = false;
    }
    private void Update ()
    {
        if (uiText != null)
        {
            timer -= Time.deltaTime;
            while (timer <= 0f)
            {
                timer += timePerCharacter;
                characterIndex++;
                uiText.text = textToWrite.Substring(0, characterIndex);
                if (characterIndex >= textToWrite.Length)
                {
                    uiText = null;
                    return;
                }
            }
        }
        else
        {
            if(!stopit) {
                GameObject.Find("WriteSound").GetComponent<AudioSource>().mute = true ;
                StartCoroutine( HandleIt() );
            }
        }
    }
    private IEnumerator HandleIt()
    {
        stopit = true ;
        if(GameObject.Find("/MainMenu/Text") != null)
        {
            yield return new WaitForSeconds( 3 );
            if (storyNum == 1)
            {
                Destroy(GameObject.Find("/MainMenu/Story1"));
                ImageFade fadeScript1 = GameObject.Find("/MainMenu/Story2").AddComponent<ImageFade>();
                GameObject.Find("/MainMenu/Story2").GetComponent<Image>().enabled = true;
                messageText = GameObject.Find("/MainMenu/Text").GetComponent<Text>();
                AddWriter(messageText, "The epidemic returned in 2021 in Paris. \nUnfortunately, this time you didn't survive as you think.. you have to infect others with dance.\nGood luck", 1f);
            }else{
                Destroy(GameObject.Find("/MainMenu/Story2"));
                Destroy(GameObject.Find("/MainMenu/Text"));
                Destroy(GameObject.Find("/MainMenu/SkipText"));
                ImageFade fadeScript = GameObject.Find("/MainMenu/Image").AddComponent<ImageFade>();
                GameObject.Find("/MainMenu/StartText").GetComponent<Text>().enabled = true;
            }
        }
    }
}
