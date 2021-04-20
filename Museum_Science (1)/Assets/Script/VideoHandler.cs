using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoHandler : MonoBehaviour
{
    //public Slider mSlider;

    public RawImage mScreen = null;
    [SerializeField]
    public VideoPlayer mVideoPlayer = null;

    public Button playButton;
    public Button pauseButton;

    float second;
    float minute = 0;
    float leftsecond;
    float leftminute;

    double clip;

    void Awake()
    {

    }

    void Start()
    {
        if (mScreen != null && mVideoPlayer != null)
        {
            // 비디오 준비 코루틴 호출
            StartCoroutine(PrepareVideo());
        }

        //mSlider.maxValue = (float)mVideoPlayer.length;
    }
    private void Update()
    {
        second = (float)(mVideoPlayer.time % 60);
        minute = ((float)(mVideoPlayer.time / 60));

        //if (second > 59)
        //{
        //    second = 0;
        //    minute = (float)(mVideoPlayer.time / 60);
        //    if (minute > 59)
        //    {
        //        minute = 0;
        //    }
        //}
        //currentText.text = string.Format("{0:00}", second);

        leftsecond = (float)((mVideoPlayer.length - mVideoPlayer.time) % 60);
        leftminute = (float)((mVideoPlayer.length - mVideoPlayer.time) / 60);
        if (second > 59)
        {

            if (minute > 59)
            {
                minute = 0;
            }
        }

        //remainText.text = string.Format("{0:00} : {1:00}", leftminute, leftsecond);
        //슬라이더 값이 변하면 비디오의 위치도 같이 바뀌어야 할 것이다. 

        if (mVideoPlayer.time > 59)
        {

        }

    }
    protected IEnumerator PrepareVideo()
    {
        // 비디오 준비
        mVideoPlayer.Prepare();

        // 비디오가 준비되는 것을 기다림
        while (!mVideoPlayer.isPrepared)
        {
            yield return new WaitForSeconds(0.5f);
        }
        // VideoPlayer의 출력 texture를 RawImage의 texture로 설정한다
        mScreen.texture = mVideoPlayer.texture;
    }
    public void PlayVideo()
    {

        if (mVideoPlayer != null && mVideoPlayer.isPrepared)
        {
            // 비디오 재생
            mVideoPlayer.Play();
        }
        pauseButton.gameObject.SetActive(true);
        playButton.gameObject.SetActive(false);

        //if()
        //패널이 붙어 있다면??
    }

    public void PauseVideo()
    {
        if (mVideoPlayer != null && mVideoPlayer.isPrepared)
        {
            // 비디오 멈춤
            mVideoPlayer.Pause();
        }
        pauseButton.gameObject.SetActive(false);
        playButton.gameObject.SetActive(true);
    }

    public void StopVideo()
    {
        if (mVideoPlayer != null && mVideoPlayer.isPrepared)
        {
            // 비디오 멈춤
            mVideoPlayer.time = 0.0f; // seek to start
        }

    }
    public void Fast()
    {
        mVideoPlayer.time += 10.0f;
    }

    public void Rewind()
    {
        mVideoPlayer.time -= 10.0f;
    }
}
