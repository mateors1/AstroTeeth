using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    
    [SerializeField]
    int _followerthreshold;

    [SerializeField]
    int _followers;

    public int followers
    {
        get { return _followers; }
        
        set
        {
            _followers = value;

            OnNewFollowers();

        }
    }

   

    // Start is called before the first frame update
    void Awake()
    {
        Time.timeScale = 1;
        if (instance == null)
        {
            instance = this;
        }
        

        

        // Update is called once per frame
        
    }
    
    void OnNewFollowers()
    {
        if (followers % _followerthreshold == 0)
        {
            CatFollowersSystem.onNewFollowers?.Invoke();
        }
            
    }
}
