using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    float timeLeft;

    [SerializeField]
    private TextMeshProUGUI Timer;
    [SerializeField]
    private GameObject failText;
    
    public Image image;

    private void Start()
    {
        timeLeft = 60.0f;
        //image = GetComponent<Image>();

    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        Timer.text = "Time : " + ((int)timeLeft).ToString();

        if (timeLeft < 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        failText.SetActive(true);
        if (timeLeft < 0)
            timeLeft = 0;
    }

    IEnumerator Blink()
    {
        while (true)
        {
            switch (image.color.g.ToString())
            {
                case "0":
                    image.color = new Color(1, 1, 1, 1);
                    //Play sound
                    yield return new WaitForSeconds(0.5f);
                    break;
                case "1":
                    image.color = new Color(1, 0, 0, 1);
                    //Play sound
                    yield return new WaitForSeconds(0.5f);
                    break;
            }
 
        }
    }
}
