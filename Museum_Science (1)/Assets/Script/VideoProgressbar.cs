using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoProgressbar : MonoBehaviour
{
    [SerializeField]
    public VideoPlayer mVideoPlayer = null;
    private Image progress;

    // Start is called before the first frame update
    void Start()
    {
        progress = GameObject.Find("Progress").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mVideoPlayer.frameCount > 0)
            progress.fillAmount = (float)mVideoPlayer.frame / (float)mVideoPlayer.frameCount;
    }

    private void TrySkipToPercent(float pct)
    {
        var frame = mVideoPlayer.frameCount * pct;
        mVideoPlayer.frame = (long)frame;
    }

    private void TrySkip(PointerEventData eventData)
    {
        Vector2 localPoint;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(progress.rectTransform, eventData.position, null, out localPoint))
        {
            float pct = Mathf.InverseLerp(progress.rectTransform.rect.xMin, progress.rectTransform.rect.xMax, localPoint.x);
            TrySkipToPercent(pct);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        TrySkip(eventData);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        TrySkip(eventData);
    }
}
