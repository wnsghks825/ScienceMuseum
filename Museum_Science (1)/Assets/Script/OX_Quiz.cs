using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OX_Quiz : MonoBehaviour
{

    [SerializeField]
    private GameObject[] OXQuiz;
    [SerializeField]
    private Image[] OX;
    private int glacierNum = 0;
    private AudioSource audioOK;
    private AudioSource audioWrong;
    private AudioClip OK;
    private AudioClip Wrong;

    public GameObject Fail;
    public GameObject Bear;
    public Transform[] Glacier;
    public GameObject BackgroundIce;

    // Start is called before the first frame update
    void Start()
    {
        glacierNum = 0;
        audioOK = GameObject.Find("퀴즈 맞춤").GetComponent<AudioSource>();
        audioWrong = GameObject.Find("퀴즈 틀림").GetComponent<AudioSource>();
        OK = (AudioClip)Resources.Load("퀴즈 맞춤");
        Wrong = (AudioClip)Resources.Load("퀴즈 틀림");
    }

    //버튼을 체크한다. 
    public void CheckButton(int n)
    {
        if (n == 0)
        {
            audioOK.clip = OK;
            audioOK.Play();

            OX[0].gameObject.SetActive(true);
            StartCoroutine(checkTime(n));
        }
        //틀렸다면
        else if(n==1)
        {
            //처음 틀린 경우
            OX[1].gameObject.SetActive(true);
            audioWrong.clip = Wrong;
            audioWrong.Play();

            print(ScoreManager.Instance.QuizScore);
            Glacier[ScoreManager.Instance.QuizScore].gameObject.SetActive(false);
            Bear.transform.position = Glacier[ScoreManager.Instance.QuizScore].position;

            ScoreManager.Instance.QuizScore++;

        }

        else if (n == 2)
        {
            if (ScoreManager.Instance.QuizScore == 10)
            {
                Fail.SetActive(true);
            }
            if (Fail.activeSelf == true)
            {
                //for(int i= 0; i < BackgroundIce.GetComponentsInChildren<Image>().Length; i++)
                //{
                //    //Glacier중 activeinhierachy이고 가장 상위에.
                //    if (BackgroundIce.GetComponentsInChildren<Image>()[i].gameObject.activeInHierarchy == true)
                //        print(BackgroundIce.GetComponentsInChildren<Image>()[i].gameObject.activeInHierarchy);
                //        Bear.transform.position = Glacier[i+1].position;
                //}

            }
 
            OX[1].gameObject.SetActive(false);
            OXQuiz[1].SetActive(true);


        }

    }

    IEnumerator checkTime(int vs)
    {
        yield return new WaitForSeconds(1f);
        if (OX[0].gameObject.activeSelf)
        {
            OX[0].gameObject.SetActive(false);
            OXQuiz[1].SetActive(true);
        }

    }
}
