using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
public class NimphTrigger2 : MonoBehaviour
{
    public static NimphTrigger2 instance;
    public RawImage rawImage;
    public GameObject me, game;
    public VideoPlayer videoPlayer;
    public bool playNow;
    public float videolenght;
    public float wait;
    public GameObject bundle, changer;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        me.SetActive(false);
        playNow = false;
    }
    private void FixedUpdate()
    {
        if (playNow)
        {
            StartCoroutine(PlayVideo());
            StartCoroutine("VideoEnded");
        }

    }
    IEnumerator PlayVideo()
    {
        game.SetActive(false);
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
        GameManager.instance.SavePlayer();
        videoPlayer.Pause();
        game.SetActive(true);
        bundle.SetActive(false);
        changer.SetActive(true);
    }
}