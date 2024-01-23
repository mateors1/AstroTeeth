
using System;
using System.Collections;
using UnityEngine;
using DG.Tweening;
using Random = UnityEngine.Random;

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

    [SerializeField]
    GameObject player;
    
    
    
   
    void Awake()
    {
        CatFollowerRandomAnswer.onHelpfulAdvice += PointToTarget;
        CatFollowerRandomAnswer.onWrongAdvice += RandomTarget;
    }


    void PointToTarget()
    {
        StartCoroutine(PointNearestTarget());

    }

    void RandomTarget()
    {
        Vector3  randomAngle = new Vector3(0,0, Random.Range(0, 1080f));
        StartCoroutine(RotateTheArrow(randomAngle));
    }

    IEnumerator RotateTheArrow(Vector3 rotationDirection)
    {
        arrow.SetActive(true);
        arrow.transform.DORotate(rotationDirection, 1f, RotateMode.FastBeyond360);
        yield return new WaitForSeconds(timeToDespawn);
        arrow.SetActive(false);
    }

    Transform GetNearestActiveTarget(GameObject[] targets)
    {
        Transform nearestTarget = null;
        float closestDistance = float.MaxValue;
        foreach (GameObject target in targets)
        {
            if (target.activeSelf)
            {
                float distance = Vector2.Distance(player.transform.position, target.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    nearestTarget = target.transform;
                }
            }
        }
        return nearestTarget;
    }

    IEnumerator PointNearestTarget()
    {
        if (arrow != null)
        {
            GameObject[] targets = GameObject.FindGameObjectsWithTag(targetTag);
            Transform nearestTarget = GetNearestActiveTarget(targets);
            if (nearestTarget != null)
            {
                Vector3 targetPosition = nearestTarget.position - player.transform.position;
                Vector3 targetDirection =
                    new Vector3(0, 0, Mathf.Atan2(targetPosition.x, targetPosition.y) * Mathf.Rad2Deg);
                StartCoroutine(RotateTheArrow(targetDirection));
            }
        }
        yield return null;
    }
    
}
