using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class AudioHandler : MonoBehaviour
{
    public VideoPlayer mAudio;
    public Slider audioVolume;
    // Start is called before the first frame update

    public void volume()
    {
        mAudio.audioOutputMode = VideoAudioOutputMode.Direct;
        mAudio.SetDirectAudioVolume(0, audioVolume.value);
    }
}
