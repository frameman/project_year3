using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toilet : MonoBehaviour
{
    public float toiletTime = 0f;
    public float time_to_toilet =5f;
    public float delayTime = 5f;
    private Vector3 _initialOffset;
    public Transform targetObject;
    public float moveSpeed = 100f;
    public float maxRotationAngle = 5f;
    public float fixedDistance = 100f;

    // Update is called once per frame
    public void going_toilet(){
            Vector3 targetPosition = targetObject.position;
            Vector3 objectPosition = transform.position;
            Vector3 direction = targetPosition - objectPosition;
            direction.y = 0f;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, maxRotationAngle);

            // Calculate target offset position based on initial offset and target position
            Vector3 targetOffsetPosition = targetPosition + targetObject.transform.rotation * _initialOffset;
            targetOffsetPosition.y = objectPosition.y;

        float distanceToTarget = Vector3.Distance(transform.position, targetOffsetPosition);

        // Check if the distance to the target is greater than the fixed distance
        if (distanceToTarget >= fixedDistance)
        {
            // Move the object towards the target offset position
            transform.position = Vector3.MoveTowards(transform.position, targetOffsetPosition, moveSpeed * Time.deltaTime);
        }
        else
        {
            StartCoroutine(WaitAndPrint(10f));
        }
        
    }
    
    IEnumerator WaitAndPrint(float waitTime)
    {
        randommove ran  = GetComponent<randommove>();
        yield return new WaitForSeconds(waitTime);
        Debug.Log("Waited for " + waitTime + " seconds.");
        ran.toiletTime = 0;
    }
}
