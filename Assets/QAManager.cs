using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QAManager : MonoBehaviour
{
    int vida = 3;
    int Time_M = 3;
    int Time_s = 0;
    float time = 0;
    public Text vida_text;
    public Text point_text;
    public Text Time_text;
    public QACard[] cards;
    public QAButton[] buttons = new QAButton[4];

    public bool ganaste = false;
    //public Image[] images = new Image[4];

    public Text question;

    //public GameObject winpanel;

    //public Color fullColor;
    //public Color noColor;
    //public Color textColor;
    //public Color correctTextColor = Color.white;
    //public Color wrongButtonColor;
    public QAEndPanel panel;

    public GameObject[] IndicadorDeFallas = new GameObject[4];
    //public SpriteRenderer sr;
    //public Sprite normalButtonSprite;
    //public Sprite correctButtonSprite;
    //public Sprite wrongSprite;
    //public Sprite correctSprite;
    [SerializeField] private int currentQuestion = 0;
    [SerializeField] private int point = 1;
    [SerializeField] private int totalScore = 0;

    //AudioSource audioSource;
    //public AudioClip trueAnswerClip;
    //public AudioClip wrongAnswerClip;
    //public AudioClip winClip;


    private void Awake()
    {
        //sr = GetComponent<SpriteRenderer>();
        //panel = FindObjectOfType<QAEndPanel>();
        panel.gameObject.SetActive(false);
        //for (int i = 0; i < images.Length; i++)
        //{
        //images[i].color = noColor;
        //}
        //winpanel.SetActive(false);
        //audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        NextAnswer();
    }

    private void Update()
    {
        if ((Time_M > 0 || Time_s > 0) && ganaste == false) 
        {
            time += Time.deltaTime;
            if (time >= 1)
            {
                time = 0;
                Time_s--;
                if (Time_s<0)
                {
                    Time_M--;
                    Time_s = 59;
                }

                if (Time_s >= 10)
                {
                    Time_text.text = Time_M + ":" + Time_s;
                }
                else
                {
                    Time_text.text = Time_M + ":0" + Time_s;
                }
            }
        }
        else
        {
            final();
        }
        
    }

    public void EvaluateAnswer(int index)
    {
        print("hola");
        point = (point < 0) ? 0 : point;
        if (index == cards[currentQuestion].answer)
        {
            print("Good");
            //audioSource.PlayOneShot(trueAnswerClip);
            for (int i = 0; i < 4; i++)
            {
                IndicadorDeFallas[i].GetComponent<RawImageX>().reinicio();
            }
            StartCoroutine(CompleteAnswer(index));
        }
        else
        {
            print("Wrong");
            //audioSource.PlayOneShot(wrongAnswerClip);
            IndicadorDeFallas[index].GetComponent<RawImageX>().fallaste();
            StartCoroutine(WrongAnswer(index));
        }


    }

    private void NextAnswer()
    {
        if (currentQuestion < cards.Length)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Initialize(cards[currentQuestion].answers[i]);
            }
            //sr.sprite = cards[currentQuestion].background;
            question.text = cards[currentQuestion].question;

            StopAllCoroutines();
            for (int i = 0; i < buttons.Length; i++)
            {
                //images[i].color = noColor;
                buttons[i].button.interactable = true;
                //buttons[i].buttonImage.color = fullColor;
            }
            point = 1;
        }
        else
        {
            
            final();
            //audioSource.PlayOneShot(winClip);
        }

    }

    IEnumerator CompleteAnswer(int index)
    {
        //images[index].color = fullColor;
        //images[index].sprite = correctSprite;
        buttons[index].button.interactable = false;
        //buttons[index].buttonImage.sprite = correctButtonSprite;
        //buttons[index].text.color = correctTextColor;
        totalScore += 1;
        point = 0;
        point_text.text = "Point: " + totalScore;
        yield return new WaitForSeconds(1f);
        //images[index].color = noColor;
        buttons[index].button.interactable = true;

        //buttons[index].buttonImage.sprite = normalButtonSprite;
        //buttons[index].text.color = textColor;
        if (currentQuestion < cards.Length)
        {
            currentQuestion++;
            NextAnswer();
        }
        else
        {
            print("end");
        }
    }
    IEnumerator WrongAnswer(int index)
    {
        //images[index].color = fullColor;
        //images[index].sprite = wrongSprite;
        buttons[index].button.interactable = false;
        //buttons[index].buttonImage.color = wrongButtonColor;
        point = 0;
        vida--;
        print(vida);
        vida_text.text = "Lives: " + vida;
        if (vida <= 0)
        {
            print("Perdiste" );
            final();
            
        }
        yield return new WaitForSeconds(1f);
        //images[index].color = noColor;
        buttons[index].button.interactable = true;
        //buttons[index].buttonImage.color = fullColor;
    }


    void final()
    {
        ganaste = true;
        panel.gameObject.SetActive(true);
        float p = 0;
        float parte1 = 0;
        float parte2 = 0;
        float parte3 = 0;
        if (Time_M != 0)
        {
            parte1 = Time_M * 60 + Time_s;
            print("parte1: " + parte1);
            parte2 = parte1 * vida / 100;
            print("parte2: " + parte2);
            parte3 = parte2 * totalScore;
            print("parte3: " + parte3);
            p = parte3;

            //p = ((Time_M * 60 + Time_s) * vida / 100) * totalScore;
            print("min:" + Time_M);
            print("sec:" + Time_s);
            print("sec:" + vida);
            print("puntaje:" + totalScore);
            print("p:" + p);
            print("");
            print("");

        }
        else if (Time_s != 0)
        {
            parte2 = Time_s * vida / 100;
            print("parte2: " + parte2);
            parte3 = parte2 * totalScore;
            print("parte3: " + parte3);
            p = parte3;

            //p = Time_s * vida / 100 * totalScore;
            print("sec:" + Time_s);
            print("sec:" + vida);
            print("puntaje:" + totalScore);
            print("p:" + p);
            print("");
            print("");
            print("");
        }
        else
        {
            p = totalScore;
            print("perdiste:" + p);
        }

        p = Mathf.Round(p);

        panel.Initialize(p);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}