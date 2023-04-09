using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BigMovement : MonoBehaviour
{
    public GameObject targetObject;
    public float eatingTime = 0f; // connected to eating scripts
    public float toiletTime = 0f;
    public float time_to_toilet =5f;

    public float delayTime = 100f;
    public float moveSpeed = 5f;
    public float elapsedTime = 0f;
    
    public float minForwardDot = 0.7f;
    public Vector3 randomDirection;
    public Transform targetPosition;
    public float maxRotationAngle = 5f;
    
    public string targetTag ="toilet";
   

    public bool isTurning = false;
    public bool shouldMove = true;

    public void Start()
    {
        targetPosition = targetObject.transform;
    }

    public void Update()
    {
        
        if (toiletTime < time_to_toilet )
        {
            toiletTime += Time.deltaTime;
            if (shouldMove)
            {
                Debug.Log("moving");
                moveforward();
            }
        }
        
        if (toiletTime >= time_to_toilet )
        {
            if (!isTurning)
            { 
               turn();
            }
        }
    }
    
       

   public void moveforward()
   {
        if (elapsedTime >= 2f)
        {
            // Generate a new random direction after 2 seconds
            Vector3 targetForward = Random.insideUnitSphere;
            targetForward.y = 0f;
            Quaternion lookRotation = Quaternion.LookRotation(targetForward);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);
            elapsedTime = 0f;
        }
        else
        {
            // Move in the current direction for 2 seconds
            Vector3 targetForward = transform.forward;
            targetForward.y = 0f;
            Quaternion lookRotation = Quaternion.LookRotation(targetForward);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);
            float forwardDot = Vector3.Dot(transform.forward, targetForward);
            if (forwardDot >= minForwardDot)
            {
                // Check if the object is within a certain distance from the target
                if (Vector3.Distance(transform.position, targetObject.transform.position) > 0.5f)
                {
                    transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
                }
            }
            elapsedTime += Time.deltaTime;
        }
   }

    public void turn()
    {
        Vector3 direction = targetPosition.position - transform.position;
        float distance = direction.magnitude;
        direction.y = 0f;
        if (distance > 1f)
        {
            
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, maxRotationAngle);
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        else
        {
            shouldMove = false; // stop movement
            isTurning = true; 
            StartCoroutine(WaitAndPrint(delayTime));
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");
        if (other.gameObject.tag == targetTag)
        {
            if (toiletTime > time_to_toilet){
            isTurning = true; 
            StartCoroutine(WaitAndPrint(delayTime));
           }
        }
        
    }

     IEnumerator WaitAndPrint(float waitTime)
    {
        
        yield return new WaitForSeconds(waitTime);
        Debug.Log("Waited for " + waitTime + " seconds.");
        toiletTime = 0;
        transform.Rotate(new Vector3(0f, 180f, 0f), Space.Self);
        shouldMove = true; // resume movement
        isTurning = false;
    }

}