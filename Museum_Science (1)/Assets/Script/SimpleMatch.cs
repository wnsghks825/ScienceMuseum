using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SimpleMatch : MonoBehaviour
{
    public const int gridRows = 2;
    public const int gridCols = 5;
    public const float offsetX = 480f;
    public const float offsetY = -520f;
    public GameObject success;

    int Count = 0;
    [SerializeField] private cardScript originalCard;
    [SerializeField] private Sprite[] Images;
    [SerializeField] private Image[] OX;

    float timeLeft;
    GameObject mainCanvas;
    cardScript Card;
    public Image image;
    public Image flipImage;
    Canvas canvas;
    private AudioSource audioOK;
    private AudioSource audioWrong;
    public List<GameObject> cardTransform;
    private void Start()
    {
        canvas = GameObject.Find("UI").GetComponent<Canvas>();
        audioOK = GameObject.Find("퀴즈 맞춤").GetComponent<AudioSource>();
        audioWrong = GameObject.Find("퀴즈 틀림").GetComponent<AudioSource>();
        Vector3 startPos = originalCard.transform.position;
        timeLeft = 60.0f;

        int[] numbers = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4 };
        numbers = ShuffleArray(numbers);

        for(int i = 0; i < gridCols; i++)
        {
            for(int j = 0; j < gridRows; j++)
            {
                if (i == 0 && j == 0)
                {
                    Card = originalCard;
                    Card.StartFlip();
                    cardTransform.Add(Card.gameObject);
                }
                else
                {
                    Card = Instantiate(originalCard) as cardScript;
                    cardTransform.Add(Card.gameObject);
                    flipImage = Instantiate(image);
                    Card.transform.SetParent(canvas.transform);
                    flipImage.transform.SetParent(canvas.transform);
                    Card.transform.SetSiblingIndex(2);
                    flipImage.transform.SetSiblingIndex(1);
                    Card.StartFlip();
                    //또한 Canvas Rect Transform 찾아서 바꿔줄 것
                }

                int index = j * gridCols + i;
                int id = numbers[index];
                Card.ChangeSprite(id, Images[id]);

                float posX = (3 * i) + startPos.x;
                float posY = -(3.75f * j) + startPos.y;
                Card.transform.position = new Vector3(posX, posY, startPos.z);
                Card.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
                flipImage.transform.position = new Vector3(posX, posY, startPos.z);
                flipImage.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
            }
        }
    }
    private int[] ShuffleArray(int[] numbers)
    {
        int[] newArray = numbers.Clone() as int[];
        for(int i = 0; i < newArray.Length; i++)
        {
            int tmp = newArray[i];
            int r = UnityEngine.Random.Range(i, newArray.Length);
            newArray[i] = newArray[r];
            newArray[r] = tmp;
        }
        return newArray;
    }

    private cardScript _firstRevealed;
    private cardScript _secondRevealed;
    public AudioClip OK;
    public AudioClip Wrong;

    public bool canReveal
    {
        get { return _secondRevealed == null; }
    }

    public void CardRevealed(cardScript card)
    {
        if (_firstRevealed == null)
            _firstRevealed = card;
        else
        {
            _secondRevealed = card;
            StartCoroutine(CheckMatch());
        }
    }

    private IEnumerator CheckMatch()
    {
        if (_firstRevealed.id == _secondRevealed.id)
        {

            _firstRevealed.GetComponentInChildren<Transform>().Find("O").gameObject.SetActive(true);
            _secondRevealed.GetComponentInChildren<Transform>().Find("O").gameObject.SetActive(true); 
            
            audioOK.clip = OK;
            audioOK.Play();

            yield return new WaitForSeconds(.5f);

            _firstRevealed.GetComponentInChildren<Transform>().Find("O").gameObject.SetActive(false);
            _secondRevealed.GetComponentInChildren<Transform>().Find("O").gameObject.SetActive(false);

            Count++;
        }
        else
        {
            _firstRevealed.GetComponentInChildren<Transform>().Find("X").gameObject.SetActive(true);
            _secondRevealed.GetComponentInChildren<Transform>().Find("X").gameObject.SetActive(true);

            audioWrong.clip = Wrong;
            audioWrong.Play();

            yield return new WaitForSeconds(.5f);

            _firstRevealed.GetComponentInChildren<Transform>().Find("X").gameObject.SetActive(false);
            _secondRevealed.GetComponentInChildren<Transform>().Find("X").gameObject.SetActive(false);



            _firstRevealed.Unreveal();
            _secondRevealed.Unreveal();



        }
        _firstRevealed = null;
        _secondRevealed = null;
    }
    //모든 Image가 비활성화 되어 있다면? 
    private void Update()
    {
        timeLeft -= Time.deltaTime;
        if (Count >= 5)
        {
            success.SetActive(true);
            if(timeLeft<0)
                Time.timeScale = 0.0f;
        }
    }
}
