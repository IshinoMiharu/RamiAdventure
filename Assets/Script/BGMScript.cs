using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMScript : MonoBehaviour
{
    private AudioSource audio;
    private AudioClip Sound;
    private string songName;
    public bool DontDestroyEnabled = true;
    void Start()
    {
        if (DontDestroyEnabled)
        {
            // SceneÇëJà⁄ÇµÇƒÇ‡è¡Ç¶Ç»Ç¢
            DontDestroyOnLoad(this);
        }
        {
            GameObject[] objs = GameObject.FindGameObjectsWithTag("BGM");
            if (1 < objs.Length) Destroy(objs[1]);
        }
        audio = GetComponent<AudioSource>();
    }
    void Update()
    {
        
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Scene loaded: " + scene.name);
        ReloadScene();
    }

    public void ReloadScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        if (currentSceneName == "Stage1")
        {
            songName = "Senka Wo Maziete";
            Sound = (AudioClip)Resources.Load("Sound/" + songName);
            audio.PlayOneShot(Sound);
        }
        else if (currentSceneName == "Stage2")
        {

        }
        else if (currentSceneName == "Stage3")
        {
 
        }
        else if (currentSceneName == "Stage4")
        {
            songName = "Senka Wo Maziete";
            Sound = (AudioClip)Resources.Load("Sound/" + songName);
            audio.PlayOneShot(Sound);
        }
    }
}