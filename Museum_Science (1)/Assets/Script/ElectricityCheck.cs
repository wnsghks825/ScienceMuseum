using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElectricityCheck : MonoBehaviour
{
    public Image[] Star;
    public Image Bulb;
    public GameObject Success;
    int i;

    private AudioSource audioOK;
    private AudioSource audioWrong;
    private AudioClip OK;
    private AudioClip Wrong;

    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        audioOK = GameObject.Find("퀴즈 맞춤").GetComponent<AudioSource>();
        audioWrong = GameObject.Find("퀴즈 틀림").GetComponent<AudioSource>();
        OK = (AudioClip)Resources.Load("퀴즈 맞춤");
        Wrong = (AudioClip)Resources.Load("퀴즈 틀림");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Electricity"))
        {
            Star[i].gameObject.SetActive(true);
            audioOK.clip = OK;
            audioOK.Play();
            i++;
            collision.gameObject.tag = "Non_Elec";
        }
        else if (collision.gameObject.CompareTag("Non_Elec"))
        {
            audioOK.clip = Wrong;
            audioOK.Play();
        }
        if (Star[3].gameObject.activeSelf == true)
            Bulb.gameObject.SetActive(true);
        if (Bulb.gameObject.activeSelf == true)
        {
            Invoke("Change", 3.0f); 
            //Success.SetActive(true);
        }

    }

    void Change()
    {
        Success.SetActive(true);
    }
}
