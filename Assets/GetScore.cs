
using System;
using UnityEngine;
using TMPro;

public class GetScore : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI score;


    
    void OnEnable()
    {
        score.text = $"Congratulations you've earned {GameManager.instance.followers} followers on this stream session";
    }
}
