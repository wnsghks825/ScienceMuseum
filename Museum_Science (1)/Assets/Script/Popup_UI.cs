using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Popup_UI : MonoBehaviour
{
    public GameObject popup;
    float timeP;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timeP += Time.deltaTime;
        if(timeP>3.0f)
            popup.SetActive(false);

        if (Input.GetMouseButtonDown(0))
        {
            popup.SetActive(true);
            timeP = 0;
        }
        //눌렀을 때 

        Scene scene = SceneManager.GetActiveScene();

        if(BGSound.Instance.source.isPlaying==true)
        {
            BGSound.Instance.source.Stop();
            print(BGSound.Instance.source.name);
        }

    }

}
