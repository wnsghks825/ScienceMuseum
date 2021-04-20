using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadyStart : MonoBehaviour
{
    private int Timer = 0;
    public AudioSource ready;
    public AudioSource start;

    public AudioClip readyClip;
    public AudioClip startClip;
    public GameObject[] UISprites;

    // Start is called before the first frame update
    private void Start()
    {
        Timer = 0;
        UISprites[1].gameObject.SetActive(false);
    }


    private void Update()
    {

        if (Timer == 0)
        {
            Time.timeScale = 0.0f;
            ready.clip = readyClip;
            ready.Play();
        }
        if (Timer <= 150)
        {
            Timer++;

            if (Timer >= 90)
            { 

                UISprites[0].gameObject.SetActive(false);
                UISprites[1].gameObject.SetActive(true);

            }
            if (Timer >= 120)
            {
                //UISprites[0].gameObject.SetActive(false);
                StartCoroutine(this.Loading());
                Time.timeScale = 1.0f;
            }
        }

    }

    IEnumerator Loading()
    {
        start.clip = startClip;
        start.Play();
        yield return new WaitForSeconds(.75f);

        UISprites[1].gameObject.SetActive(true);
        UISprites[1].transform.parent.gameObject.SetActive(false);
    }

    void PauseGame()
    {
        Time.timeScale = 0;
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
    }

    IEnumerator SpawnLoop()
    {
        if (UISprites[0].gameObject.activeSelf)
        {
            yield return new WaitForSeconds(1f);
            UISprites[0].gameObject.SetActive(false);
            UISprites[1].gameObject.SetActive(true);
        }

        if (UISprites[1].gameObject.activeSelf)
        {
            yield return new WaitForSeconds(1f);

            UISprites[1].transform.parent.gameObject.SetActive(false);
            ResumeGame();
        }
    }
}
