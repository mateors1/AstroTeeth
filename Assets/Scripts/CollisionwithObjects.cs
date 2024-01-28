using UnityEngine;
using System.Linq;

public class CollisionwithObjects : MonoBehaviour
{
    [SerializeField]
    string[] obstacleTags;
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D other)
    {
        if (obstacleTags.Contains(other.gameObject.tag.ToLower()))
        {
            CatFollowersSystem.onDisconnect?.Invoke();
        }
        
    }

 
}
