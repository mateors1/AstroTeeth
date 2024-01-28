using UnityEngine;

public class SpawnBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        if (SpawnsManager.instance == null || SpawnsManager.instance.spawnMoveSpeed == 0)
        {
            //SpawnsManager.instance.spawnMoveSpeed += 6;
        }
        SpawnsManager.instance.MoveLeft(transform);
        
        
    }

    // Update is called once per frame
    void OnDestroy()
    {

        GameManager.instance.followers += SpawnsManager.instance.followersValue;
    }


}
