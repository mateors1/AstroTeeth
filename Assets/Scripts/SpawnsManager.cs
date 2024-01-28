using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnsManager : MonoBehaviour
{
    public static SpawnsManager instance;

    public float spawnSpeed;
    public float incrementSpeed;

    public int followersValue;

    public float spawnMoveSpeed;
    public float spawnAcceleration;


    [SerializeField]
    GameObject[] props;

    [SerializeField]
    Vector2 SpawnCoordinates;

    [SerializeField]
    float spawnDistance;
    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        
        CatFollowersSystem.onNewFollowers += IncreaseSpeeds;
    }

    void Start()
    {
        StartCoroutine(SpawnProps(spawnSpeed));
    }


    IEnumerator SpawnProps(float spawnRate)
    {
        yield return new WaitForSeconds(spawnRate);

        // Check if there are any prefabs in the array
        if (props.Length > 0)
        {
            Vector3 spawnLocation = new Vector3(spawnDistance, Random.Range(SpawnCoordinates.x, SpawnCoordinates.y), 0);

            // Generate a random index within the valid range
            int index = Random.Range(0, props.Length);

            // Instantiate the prefab
            Instantiate(props[index], spawnLocation, props[index].transform.rotation);
        }

        // Continue spawning
        StartCoroutine(SpawnProps(spawnSpeed));
    }

    

    void IncreaseSpeeds()
    {
        spawnSpeed += incrementSpeed;
        spawnMoveSpeed += spawnAcceleration;
    }
   
    // Start is called before the first frame update
    public void MoveLeft(Transform movingobject)
    {
        movingobject.Translate(Vector3.left * spawnMoveSpeed * Time.deltaTime, Space.World);
    }
}
