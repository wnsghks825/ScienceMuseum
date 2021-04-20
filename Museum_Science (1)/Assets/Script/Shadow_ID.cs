using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shadow_ID : MonoBehaviour
{
    public Image[] TrueFalse;
    public Image[] Health;
    public GameObject show;
    public GameObject failImage;
    public GameObject[] Quiz;

    public AudioClip OK;
    public AudioClip Wrong;

    AudioSource audioOK;
    AudioSource audioWrong;

    bool exception;
    int checkCount;
    int quizNum;

    // Start is called before the first frame update
    void Start()
    {
       for(int i = 0; i < TrueFalse.Length; i++)
        {
            TrueFalse[i].gameObject.SetActive(false);
        }
        checkCount = Health.Length-1;
        quizNum = 0;
        audioOK = GameObject.Find("퀴즈 맞춤").GetComponent<AudioSource>();
        audioWrong = GameObject.Find("퀴즈 틀림").GetComponent<AudioSource>();
    }

    public void CheckButton(int n)
    {
        if (n == 0)
        {
            show.SetActive(true);

            TrueFalse[0].gameObject.SetActive(true);
            StartCoroutine(checkTime(0));

            exception = true;
            audioOK.clip = OK;
            audioOK.Play();
            //이렇게 하니깐 바로바로 넘어간다. 
            //맞는 버튼을 누른다면 다음 문제로 넘어갈 수 있도록 해야 할 것이다. 

        }
        //if (Quiz[0].activeSelf==true && n==0)
        //{
        //    show.SetActive(true);

        //    TrueFalse[0].gameObject.SetActive(true);
        //    StartCoroutine(checkTime(0));

        //    exception = true;
        //    StartCoroutine(checkTime(0));
        //    Quiz[0].SetActive(false);
        //    Quiz[1].SetActive(true);
        //    quizNum++;
        //}
        else if(exception)
        {
            exception = false;
        }
        else
        {
            print(checkCount);
            TrueFalse[1].gameObject.SetActive(true);

            StartCoroutine(checkTime(1));
            audioWrong.clip = Wrong;
            audioWrong.Play();

            Health[checkCount--].gameObject.SetActive(false);

        }
            print(quizNum);
    }
    

    IEnumerator DelayTime()
    {
        yield return new WaitForSeconds(1f);
    }
    IEnumerator checkTime(int vs)
    {
        yield return new WaitForSeconds(.5f);
        if (TrueFalse[0].gameObject.activeSelf)
        {
            TrueFalse[0].gameObject.SetActive(false);
            show.SetActive(false);

            if (quizNum == 0&& Quiz[0].activeSelf==true)
            {
                Quiz[0].SetActive(false);
                Quiz[1].SetActive(true);
                quizNum++;
            }

        }
        else if (TrueFalse[1].gameObject.activeSelf)
        {
            TrueFalse[1].gameObject.SetActive(false);
            show.SetActive(false);

        }
        else
        { 
            yield return new WaitForSeconds(.5f);
            show.SetActive(false);

        }

    }
    private void Update()
    {
        if (checkCount == -1)
            failImage.SetActive(true);
    }


    //이미지 바꿔치기 해보자 리소스 들어오면
}
