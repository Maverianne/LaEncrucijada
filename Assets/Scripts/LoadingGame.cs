using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LoadingGame : MonoBehaviour
{
    [SerializeField]
    private Slider slider;

    public static LoadingGame instance;
    private AsyncOperation operation;
    private Canvas canvas;

    private void Awake()
    {
        instance = this;
        canvas = GetComponentInChildren<Canvas>(true);
        canvas.gameObject.SetActive(false);
        DontDestroyOnLoad(gameObject);
    }

    public void LoadScene(int sceneName)
    {
        UpdateProgressUI(0);
        canvas.gameObject.SetActive(true);

        StartCoroutine(BeginLoad(sceneName));

    }

    private IEnumerator BeginLoad(int sceneName)
    {
        operation = SceneManager.LoadSceneAsync(sceneName);

        while (!operation.isDone)
        {
            UpdateProgressUI(operation.progress);
            yield return null;
        }

        UpdateProgressUI(operation.progress);
        operation = null;
        canvas.gameObject.SetActive(false);
        if (sceneName == 0)
        {
            Destroy(gameObject);
        }
    }

    private void UpdateProgressUI(float progress)
    {
        slider.value = progress;
    }
}
