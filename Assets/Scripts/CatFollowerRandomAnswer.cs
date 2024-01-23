using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class CatFollowerRandomAnswer : MonoBehaviour
{
    public static CatFollowerRandomAnswer instance;
    public static Action[] randomFollowerOutcome;
    public static Action onHelpfulAdvice;
    public static Action onWrongAdvice;
    public static Action onFollowerGift;
    public static Action onInsult;

    [SerializeField] 
    int allowedOutcomes;
    
    
    // Start is called before the first frame update
    void Awake()
    {
        //array to denote the possible outcomes of pressing the button for help
        randomFollowerOutcome = new[]
        {
            onInsult,
            onHelpfulAdvice,
            onWrongAdvice,
            onFollowerGift

        };
      


        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        SubscribeToEvents();
        
        DontDestroyOnLoad(gameObject);
    }


    void increaseEventPosibilities()
    {
        if (allowedOutcomes >= randomFollowerOutcome.Length)
        {
            allowedOutcomes = randomFollowerOutcome.Length;
        }
    }
    
    
    //This function is the one that once pressed the ask for help button in the ui, proceeds to generate a random event
    void GetAnswerFromFollowers()
    {
        int randomIndex = Random.Range(0, allowedOutcomes);
        randomFollowerOutcome[randomIndex]?.Invoke();
    }

    void SubscribeToEvents()
    {
        CatFollowersSystem.onNewFollowers += increaseEventPosibilities;
        CatFollowersSystem.onFollowersRequest += GetAnswerFromFollowers;
    }

    void UnSubscribeToEvents()
    {
        CatFollowersSystem.onNewFollowers -= increaseEventPosibilities;
        CatFollowersSystem.onFollowersRequest -= GetAnswerFromFollowers;
    }

    void OnDisable()
    {
        UnSubscribeToEvents();
    }
}
