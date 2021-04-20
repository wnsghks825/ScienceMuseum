using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Science_Text : MonoBehaviour
{
    public GameObject rule;
    public GameObject description;
    public GameObject panel;
    public GameObject panel2;

    private AudioSource audioOK;
    private AudioClip OK;

    // Start is called before the first frame update
    void Start()
    {
        audioOK = GameObject.Find("메인버튼").GetComponent<AudioSource>();
        OK = (AudioClip)Resources.Load("MainButton");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextMove(int num)
    {
        switch (num)
        {
            case 0:
                audioOK.clip = OK;
                audioOK.Play();
                rule.SetActive(false);
                description.SetActive(true);
                break;
            case 1:
                description.SetActive(false);
                audioOK.clip = OK;
                audioOK.Play();
                GameObject.Find("Name").SetActive(false);
                panel.gameObject.SetActive(true);
                panel2.gameObject.SetActive(false);
                break;
        }
    }
}
