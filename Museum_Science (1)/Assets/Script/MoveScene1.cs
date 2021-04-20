using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene1 : MonoBehaviour
{
    private AudioSource audioOK;
    private float _duration = 0;
    int n = 0;
    private AudioClip audioclip;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //SceneManager.LoadSceneAsync(1);
            StartCoroutine(LoadLevelAfterDelay(_duration));
        }

    }

    void Start()
    {
        audioOK = GameObject.Find("메인버튼").GetComponent<AudioSource>();
        audioclip = (AudioClip)Resources.Load("MainButton");
        _duration = audioclip.length;
    }

    public void ExitScene()
    {
        Application.Quit();
    }
    IEnumerator LoadLevelAfterDelay(float delay)
    {
        audioOK.Play();
        yield return new WaitForSeconds(delay);

        SceneManager.LoadScene(1);
    }
}
