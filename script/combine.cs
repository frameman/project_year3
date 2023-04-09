using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combine : MonoBehaviour
{
    public GameObject targetObject;
    public float moveSpeed = 5f;
    public float elapsedTime = 0f;
    public float toiletTime = 0f;
    public bool isMovingRandomly = true;
    public float delayTime = 3f;
    public float minForwardDot = 0.2f;
    private Vector3 randomDirection;
    private Transform targetPosition;

    private void Start()
    {
        targetPosition = targetObject.transform;

    }

    private void Update()
    {
        moveforward();
    }


    public void moveforward(){
     if (elapsedTime >= 1f)
            {
                // Generate a new random direction after 2 seconds
                Vector3 targetForward = Random.insideUnitSphere;
                targetForward.y = 0f;
                Quaternion lookRotation = Quaternion.LookRotation(targetForward);
                transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 10f);
                elapsedTime = 0f;
            }
            else
            {
                // Move in the current direction for 2 seconds
                Vector3 targetForward = transform.forward;
                targetForward.y = 0f;
                Quaternion lookRotation = Quaternion.LookRotation(targetForward);
                transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 10f);
                float forwardDot = Vector3.Dot(transform.forward, targetForward);
                if (forwardDot >= minForwardDot)
                {
                transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
                }
                elapsedTime += Time.deltaTime;
            }
    }

    IEnumerator WaitAndPrint(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Debug.Log("Waited for " + waitTime + " seconds.");
        isMovingRandomly = true;
    }

}