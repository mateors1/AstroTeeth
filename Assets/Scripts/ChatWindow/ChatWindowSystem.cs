
using System.Collections;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class ChatWindowSystem : MonoBehaviour
{
    [Header("Parameters for standard text speed")]
    [SerializeField]
    [Tooltip("The current time between chat  responses")]
    float delayBetweenRandomTexts;

    [SerializeField]
    [Tooltip("The time that gets shaved from current time each" +
             " time the player reaches a new follower milestone")]
    float increaseRateBetweenTexts;

    [SerializeField]
    [Tooltip("Truncates how fast can the chat go")]
    float minTimeBetweenTexts;

    [SerializeField]
    [Tooltip("Indicates the maximum of chats given from an specific event")]
    int maxResponsesPerEvent;
    
    [SerializeField]
    int responsesOnEvent;

    [SerializeField]
    TextMeshProUGUI chatbox;

    [SerializeField]
    StreamUserNames usernames;

    void Awake()
    {
        SubscribeToEvents();
    }

    void Start()
    {
        StartCoroutine(StandardScrollingText(delayBetweenRandomTexts));

    }

    IEnumerator StandardScrollingText(float timebetweenchats)
    {
        string[] standardResponses = new[]
        {
            DynamicDialogSystem.instance.GetChatString(DialogType.Encouragement),
            DynamicDialogSystem.instance.GetChatString(DialogType.Discouragement),
            DynamicDialogSystem.instance.GetChatString(DialogType.Trolling)
        };
        chatbox.text = FormattedUserDialog(standardResponses[Random.Range(0, standardResponses.Length)]);
        yield return new WaitForSeconds(delayBetweenRandomTexts);
        StartCoroutine(StandardScrollingText(delayBetweenRandomTexts));


    }

    string FormattedUserDialog(string dialog)
    {
        return
            $"<color=#{UserColor()}>{usernames.usernames[Random.Range(0, usernames.usernames.Length)]}</color>: \n {dialog} \n {chatbox.text}";
    }

    string UserColor()
    {
        return $"{ColorUtility.ToHtmlStringRGB(GetRandomColor())}";
    }

    Color GetRandomColor()
    {
        float r = Random.value;
        float g = Random.value;
        float b = Random.value;

        return new Color(r, g, b);
    }

    // Reduces the delay between random texts
    void IncreasingFanbaseInteraction()
    {
        if (delayBetweenRandomTexts > minTimeBetweenTexts)
        {
            delayBetweenRandomTexts -= increaseRateBetweenTexts;
        }
        else
        {
            delayBetweenRandomTexts = minTimeBetweenTexts;
        }

    }



    void EventText(DialogType eventResponse)
    {
        
        int responsesForEvent = Random.Range(1, maxResponsesPerEvent);
        while (responsesForEvent > 0)
        {
            chatbox.text = FormattedUserDialog(DynamicDialogSystem.instance.GetChatString(eventResponse));
            responsesForEvent--;
        }
       
    }



    void SubscribeToEvents()
    {
        CatFollowersSystem.onNewFollowers += IncreasingFanbaseInteraction;
        CatFollowersSystem.onNewFollowers += () => { EventText(DialogType.NewFollower); };
        CatFollowersSystem.onFollowersHelp += () => { EventText(DialogType.HelpFulAdvice); };
        CatFollowerRandomAnswer.onWrongAdvice += () => { EventText(DialogType.Trolling); };
        CatFollowerRandomAnswer.onInsult += () => { EventText(DialogType.Discouragement); };
        CatFollowerRandomAnswer.onPowerup1 += () => { EventText(DialogType.PowerUpChat1); };
        CatFollowerRandomAnswer.onPowerup2 += () => { EventText(DialogType.PowerUpChat2); };
        CatFollowerRandomAnswer.onPowerup3 += () => { EventText(DialogType.PowerUpChat3); };
    }

    void UnsubscribeToEvents()
        {
            CatFollowersSystem.onNewFollowers -= IncreasingFanbaseInteraction;
            CatFollowersSystem.onNewFollowers -= () => { EventText(DialogType.NewFollower); };
            CatFollowersSystem.onFollowersHelp -= () => { EventText(DialogType.HelpFulAdvice); };
            CatFollowerRandomAnswer.onWrongAdvice -= () =>  { EventText(DialogType.Trolling); };
            CatFollowerRandomAnswer.onInsult -= () => { EventText(DialogType.Discouragement); };
            CatFollowerRandomAnswer.onPowerup1 -= () =>  { EventText(DialogType.PowerUpChat1); };
            CatFollowerRandomAnswer.onPowerup2 -= () =>  { EventText(DialogType.PowerUpChat2); };
            CatFollowerRandomAnswer.onPowerup3 -= () =>  { EventText(DialogType.PowerUpChat3); };
        }

        void OnDestroy()
        {
            UnsubscribeToEvents();
        }
    }

