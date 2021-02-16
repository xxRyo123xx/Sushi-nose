using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Master : MonoBehaviour
{
    public Text countText;
    public Text currentScoreNumText;
    public Text currentScoreText;
    public Text scoreNumText;
    public Text scoreText;
    public Text highScoreNumText;
    public Text highScoreText;
    //public Text updateScoreText;
    public Text levelNumText;
    public Text retryText;
    public ParticleSystem particle;
    private bool isLock = false;
    private float countDown = 4f;
    private float time = 0.0f;
    private int score = 0;
    private int count;
    private const int LEVEL_UP_NUM = 100;
    private const float SPEED = 1.5f;
    private int levelUpCount = 0;
    private float xGoodDifference = 0.1f;
    private float xExcellentDifference = 0.02f;
    private GameObject canvas;
    private SoundController sound;
    SystemLanguage sl;

    void Awake()
    {
        canvas = GameObject.Find("Canvas");
        sound = new SoundController();
        sl = Application.systemLanguage;
        switch (sl)
        {

            case SystemLanguage.Japanese:
                currentScoreText.text = "点";
                break;
            case SystemLanguage.English:
            default:
                currentScoreText.text = "P";
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (countDown >= 0)
        {
            countDown -= Time.deltaTime;
            count = (int)countDown;
            if (count == 0)
            {
                countText.fontSize = 200;
                countText.text = "START!";
            }
            else
            {
                countText.text = count.ToString();
            }
        }
        else
        {
            if (!isLock)
            {
                countText.gameObject.SetActive(false);
                isLock = true;
                Util.isStart = true;
                Util.isReady = true;
            }

            if (Util.isSucceed)
            {
                time += Time.deltaTime;
                if (time > 0.3f)
                {
                    GameObject neta = GameObject.FindGameObjectWithTag("Sushi");
                    score += 10;


                    float netaX = Util.targetX;

                    GameObject player = GameObject.Find("Player");
                    float playerX = player.gameObject.transform.localPosition.x;

                    if (Mathf.Abs(netaX - playerX) < xExcellentDifference)
                    {
                        score += 10;
                        var addScoreText = canvas.gameObject.transform.Find("AddScoreText");
                        addScoreText.GetComponent<Text>().text = "Excellent+10";
                        addScoreText.gameObject.SetActive(true);
                    }
                    else if (Mathf.Abs(netaX - playerX) < xGoodDifference)
                    {
                        score += 5;
                        var addScoreText = canvas.gameObject.transform.Find("AddScoreText");
                        addScoreText.GetComponent<Text>().text = "Good +5";
                        addScoreText.gameObject.SetActive(true);
                    }

                    this.currentScoreNumText.text = score.ToString();

                    //player.gameObject.transform.localPosition = new Vector3(0, 0, 0);

                    Destroy(neta);
                    if (score >= LEVEL_UP_NUM * (levelUpCount + 1))
                    {
                        Util.currentSpeed += SPEED;
                        levelUpCount++;
                        this.levelNumText.text = levelUpCount.ToString();
                    }
                    Util.isReady = true;
                    time = 0.0f;
                }
            }
        }
    }

    public void EndProcess(GameObject sushiObj, GameObject parentObj)
    {
        GameObject mainCamera = GameObject.Find("Main Camera");
        //GameObject child = sushiObj.transform.Find("Cube").gameObject;
        float x = parentObj.transform.localPosition.x;
        mainCamera.transform.localPosition = new Vector3(x, 3.5f, -6.0f);

        var gameOverTxt = canvas.gameObject.transform.Find("GameOverText");
        gameOverTxt.gameObject.SetActive(true);

        var retryBtn = canvas.gameObject.transform.Find("RetryButton");
        retryBtn.gameObject.SetActive(true);

        //var currentScoreText = canvas.gameObject.transform.Find("CurrentScoreText");
        currentScoreText.gameObject.SetActive(false);
        this.currentScoreNumText.gameObject.SetActive(false);

        var levelText = canvas.gameObject.transform.Find("LevelText");
        levelText.gameObject.SetActive(false);
        this.levelNumText.gameObject.SetActive(false);

        //var scoreText = canvas.gameObject.transform.Find("ScoreText");
        scoreText.gameObject.SetActive(true);
        this.scoreNumText.gameObject.SetActive(true);

        //var highScoreText = canvas.gameObject.transform.Find("HighScoreText");
        highScoreText.gameObject.SetActive(true);
        this.highScoreNumText.gameObject.SetActive(true);

        ScoreController scoreCtl = new ScoreController();
        int maxScore = scoreCtl.GetRanking();

        if (score > maxScore)
        {
            maxScore = score;
            scoreCtl.SetRanking(score);
            this.particle.transform.localPosition = new Vector3(x, 8.5f, 0.0f);
            this.particle.gameObject.SetActive(true);
            //var updateScoreText = canvas.gameObject.transform.Find("UpdateScoreText");
            //updateScoreText.gameObject.SetActive(true);
            if (Util.isBgmOn)
            {
                sound.Sound(0);
            }
        }
        switch (sl)
        {
            case SystemLanguage.Japanese:
                highScoreText.text = "自己ベスト";
                scoreText.text = "今回のスコア";
                //updateScoreText.text = "更新!";
                retryText.text = "再チャレンジ";
                this.scoreNumText.text = score.ToString() + "点";
                this.highScoreNumText.text = maxScore.ToString() + "点";
                break;
            case SystemLanguage.English:
            default:
                highScoreText.text = "Best Score";
                scoreText.text = "Score";
                //updateScoreText.text = "Update!";
                retryText.text = "Retry";
                this.scoreNumText.text = score.ToString() + "P";
                this.highScoreNumText.text = maxScore.ToString() + "P";
                break;
        }
    }

}
