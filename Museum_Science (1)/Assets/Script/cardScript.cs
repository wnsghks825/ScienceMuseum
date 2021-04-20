using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class cardScript : MonoBehaviour,IPointerDownHandler
{
    [SerializeField] private SimpleMatch controller;
    [SerializeField] private GameObject cardBack;


    //public bool cardBackIsActive;
    //public int timer;
    //public float x, y, z;

    // Start is called before the first frame update
    void Start()
    {
        //cardBackIsActive = true;
    }

    private int _id;

    public int id
    {
        get { return _id; }
    }


    //여기서는 카드가 뒤집히거나 아니면 어떤 모양으로 보일지를 생각해 보자

    #region Flip    
    public void StartFlip()
    {
        StartCoroutine(CalculateFlip());
    }

    //void Flip()
    //{
    //    if (cardBackIsActive == true)
    //    {
    //        cardBack.SetActive(false);
    //        cardBackIsActive = false;
    //    }
    //    else
    //    {
    //        cardBack.SetActive(true);
    //        cardBackIsActive = true;
    //    }
    //}

    IEnumerator CalculateFlip()
    {
        //for (int i = 0; i < 180; i++)
        //{
        //    yield return new WaitForSeconds(0.001f);
        //    transform.Rotate(new Vector3(x, y, z));
        //    timer++;

        //    if (timer == 90 || timer == -90)
        //    {
        //        Flip();
        //    }
        //}

        //timer = 0;
        yield return new WaitForSeconds(1.0f);
        cardBack.SetActive(false);
        yield return new WaitForSeconds(2.0f);
        cardBack.SetActive(true);

    }
    #endregion

    public void ChangeSprite(int id, Sprite image)
    {
        _id = id;
        GetComponent<Image>().sprite = image;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (cardBack.activeSelf && controller.canReveal)
        {
            cardBack.SetActive(false);
            controller.CardRevealed(this);
        }
    }
    public void Unreveal()
    {
        cardBack.SetActive(true);
    }

}
