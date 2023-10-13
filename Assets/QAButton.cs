using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QAButton : MonoBehaviour
{
    public Text text;
    public Button button;
    public Image buttonImage;


    private void Awake()
    {
        text = GetComponentInChildren<Text>();
        button = GetComponent<Button>();
        buttonImage = GetComponent<Image>();
    }
    public void Initialize(string buttonText)
    {
        text.text = buttonText;
    }

}