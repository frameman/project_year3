using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class eating : MonoBehaviour
{
    public Transform targetObject;
    public float moveSpeed = 100f;
    public float maxRotationAngle = 5f;
    public float fixedDistance = 100f;
    private Vector3 _initialOffset;

    private void Start()
    {
        // Calculate initial offset based on target's rotation
        _initialOffset = targetObject.transform.forward * fixedDistance;
    }

    public void going_to_eat()
    {
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
            randommove ran=GetComponent<randommove>();
            ran.iseating = true;
        }
        
    }
}