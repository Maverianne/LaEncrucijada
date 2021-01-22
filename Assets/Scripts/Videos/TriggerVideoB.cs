using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;


public class TriggerVideoB : MonoBehaviour
{
    public static TriggerVideoB instance;
    public RawImage rawImage;
    public GameObject me, game;
    public VideoPlayer videoPlayer;
    public bool playNow;
    public int SceneNumber;
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
        videoPlayer.Prepare();
        WaitForSeconds waitForSeconds = new WaitForSeconds(wait);
        while (!videoPlayer.isPrepared)
        {
            yield return waitForSeconds;
            break;
        }
        me.SetActive(true);
        game.SetActive(false);
        rawImage.texture = videoPlayer.texture;
        videoPlayer.Play();
    }
    IEnumerator VideoEnded()
    {
        yield return new WaitForSeconds(videolenght);
        me.SetActive(false);
        videoPlayer.Pause();
        GameManager.instance.SavePlayer();
        LoadingGame.instance.LoadScene(SceneNumber);
    }
}
