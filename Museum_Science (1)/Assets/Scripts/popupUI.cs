using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popupUI : MonoBehaviour
{

    GameObject original;
    piceseScript[] seperatePuzzle;
    // Start is called before the first frame update
    void Start()
    {    
        //처음에 나오는 원본 이미지
        original = GameObject.Find(this.name + "_Background");

        //퍼즐 각각이 나오는 시간을 늦춘다.
        seperatePuzzle = GetComponentsInChildren<piceseScript>();

        for (int i = 0; i < seperatePuzzle.Length ; i++)
            seperatePuzzle[i].gameObject.SetActive(false);
        StartCoroutine(popup());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator popup()
    {
        yield return new WaitForSeconds(2.0f);
        original.SetActive(false);
        for (int i = 0; i < seperatePuzzle.Length ; i++)
            seperatePuzzle[i].gameObject.SetActive(true);
    }
}
