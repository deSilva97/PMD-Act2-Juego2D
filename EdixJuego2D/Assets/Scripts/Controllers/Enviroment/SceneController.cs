using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SceneController : MonoBehaviour
{
    [SerializeField] Canvas canvasContent;
    [Space]
    [SerializeField] Image loadingImage;
    [SerializeField] TextMeshProUGUI loadingText;

    private static SceneController instance;
    public static SceneController Instance => instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        Close();
    }

    private void Open()
    {
        canvasContent.gameObject.SetActive(true);
        loadingImage.fillAmount = 0;
        StartCoroutine(LoadingTextAnimation());
    }

    private void Close()
    {
        canvasContent.gameObject.SetActive(false);
        StopAllCoroutines();
    }

    public void LoadActiveScene() => LoadScene(SceneManager.GetActiveScene().buildIndex);

    public void LoadScene(int buildIndex) => LoadScene(SceneManager.GetSceneByBuildIndex(buildIndex).name);

    public void LoadScene(string str)
    {
        Open();
        StartCoroutine(LoadLevelASync(str));
    }

    IEnumerator LoadLevelASync(string levelToLoad)
    {

        //--Delete me >
        /*
        float smallTimer = 0;
        float smallTimerMax = 1.5f;
        while(smallTimer < smallTimerMax)
        {
            smallTimer += Time.deltaTime;
            loadingImage.fillAmount = smallTimer / smallTimerMax;
            yield return new WaitForEndOfFrame();
        }
        loadingImage.fillAmount = 0;
        //--Delete me <
        */
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(levelToLoad);
        while (loadOperation.progress < .8f)
        {
            float progressValue = Mathf.Clamp01(loadOperation.progress / 1f);
            loadingImage.fillAmount = progressValue;
            yield return new WaitForEndOfFrame();
        }
     
        loadingImage.fillAmount = 1;
    }

    IEnumerator LoadingTextAnimation()
    {
        string txt = "Cargando";
        float speed = .5f;
        while (true)
        {
            loadingText.text = txt + ".";
            yield return new WaitForSeconds(speed);
            loadingText.text = txt + "..";
            yield return new WaitForSeconds(speed);
            loadingText.text = txt + "...";
            yield return new WaitForSeconds(speed);
        }

    }
}
