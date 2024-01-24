
using UnityEngine;
using Debug = UnityEngine.Debug;

public class PasserbySystemTest : MonoBehaviour
{

    [SerializeField]
    string targetTag;

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(targetTag))
        {
            Debug.Log("ay mira. un michi");
        }
    }

}
