
using System.Collections;
using UnityEngine;
using DG.Tweening;
using Debug = UnityEngine.Debug;
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
        Debug.Log("The arrow points the right place");
        StartCoroutine(PointNearestTarget());

    }

    void RandomTarget()
    {
        Debug.Log("The arrow goes brr");
        Vector3  randomAngle = new Vector3(0,0, Random.Range(0, 1080f));
        StartCoroutine(RotateTheArrow(randomAngle));
    }

    IEnumerator RotateTheArrow(Vector3 rotationDirection)
    {
        arrow.SetActive(true);
        arrow.transform.DORotate(rotationDirection, rotationDuration, RotateMode.FastBeyond360);
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

                // Calculate the rotation quaternion using LookRotation
                Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, targetPosition);

                // Convert the rotation quaternion to Euler angles
                Vector3 targetDirection = targetRotation.eulerAngles;
                StartCoroutine(RotateTheArrow(targetDirection));
            }
        }
        yield return null;
    }

   void  OnDisable()
    {
        Debug.Log("YaVali");
    }
}
