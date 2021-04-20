using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene : MonoBehaviour
{
    private AudioSource audioOK;
    private float _duration = 0;
    int n = 0;
    private AudioClip audioclip;

    // Start is called before the first frame update
    void Start()
    {
        audioOK = GameObject.Find("메인버튼").GetComponent<AudioSource>();
        audioclip = (AudioClip)Resources.Load("MainButton");
        _duration = audioclip.length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene(int n)
    {
        StartCoroutine(LoadLevelAfterDelay(_duration, n));
        ScoreManager.Instance.QuizScore = 0;

    }
    public void Initialize()
    {

    }
    IEnumerator LoadLevelAfterDelay(float delay, int n)
    {
        audioOK.Play();
        yield return new WaitForSeconds(delay);

        SceneManager.LoadScene(n);
        this.gameObject.SetActive(false);
    }
}
