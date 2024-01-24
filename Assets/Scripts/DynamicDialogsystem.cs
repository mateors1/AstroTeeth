
using UnityEngine;
using Random = UnityEngine.Random;

public enum DialogType
{
    Encouragement,
    Discouragement,
    Trolling,
    Passerby,
    PowerUpChat1,
    PowerUpChat2,
    PowerUpChat3
}
   
    


public class DynamicDialogSystem : MonoBehaviour
{
    public static DynamicDialogSystem instance;

    [Header("standard chats to be displayed")]
    public DialogsObjects encouragementChats;

    public DialogsObjects discouragementChats;

    public DialogsObjects trollingChats;
    [Header("Dialogs that the passerby will say ")]
    public DialogsObjects passerbyChats;
    [Header("Follower's responses for powerUps")]
    public DialogsObjects powerUpChat1;

    public DialogsObjects powerUpChat2;

    public DialogsObjects powerUpChat3;


    void Awake()
    {
        instance = this;
        if (instance != null)
        {
            Debug.Log("Dynamic Dialog System Activated");
        }
    }

    // Start is called before the first frame update
    public string GetChatString(DialogType dialogType)
    {
        string[] selectedOutcome = null;
        switch (dialogType)
        {
                
            case DialogType.Encouragement:
                selectedOutcome = encouragementChats.dialogs;
                break;
                
            case DialogType.Discouragement:
                selectedOutcome = discouragementChats.dialogs;
                break;
           
            case DialogType.Trolling:
                selectedOutcome = trollingChats.dialogs;
                break;
            
            case DialogType.Passerby:
                selectedOutcome = passerbyChats.dialogs;
                break;
            
            case DialogType.PowerUpChat1:
                selectedOutcome = powerUpChat1.dialogs;
                break;
            
            case DialogType.PowerUpChat2:
                selectedOutcome = powerUpChat2.dialogs;
                break;
                
            case DialogType.PowerUpChat3:
                selectedOutcome = powerUpChat3.dialogs;
                break;
                
            default:
                Debug.Log("No Option selected");
                break;
            
            
            
        }
        if (selectedOutcome != null && selectedOutcome.Length > 0)
        {
            return selectedOutcome[Random.Range(0, selectedOutcome.Length)];
        }
        else
        {
            Debug.Log("there are no dialog options");
            return "Wow, such meme, WoW";
        }
    }


}
