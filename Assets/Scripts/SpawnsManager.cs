using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnsManager : MonoBehaviour
{
    public static SpawnsManager instance;

    public float spawnSpeed;
    public float incrementSpeed;

    public int followersValue;

    public float spawnMoveSpeed;
    public float spawnAcceleration;

    void awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        
        CatFollowersSystem.onNewFollowers += IncreaseSpeeds;
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
