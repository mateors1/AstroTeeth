using UnityEngine;

public class CollisionwithObjects : MonoBehaviour
{
    [SerializeField]
    string tag;
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(tag))
        {
            CatFollowersSystem.onDisconnect?.Invoke();
        }
        
    }
}
