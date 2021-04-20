using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
public class DragAndDrop_ : MonoBehaviour
{
    public GameObject[] Levels;
    float MaxDistance = 15;
    public GameObject EndMenu;
    public GameObject SelectedPiece;
    public GameObject[] nextPanel;
    int OIL = 1;
    public int PlacedPieces = 0;
    public GameObject transparentPanel;
    //private Ray2D ray;
    //RaycastHit2D hit;
    Ray ray;
    RaycastHit hit;

    private AudioSource audioOK;
    private float _duration = 0;
    int n = 0;
    private AudioClip audioclip;
    void Start()
    {
        audioOK = GameObject.Find("메인버튼").GetComponent<AudioSource>();
        audioclip = (AudioClip)Resources.Load("MainButton");
        _duration = audioclip.length;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.forward * 50, Color.red, 0.3f);
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.forward, Mathf.Infinity);


            if (hit.transform.CompareTag("Puzzle"))
            {
                print(hit);
                if (!hit.transform.GetComponent<piceseScript>().InRightPosition)
                {
                    SelectedPiece = hit.transform.gameObject;
                    SelectedPiece.GetComponent<piceseScript>().Selected = true;
                    SelectedPiece.transform.parent = GameObject.Find("Canvas").transform;
                    //SelectedPiece.GetComponent<SortingGroup>().sortingOrder = OIL;
                    //OIL++;
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (SelectedPiece != null)
            {
                SelectedPiece.GetComponent<piceseScript>().Selected = false;
                if (Levels[0].activeInHierarchy == true)
                {
                    SelectedPiece.transform.parent = GameObject.Find("측우기").transform;
                }
                else if (Levels[1].activeInHierarchy == true)
                {
                    SelectedPiece.transform.parent = GameObject.Find("앙부일구").transform;
                }
                else if (Levels[2].activeInHierarchy == true)
                {
                    SelectedPiece.transform.parent = GameObject.Find("자격루").transform;
                }
                SelectedPiece = null;
            }
        }
        if (SelectedPiece != null)
        {
            Vector3 MousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            SelectedPiece.transform.position = new Vector3(MousePoint.x, MousePoint.y, 0);
        }
        if (PlacedPieces == 9 && Levels[0].activeSelf == true)
        {
            Levels[0].SetActive(false);
            nextPanel[0].SetActive(true);
            PlacedPieces = 0;
        }
        if (PlacedPieces == 12 && Levels[1].activeSelf == true)
        {
            Levels[1].SetActive(false);
            nextPanel[1].SetActive(true);
            PlacedPieces = 0;
        }
        if (PlacedPieces == 16 && Levels[2].activeSelf == true)
        {
            Levels[2].SetActive(false);
            nextPanel[2].SetActive(true);
            PlacedPieces = 0;
        }
    }
    public void NextLevel(int n)
    {
        audioOK.Play();
        Levels[n].SetActive(true);
        nextPanel[n-1].SetActive(false);

    }
    public void MenuEnd()
    {
        EndMenu.SetActive(true);
    }
    public void BacktoMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}