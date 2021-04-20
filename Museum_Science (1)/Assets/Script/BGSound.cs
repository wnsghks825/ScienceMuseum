using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGSound : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip sound;

    public AudioSource source
    {
        get
        {
            return GetComponent<AudioSource>();
        }
    }
    private void Update()
    {
        //Scene scene = SceneManager.GetActiveScene();
        //if (scene.name=="VideoScene")
        //{
        //    this.GetComponent<AudioSource>().Pause();
        //    print(this.GetComponent<AudioSource>().name);
        //}
        if (source.isPlaying == false)
        {
            this.GetComponent<AudioSource>().Play();
        }
    }
    private static BGSound instance = null;
    public static BGSound Instance
    {
        get { return instance; }
    }
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
