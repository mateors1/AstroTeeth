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
        Debug.Log($"ImMoving at {SpawnsManager.instance.spawnMoveSpeed}");
       // MoveLeft();
        
    }

    // Update is called once per frame
    void OnDestroy()
    {

        GameManager.instance.followers += SpawnsManager.instance.followersValue;
    }

    void MoveLeft()
    {
        transform.Translate(Vector3.left * Time.deltaTime, Space.World);
    }
}
