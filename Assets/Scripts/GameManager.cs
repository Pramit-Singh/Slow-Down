using DG.Tweening;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject StartPath;
    public ObjectPooling ObjPoolingScript;
    public ObstaclesGenerate ObsGeneraterScript;
    [Space]
    [Header("UI")]
    [Space]
    public GameObject startPanel;
    public GameObject scorePanel;
    public GameObject pauseMenu;
    public GameObject pausePanel;
    public GameObject gameOverPanel;
    public GameObject musicPanel;
    public GameObject settingPanel;
    public GameObject tutorialPanel;
    public GameObject starPanel;

    [Space]
    [Space]
    public Texture[] ballTexture;
    public GameObject [] ballBtn;
    public Material ballMaterial;
    public bool _isPaused;
    public GameObject destroyParticleSystem;
    public GameObject Ball;


    public GameObject goText;
    public GameObject readyText;

    public Material cameraMaterial;
    bool _isTabPressed;
    float materialChangeValue = 0;


    public GameObject backGroundSound;


    //Dictionary<int, bool> ballStatus = new Dictionary<int, bool>();
    
    bool _isBallStatus;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        

        startPanel.SetActive(true);
        scorePanel.SetActive(false);
        settingPanel.SetActive(true);
        StartPath.GetComponent<PathMove>().enabled = false;
        ObjPoolingScript.enabled = false;
        ObsGeneraterScript.enabled = false;

        if (PlayerPrefs.HasKey("Reset") && PlayerPrefs.GetInt("Reset") ==1)
        { 
            ClickOnPlay();
            PlayerPrefs.SetInt("Reset", 0);

        }
       
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButton(0))
        {
            _isTabPressed = true;  //touch
            if (materialChangeValue < .9 && !startPanel.activeSelf
            && gameOverPanel.GetComponent<RectTransform>().anchoredPosition == new Vector2(0, 3000)
            && pauseMenu.GetComponent<RectTransform>().anchoredPosition == new Vector2(0, 3000)
            && musicPanel.GetComponent<RectTransform>().anchoredPosition == new Vector2(0, 3000))
                materialChangeValue += Time.deltaTime * 2;
        }
        else
        {
            _isTabPressed = false;
            if (materialChangeValue > .1)
                materialChangeValue -= Time.deltaTime;
        }

        if (_isTabPressed )
        {
          //  print(startPanel.activeSelf);
            cameraMaterial.SetFloat("_VSoft", materialChangeValue);
        }
        else
        {
            cameraMaterial.SetFloat("_VSoft", materialChangeValue);
        }


#elif UNITY_ANDROID
       
        if (Input.touchCount > 0)
        {
            _isTabPressed = true;  //touch
            if (materialChangeValue < .9 && !startPanel.activeSelf
            && gameOverPanel.GetComponent<RectTransform>().anchoredPosition == new Vector2(0, 3000)
            && pauseMenu.GetComponent<RectTransform>().anchoredPosition == new Vector2(0, 3000)
            && musicPanel.GetComponent<RectTransform>().anchoredPosition == new Vector2(0, 3000))
                materialChangeValue += Time.deltaTime * 2;
        }
        else
        {
            _isTabPressed = false;
            if (materialChangeValue > .1)
                materialChangeValue -= Time.deltaTime;
        }

        if (_isTabPressed )
        {
          //  print(startPanel.activeSelf);
            cameraMaterial.SetFloat("_VSoft", materialChangeValue);
        }
        else
        {
            cameraMaterial.SetFloat("_VSoft", materialChangeValue);
        }

#endif


    }


    public void ClickOnSettings()
    {
        musicPanel.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, 0), .4f);

    }

    public void ClickOnTutorial()
    {
        musicPanel.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, 3000), .4f);
        tutorialPanel.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, 0), .4f);
    }
    public void ClickOnPlay()
    {
        settingPanel.SetActive(false);
        startPanel.SetActive(false);
        readyText.SetActive(true);
        scorePanel.SetActive(true);
        StartPath.GetComponent<PathMove>().enabled = true;
        ObjPoolingScript.enabled = true;
        ObsGeneraterScript.enabled = true;
        StartCoroutine("activeText");
    }
    IEnumerator activeText()
    {
        yield return new WaitForSeconds(1.8f);
        readyText.SetActive(false);
        goText.SetActive(true);
        yield return new WaitForSeconds(1.8f);
        goText.SetActive(false);
    }
    public void ClickOnReset()
    {
        Time.timeScale = 1.0f;
        ScoreManager.instance.ResetScore();
        SceneManager.LoadScene(0);
        PlayerPrefs.SetInt("Reset",1);

    }

    public void ClickOnPauseBtn()
    {
        _isPaused = true;
        //   pausePanel.SetActive(true);
        //pauseMenu.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        pauseMenu.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, 0), .4f);
        // Time.timeScale = 0.0f;
        StartCoroutine("TimeScaleChange");
    }

    IEnumerator TimeScaleChange()
    {
        yield return new WaitForSeconds(.4f);
        Time.timeScale = 0.0f;
    }

    public void ClickOnHome()
    {
        if (gameOverPanel.GetComponent<RectTransform>().anchoredPosition == new Vector2(0, 0)
            || pauseMenu.GetComponent<RectTransform>().anchoredPosition == new Vector2(0, 0))
        {
            Time.timeScale = 1.0f;
            ScoreManager.instance.ResetScore();
            SceneManager.LoadScene(0);
        }
        else
        {
            ResetPosAll();
        }
    }

    public void ClickOnResumeBtn()
    {
        _isPaused = false;
        Time.timeScale = 1;
        pauseMenu.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, 3000), .2f);
        // pausePanel.SetActive(false);
        //  pauseMenu.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 1500);

    }

    public void GameOver()
    {
        gameOverPanel.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, 0), .5f);
    }

    public void ResetPosAll()
    {
        musicPanel.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, 3000), 0f);
        //settingPanel.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, 3000), 0f);
        tutorialPanel.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, 3000), 0f);
        starPanel.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, 3000), 0f);
    }

    public void OnClickCart()
    {
        starPanel.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, 0), .4f);
    }

    public void OnBallTextureClick(int number)
    {
        string ballName= ballBtn[number].name;
        if (!PlayerPrefs.HasKey(ballName) && ScoreManager.starCount >= 100)
        {
            ballMaterial.SetTexture("_MainTex", ballTexture[number]);
            ballBtn[number].GetComponent<Image>().sprite = null;
            ScoreManager.starCount = ScoreManager.starCount - 100;
            ScoreManager.instance.StarUpdate();

            ballBtn[number].transform.GetChild(0).transform.gameObject.SetActive(true);
        }
        else if (PlayerPrefs.HasKey(ballName) && PlayerPrefs.GetInt(ballName) == 1)
        {
            ballMaterial.SetTexture("_MainTex", ballTexture[number]);
            
            

        }


    }

    public void Quit()
    {
        Application.Quit();
    }

    public void BGSound(string str)
    {
        if (str == "ON")
        {
            backGroundSound.SetActive(true);
        }
        else if (str == "OFF")
        {
            backGroundSound.SetActive(false);
        }
    }

    public void FB()
    {
        Application.OpenURL("https://www.facebook.com/zuobox/");
    }

    public void PlayStore()
    {
        Application.OpenURL("http://play.google.com/store/apps/details?id=com.br.latestslowdown");
    }

}
