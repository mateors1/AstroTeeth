using System.Collections;
using UnityEngine;
using TMPro;


public class PasserbySystem : MonoBehaviour
{

    
    /*[SerializeField]
    GameObject chatBubble;
    TextMeshProUGUI dialogBox;*/

    [SerializeField]
    float transformOffset;
    
    [SerializeField]
    int timeOnScreen;

    [SerializeField]
    int newFollowersValue= 20;

  /*  void OnEnable()
    {
        chatBubble = gameObject.Find("ChatBubble");
        dialogBox = chatBubble.GetComponentInChildren<TextMeshProUGUI>();
    }*/

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //StartCoroutine(DisplayChatBubble());
            GameManager.instance.followers += newFollowersValue;
        }
    }

   /* IEnumerator DisplayChatBubble()
    {
        
        chatBubble.SetActive(true);
        chatBubble.transform.position = transform.position * transformOffset;
        dialogBox.text = DynamicDialogSystem.instance.GetChatString((DialogType.Passerby));
        yield return new WaitForSeconds(timeOnScreen);
        chatBubble.SetActive(false);
        dialogBox.text = "";
    }*/
}
