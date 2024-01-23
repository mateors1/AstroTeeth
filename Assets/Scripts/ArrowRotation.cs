
using System.Collections;
using UnityEngine;
using DG.Tweening;

public class ArrowRotation : MonoBehaviour
{
    [SerializeField]
    GameObject arrow;

    [SerializeField]
    string targetTag;

    [SerializeField]
    float rotationDuration;

    [SerializeField]
    int timeToDespawn;
    
    
    
   
    void Awake()
    {
        CatFollowerRandomAnswer.onHelpfulAdvice += PointToTarget;
        CatFollowerRandomAnswer.onWrongAdvice += RandomTarget;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PointToTarget()
    {
        
    }

    void RandomTarget()
    {
        Vector3  randomAngle = new Vector3(0,0, Random.Range(0, 1080f));
        StartCoroutine(RotateTheArrow(randomAngle));
    }

    IEnumerator RotateTheArrow(Vector3 rotationDirection)
    {
        arrow.transform.DORotate(rotationDirection, 2f, RotateMode.FastBeyond360);
        yield return new WaitForSeconds(timeToDespawn);
    }
    
    Vector3 GetNearestTarget
    
}
