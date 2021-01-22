using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class EndingVideo : MonoBehaviour
{

    public static EndingVideo instance;
    public RawImage rawImage;
    public GameObject me, game, bundle, won;
    public VideoPlayer videoPlayer;
    public bool playNow;
    public float videolenght;
    public float wait;
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
        bundle.SetActive(false);
        won.SetActive(true);
    }
}
