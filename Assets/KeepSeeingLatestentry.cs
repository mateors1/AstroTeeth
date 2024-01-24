
using UnityEngine;

public class KeepSeeingLatestEntry : MonoBehaviour
{
    [SerializeField]
    RectTransform contentRectTransform;
    

    void Start()
    {
    contentRectTransform.anchoredPosition = contentRectTransform.sizeDelta;
    }


}
