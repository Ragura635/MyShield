using NUnit.Framework.Internal;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    //public GameObject square;
    public GameObject endPanel;
    public Text timeTxt;
    public Text nowScore;
    public Text bestScore;
    public Animator anim;

    bool isPlay = true;
    float time = 0.0f;
    string key = "bestScore";

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isPlay = true;
        Time.timeScale = 1.0f;
        InvokeRepeating(nameof(MakeSquare), 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlay)
        {
            time += Time.deltaTime;
            timeTxt.text = time.ToString("N2");
        }
    }

    void MakeSquare()
    {
        /*
        ���� ���� ���
        Instantiate(square);
        */
        if (ObjectPoolManager.instance != null)
        {
            GameObject square = ObjectPoolManager.instance.GetObject();

            // Square ������Ʈ ��ġ, ũ��, ȸ���� �ʱ�ȭ
            float x = Random.Range(-3.0f, 3.0f);
            float y = Random.Range(3.0f, 5.0f);
            float size = Random.Range(0.5f, 1.5f);

            square.transform.position = new Vector2(x, y);
            square.transform.localScale = new Vector2(size, size);
            square.transform.rotation = Quaternion.identity;
        }
    }

    void TimeStop()
    {
        Time.timeScale = 0.0f;
    }

    public void GameOver()
    {
        isPlay = false;
        anim.SetBool("isDie", true);
        Invoke("TimeStop", 0.5f);
        nowScore.text = time.ToString("N2");

        //�ְ������� �ִٸ�
        if (PlayerPrefs.HasKey(key))
        {
            float best = PlayerPrefs.GetFloat(key);
            //( �ְ����� < �������� ) ���������� �ְ������� ����
            if (time > best)
            {
                PlayerPrefs.SetFloat(key, time);
                bestScore.text = time.ToString("N2");
            }
            //( �ְ����� >= �������� ) 
            else
            {
                bestScore.text = best.ToString("N2");
            }
        }
        //�ְ������� ���ٸ�
        else
        {
            //���� ������ ����
            PlayerPrefs.SetFloat(key, time);
            bestScore.text = time.ToString("N2");
        }

        endPanel.SetActive(true);
    }
}
