using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class BeginningVideo : MonoBehaviour
{
    public RawImage rawImage;
    public GameObject me, game;
    public VideoPlayer videoPlayer;
    public int SceneNumber;
    public float videolenght;
    public float wait;
    void Start()
    {
        me.SetActive(false);
        game.SetActive(false);
        StartCoroutine(PlayVideo());
    }
    private void FixedUpdate()
    {
       StartCoroutine("VideoEnded");
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
        game.SetActive(true);
        videoPlayer.Pause();
        Destroy(gameObject);
    }
}
