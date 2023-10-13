using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QAManager : MonoBehaviour
{
    int vida = 3;
    public QACard[] cards;
    public QAButton[] buttons = new QAButton[4];
    //public Image[] images = new Image[4];

    public Text question;

    //public GameObject winpanel;

    //public Color fullColor;
    //public Color noColor;
    //public Color textColor;
    //public Color correctTextColor = Color.white;
    //public Color wrongButtonColor;
    public QAEndPanel panel;
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
        panel = FindObjectOfType<QAEndPanel>();
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

    public void EvaluateAnswer(int index)
    {
        print("hola");
        point = (point < 0) ? 0 : point;
        if (index == cards[currentQuestion].answer)
        {
            print("Good");
            //audioSource.PlayOneShot(trueAnswerClip);
            StartCoroutine(CompleteAnswer(index));
        }
        else
        {
            print("Wrong");
            //audioSource.PlayOneShot(wrongAnswerClip);
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
            panel.gameObject.SetActive(true);
            int p = 0;
            if (totalScore < 4)
            {
                p = 0;
            }
            else if (totalScore > 3 && totalScore < 8)
            {
                p = 1;
            }
            else if (totalScore > 7)
            {
                p = 2;
            }
            panel.Initialize(p);
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
        totalScore += point;
        point = 0;
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
        if (vida <= 0)
        {
            print("Perdiste");
        }
        yield return new WaitForSeconds(1f);
        //images[index].color = noColor;
        buttons[index].button.interactable = true;
        //buttons[index].buttonImage.color = fullColor;
    }
}