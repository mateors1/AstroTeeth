using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ChatWindowTextTest : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI chatbox;

    [SerializeField]
    ScrollRect scrollRect;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("elburro", 1f,0.1f);
    }

    // Update is called once per frame

    void elburro()
    {
        chatbox.text = Caballoquemasletrote() + "\n"+ chatbox.text;
        //scrollRect.verticalNormalizedPosition = 1f;
    }


    string Caballoquemasletrote()
    {
        string[] caballoquemasletrote = new string[]
        {
            DynamicDialogSystem.instance.GetChatString(DialogType.Encouragement),
            DynamicDialogSystem.instance.GetChatString(DialogType.Discouragement)
        };

        return caballoquemasletrote[Random.Range(0, caballoquemasletrote.Length)];
    }
}
