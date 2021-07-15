using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    public AudioMixer mixer;
	Slider slider;
	public void Start ()
	{
		slider = GetComponent<Slider>();
		slider.onValueChanged.AddListener( value => SetLevel( slider.value ) ) ;
		
	}
    public void SetLevel (System.Single sliderValue)
    {
        mixer.SetFloat("MenuMusicVol", Mathf.Log10(sliderValue) * 20);
    }
}
