using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class CatFollowerRandomAnswer : MonoBehaviour
{
    public static CatFollowerRandomAnswer instance;
    public static Action[] randomFollowerOutcome;
    public static Action onHelpfulAdvice;
    public static Action onWrongAdvice;
    public static Action onFollowerGift;
    public static Action onInsult;

    [Header("How many options are available at game start")]
    [SerializeField] 
    int allowedOutcomes;

    [Header("Button and Cooldown Properties")]
    [SerializeField]
    Button phoneButton;

    [SerializeField]
    float cooldownTimer;
    
    
    // Start is called before the first frame update
    void Awake()
    {
        //array to denote the possible outcomes of pressing the button for help
        randomFollowerOutcome = new[]
        {
            onInsult,
            onHelpfulAdvice,
            onWrongAdvice,
            onHelpfulAdvice,
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

    //route the onclick in the button to this function//
   public void AskFollowersForHelp()
    {
        GetAnswerFromFollowers();
        phoneButton.interactable = false;
        StartCoroutine(CooldownCoroutine());
    }

    IEnumerator CooldownCoroutine()
    {
        float cooldownTime = cooldownTimer;

        while (cooldownTime > 0)
        {
            // Calculate the normalized progress of the cooldown
            float normalizedCooldownProgress = 1 - (cooldownTime / cooldownTimer);

            // Use Mathf.Lerp to smoothly interpolate between 0 and 1
            float lerpedValue = Mathf.Lerp(0f, 1f, normalizedCooldownProgress);

            // Update shader property for visual feedback
           // materialWithCooldownShader.SetFloat("_CooldownProgress", lerpedValue);

            // Wait for one second
            yield return new WaitForSeconds(1f);

            // Decrement the cooldown time
            cooldownTime -= 1f;
        }

        /*uncomment when the button has been created
        // Reset shader property when cooldown is complete
       // materialWithCooldownShader.SetFloat("_CooldownProgress", 0f); */

        // Cooldown finished, enable the button
        phoneButton.interactable = true;
    }
    
    void GetAnswerFromFollowers()
    {
        if (allowedOutcomes > randomFollowerOutcome.Length)
        {
            allowedOutcomes = randomFollowerOutcome.Length;
        }
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
