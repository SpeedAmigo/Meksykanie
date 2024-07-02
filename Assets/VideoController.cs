using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public SceneLoader sceneLoader;

    public void OnVideoEnd(VideoPlayer vp)
    {
        sceneLoader.LoadScene(2);
    }

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.loopPointReached += OnVideoEnd;
    }
}
