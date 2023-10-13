using System.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "QA/Card")]
public class QACard : ScriptableObject
{
    public string[] answers = new string[4];
    public int answer;
    public string stringAnswer;
    [TextArea]public string question;
}