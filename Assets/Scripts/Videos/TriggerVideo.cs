using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
public class TriggerVideo : MonoBehaviour
{
    public static TriggerVideo instance;
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
        LoadingGame.instance.LoadScene(SceneNumber);
        videoPlayer.Pause();

    }
}
