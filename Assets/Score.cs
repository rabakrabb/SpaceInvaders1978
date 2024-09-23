using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    int score = 0;

    public void AddScore(int scoreAddition)
    {

    }
}
