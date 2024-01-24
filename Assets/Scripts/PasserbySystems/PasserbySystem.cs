using System.Collections;
using UnityEngine;
using TMPro;
public class PasserbySystem : MonoBehaviour
{

    [SerializeField]
    GameObject chatBubble;
    TextMeshProUGUI dialogBox;

    [SerializeField]
    int timeOnScreen;

    void Start()
    {
        dialogBox = chatBubble.GetComponentInChildren<TextMeshProUGUI>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(DisplayChatBubble());
        }
    }

    IEnumerator DisplayChatBubble()
    {
        
        chatBubble.SetActive(true);
        dialogBox.text = DynamicDialogSystem.instance.GetChatString((DialogType.Passerby));
        yield return new WaitForSeconds(timeOnScreen);
        chatBubble.SetActive(false);
        dialogBox.text = "";
    }
}
