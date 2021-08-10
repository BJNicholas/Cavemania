using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Music_Menu : MonoBehaviour
{
    static AudioSource backgroundMusic;
    private float musicVolume = 1f;
    //what the volume of the audio source will be

    private void Awake()
    {
        //DontDestroyOnLoad(transform.gameObject);
        GameObject music = GameObject.Find("BackgroundMusic");
        backgroundMusic = music.GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        backgroundMusic.volume = musicVolume;
    }

    public void updateVolume(float volume)
    {
        musicVolume = volume;
    }

    public void openMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
}
