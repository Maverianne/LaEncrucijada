using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class PlayVideos : MonoBehaviour
{
    public RawImage rawImage;
    public GameObject me;
    public VideoPlayer videoPlayer;
    public int SceneNumber;
    public float videolenght;
    public float wait;
    public bool videoChanged, videoQuit;
    void Start()
    {
        me.SetActive(false);
        StartCoroutine(PlayVideo());
        
    }
    private void FixedUpdate()
    {
        if (videoQuit == true)
        {
            StartCoroutine("VideoEnded");
        }
    }
    IEnumerator PlayVideo()
    {
        videoPlayer.Prepare();
        WaitForSeconds waitForSeconds = new WaitForSeconds(wait);
        while (!videoPlayer.isPrepared)
        {
            yield return waitForSeconds;
            break;
        }
        me.SetActive(true);
        rawImage.texture = videoPlayer.texture;
        videoPlayer.Play();
    }
    IEnumerator VideoEnded()
    {
        yield return new WaitForSeconds(videolenght);
        me.SetActive(false);
    }
}

