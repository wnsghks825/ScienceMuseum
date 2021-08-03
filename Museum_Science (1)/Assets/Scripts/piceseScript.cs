using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class piceseScript : MonoBehaviour
{
    private Vector3 RightPosition;
    public bool InRightPosition;
    public bool Selected;
    float leftRange, rightRange;
    public AudioSource correctAudio;
    void Start()
    {
        RightPosition = transform.position;
        rightRange = Random.Range(8f, 9.5f);
        leftRange = Random.Range(-4f, -3.5f);
        transform.position = new Vector3(Random.Range(leftRange, rightRange), Random.Range(-3, -6));
        if (transform.position.x <= 4.5f)
        {
            transform.position = new Vector3(leftRange, Random.Range(0f, -6));
        }
        //x의 위치는 leftRange가 될 수도 있고 right도 될 수 있다. 
        else if (transform.position.x >= 0.5f)
        {
            transform.position = new Vector3(rightRange, Random.Range(0f, -6));
        }

    }
    
    void Update()
    {
        if (Vector3.Distance(transform.position, RightPosition) < 0.5f)
        {
            if (!Selected)
            {
                if (InRightPosition == false)
                {
                    transform.position = RightPosition;
                    InRightPosition = true;
                    GetComponent<SortingGroup>().sortingOrder = 0;
                    Camera.main.GetComponent<DragAndDrop_>().PlacedPieces++;
                    correctAudio.Play();
                }
            }
        }
    }
}
