using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingManager : MonoBehaviour
{
    public static LoadingManager Instance;

    public GameObject LoadingPanel;
    public float MinLoadTime;

    public Image LoadingSquare;

    public Image FadeImage;
    public float FadeTime;

    private string targetScene;
    private bool isLoading;
    private bool isEntrance;

    private void Awake()
    {
        LoadingPanel.SetActive(false);
        FadeImage.gameObject.SetActive(false);
    }

    public void LoadScene(string parameters)
    {
        var parameterArray = parameters.Split(',');

        targetScene = parameterArray[0];
        isEntrance = bool.Parse(parameterArray[1]);

        StartCoroutine(LoadBasicFadeRoutine());
    }

    public void LoadSceneWithTransition(string parameters)
    {
        var parameterArray = parameters.Split(',');

        targetScene = parameterArray[0];
        isEntrance = bool.Parse(parameterArray[1]);

        StartCoroutine(LoadAdvancedFadeRoutine());
    }

    IEnumerator playSound(AudioSource audioSource)
    {
        audioSource.Play();
        yield return null;
    }

    private IEnumerator LoadBasicFadeRoutine()
    {
        if (isEntrance)
        {
            FindObjectOfType<AudioManager>().Play("Menu Selection");
        }
        else
        {
            FindObjectOfType<AudioManager>().Play("Menu Exit");
        }

        isLoading = true;

        FadeImage.gameObject.SetActive(true);
        FadeImage.canvasRenderer.SetAlpha(0);

        while (!Fade(1))
            yield return null;

        LoadingPanel.SetActive(true);

        while (!Fade(0))
            yield return null;

        SceneManager.LoadSceneAsync(targetScene);
        
        while (!Fade(1))
            yield return null;

        LoadingPanel.SetActive(false);

        while (!Fade(0))
            yield return null;

        isLoading = false;
    }

    private IEnumerator LoadAdvancedFadeRoutine()
    {
        if (isEntrance)
        {
            FindObjectOfType<AudioManager>().Play("Menu Selection");
        }
        else
        {
            FindObjectOfType<AudioManager>().Play("Menu Exit");
        }

        isLoading = true;

        FadeImage.gameObject.SetActive(true);
        FadeImage.canvasRenderer.SetAlpha(0);

        while (!Fade(1))
            yield return null;

        LoadingPanel.SetActive(true);
        StartCoroutine(BlinkSquareRoutine());

        while (!Fade(0))
            yield return null;

        AsyncOperation op = SceneManager.LoadSceneAsync(targetScene);
        float elapsedLoadTime = 0f;

        while(!op.isDone)
        {
            elapsedLoadTime += Time.deltaTime;
            yield return null;
        }

        while(elapsedLoadTime < MinLoadTime)
        {
            elapsedLoadTime += Time.deltaTime;
            yield return null;
        }

        while (!Fade(1))
            yield return null;

        LoadingPanel.SetActive(false);

        while (!Fade(0))
            yield return null;

        isLoading = false;
        Destroy(gameObject);
    }

    private bool Fade(float target)
    {
        FadeImage.CrossFadeAlpha(target, FadeTime, true);
        if (Mathf.Abs(FadeImage.canvasRenderer.GetAlpha() - target) <= 0.05f)
        {
            FadeImage.canvasRenderer.SetAlpha(target);
            return true;
        }
        return false;
    }

    private IEnumerator BlinkSquareRoutine()
    {
        while (isLoading)
        {
            switch (LoadingSquare.color.a.ToString())
            {
                case "0":
                    LoadingSquare.color = new Color(LoadingSquare.color.r, LoadingSquare.color.g, LoadingSquare.color.b, 1);
                    //Play sound
                    yield return new WaitForSeconds(0.5f);
                    break;
                case "1":
                    LoadingSquare.color = new Color(LoadingSquare.color.r, LoadingSquare.color.g, LoadingSquare.color.b, 0);
                    //Play sound
                    yield return new WaitForSeconds(0.5f);
                    break;
            }
        }
    }
}
