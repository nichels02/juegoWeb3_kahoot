using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QAEndPanel : MonoBehaviour
{
    public Image panelImage;
    //public Sprite[] sprites;
    public Text pointsText;
    //public Animator starAnimator;
    //public GameObject button;
    //public AudioClip oneStar;
    //public AudioClip twoStars;
    //public AudioClip threeStars;
    //AudioSource audioSource;



    public void Initialize(float points)
    {

        //panelImage.sprite = sprites[totalPoints];
        //panelImage.color = fullcolor;
        pointsText.text = "Points:" + points;
        //starAnimator.gameObject.SetActive(true);
        //button.gameObject.SetActive(true);
        //starAnimator.Play("QA_Win" + totalPoints);

        //if (totalPoints == 0)
        //{
        //audioSource.PlayOneShot(oneStar);
        //}
        //else if (totalPoints == 1)
        //{
        //audioSource.PlayOneShot(twoStars);
        //}
        //else if (totalPoints == 2)
        //{
        //audioSource.PlayOneShot(threeStars);
        //}
    }
    void OnEnable()
    {
        //audioSource = GetComponent<AudioSource>();
    }
    void Awake()
    {
        //audioSource = GetComponent<AudioSource>();
        //starAnimator.gameObject.SetActive(false);
        //button.gameObject.SetActive(false);
    }

}