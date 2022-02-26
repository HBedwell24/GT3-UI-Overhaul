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

    private string lastScene;

    private void Awake()
    {
        lastScene = SceneManager.GetActiveScene().name;

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        LoadingPanel.SetActive(false);
        FadeImage.gameObject.SetActive(false);
    }

    private void Start()
    {
        playBackgroundMusic();
    }

    private void playBackgroundMusic()
    {
        if (lastScene.Equals("Simulation Mode"))
        {
            AudioManager.instance.PlayMusic("Simulation Mode");
        }
        else if (lastScene.Equals("Single Player") || lastScene.Equals("Go Race"))
        {
            AudioManager.instance.PlayMusic("Go Race");
        }
        else if (lastScene.Equals("License Center"))
        {
            AudioManager.instance.PlayMusic("License Center");
        }
        else if (lastScene.Equals("Car Dealer"))
        {
            AudioManager.instance.PlayMusic("Car Dealer");
        }
        else if (lastScene.Equals("My Home"))
        {
            AudioManager.instance.PlayMusic("My Home");
        }
        else if (lastScene.Equals("Tune Shop") || lastScene.Equals("Machine Test"))
        {
            AudioManager.instance.PlayMusic("Tune Shop");
        }
        else if (lastScene.Equals("GT Auto"))
        {
            AudioManager.instance.PlayMusic("GT Auto");
        }
        else if (lastScene.Equals("Options") || lastScene.Equals("Save Screen") || lastScene.Equals("Load Screen") || lastScene.Equals("Library"))
        {
            AudioManager.instance.StopMusic();
        }
    }

    void GetCurrentScene()
    {
        var currentScene = SceneManager.GetActiveScene().name;

        if (currentScene != lastScene)
        {
            lastScene = currentScene;
            playBackgroundMusic();
        }
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

    private IEnumerator LoadBasicFadeRoutine()
    {
        if (isEntrance)
        {
            AudioManager.instance.PlaySoundEffect("Menu Selection");
        }
        else
        {
            AudioManager.instance.PlaySoundEffect("Menu Exit");
        }

        isLoading = true;

        FadeImage.gameObject.SetActive(true);
        FadeImage.canvasRenderer.SetAlpha(0);

        while (!Fade(1))
            yield return null;

        LoadingPanel.SetActive(true);

        while (!Fade(0))
            yield return null;

        AsyncOperation op = SceneManager.LoadSceneAsync(targetScene);
        float elapsedLoadTime = 0f;

        while (!op.isDone)
        {
            elapsedLoadTime += Time.deltaTime;
            yield return null;
        }

        GetCurrentScene();

        while (!Fade(1))
            yield return null;

        LoadingPanel.SetActive(false);

        while (!Fade(0))
            yield return null;

        isLoading = false;
        Destroy(gameObject);
        
    }

    private IEnumerator LoadAdvancedFadeRoutine()
    {
        if (isEntrance)
        {
            AudioManager.instance.PlaySoundEffect("Menu Selection");
        }
        else
        {
            AudioManager.instance.PlaySoundEffect("Menu Exit");
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

        GetCurrentScene();

        while (elapsedLoadTime < MinLoadTime)
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
