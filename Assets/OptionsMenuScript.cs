using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class OptionsMenuScript : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] AudioMixer MainMixer;
    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.value = 10;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeVolume();
    }

    public void ChangeVolume() 
    {
        MainMixer.SetFloat("MasterVolume", volumeSlider.value);
        Debug.Log(volumeSlider.value);
    }

    public void openOptions(){
        gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void closeOptions()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
