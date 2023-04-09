using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turning : MonoBehaviour
{

    public GameObject targetObject;
    private Vector3 randomDirection;
    private Transform targetTransform;
    public float maxRotationAngle = 5f;
    public float moveSpeed = 2f;
    public bool isturn = false;

    void Start()
    {
        targetTransform = targetObject.transform;
    }

    void Update()
    {
        turn(false);
    }

    public void turn(bool isturn)
    {
        Vector3 direction = targetTransform.position - transform.position;
        float distance = direction.magnitude;
        if (!isturn)
        {
            direction = targetTransform.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, maxRotationAngle);
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            if (distance < 0f)
            {
                isturn = false;
            }
        }
    }
}
