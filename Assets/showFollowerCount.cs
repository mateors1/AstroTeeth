
using UnityEngine;
using TMPro;
public class showFollowerCount : MonoBehaviour
{
    TextMeshProUGUI scoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = $"{GameManager.instance.followers}";
    }
}
