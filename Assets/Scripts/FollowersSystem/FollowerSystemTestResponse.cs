using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FollowerSystemTestResponse : MonoBehaviour
{
    [SerializeField]
    GameObject loli;
    // Start is called before the first frame update
    void Awake()
    {
        
        CatFollowerRandomAnswer.onInsult += gotRoasted;
        CatFollowerRandomAnswer.onHelpfulAdvice += Helped;
        CatFollowerRandomAnswer.onWrongAdvice += gotTrolled;
        CatFollowerRandomAnswer.onFollowerGift += takeAloli;
        CatFollowerRandomAnswer.onFollowerGift += theloli;

    }

    // Update is called once per frame
    void gotRoasted()
    {
        Debug.Log("Roasted");
    }

    void Helped()
    {
        Debug.Log("GotHelped");
    }

    void gotTrolled()
    {
        Debug.Log("U Mad Bro?");
    }

    void takeAloli()
    {
        Debug.Log("here's a loli");
    }

    void theloli()
    {
        Instantiate(loli);
    }
}
