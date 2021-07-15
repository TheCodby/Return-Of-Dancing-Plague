using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Escape : MonoBehaviour
{
    public void Update ()
    {
        if (Input.GetKeyDown("space"))
        {
            if (GameObject.Find("/MainMenu/Text") != null)
            {
                SkipStory();
            }
            else
            {
                PlayGame(); 
            }
        }
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void SkipStory()
    {
        Destroy(GameObject.Find("/MainMenu/Story1"));
        Destroy(GameObject.Find("/MainMenu/Story2"));
        Destroy(GameObject.Find("/MainMenu/Text"));
        Destroy(GameObject.Find("/MainMenu/SkipText"));
        ImageFade fadeScript = GameObject.Find("/MainMenu/Image").AddComponent<ImageFade>();
        GameObject.Find("/MainMenu/StartText").GetComponent<Text>().enabled = true;
    }
}
