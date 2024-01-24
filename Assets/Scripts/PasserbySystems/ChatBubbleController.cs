
using UnityEngine;
using DG.Tweening;

public class ChatBubbleController : MonoBehaviour
{
    [SerializeField]
    float maxBubbleSize;

    [SerializeField]
    float expandTime;
    void OnEnable()
    {
        transform.localScale = Vector3.zero;
        transform.DOKill();
        transform.DOScale(maxBubbleSize, expandTime);
    }

    void OnDisable()
    {
        transform.DOKill();
        //transform.localScale = Vector3.zero;
        
    }
}
