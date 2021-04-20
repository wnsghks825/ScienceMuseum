using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public AudioSource ButtonSound;
    public Transform Exit;
    private Ray ray;
    private RaycastHit hit;
    [SerializeField] GameObject HomeButton;

    private void Awake()
    {
        //Screen.SetResolution(1920, 1080, false);
        if (instance == null)
        {
            instance = this;

        }
        else
        {
            Destroy(this.gameObject);
            return;
        }
        DontDestroyOnLoad(transform.gameObject);
    }
    /*
    private void Start()
    {
        
        
        
        HomeButton.GetComponent<Button>().onClick.AddListener(() => {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                print("Escape");
            }
        });
        //print(HomeButton.GetComponent<Button>().onClick.GetPersistentEventCount());
    }*/
    // Update is called once per frame
    void Update()
    {
        //안드로이드 백키 종료      
        // if (Application.platform == RuntimePlatform.Android)]
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.transform.tag == "Button")
                {
                    //print("Sound");
                    ButtonSound.Play();
                }
            }
        }
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    ButtonSound.Play();
        //    ActExit();
        //}
    }
    public void ActExit()
    {
        Time.timeScale = 0f;
        Exit.gameObject.SetActive(true);
    }
    public void ExitYes()
    {
        //UnityEditor.EditorApplication.isPlaying = false;

        Application.Quit(); // 어플리케이션 종료
    }
    public void ExitNo()
    {
        //BGM.Play(); Sea.Stop();
        Time.timeScale = 1f; // 먼저 시간을 다시 가도록 원복 
        Exit.gameObject.SetActive(false); // Exit 팝업창을 지운다.
    }

    void OnEnable()
    {
        // 씬 매니저의 sceneLoaded에 체인을 건다.
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // 체인을 걸어서 이 함수는 매 씬마다 호출된다.
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Exit = GameObject.Find("UI").transform.Find("Exit");
        string SceneName = SceneManager.GetActiveScene().name;
        if (SceneName == "Play")
        {
            HomeButton = GameObject.Find("HomeButton").transform.Find("홈버튼").gameObject;
            HomeButton.GetComponent<Button>().onClick.AddListener(ActExit);
        }
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
