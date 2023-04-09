using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randommove : MonoBehaviour
{
    public float elapsedTime = 0f;
    public float minForwardDot = 0.7f;
    public float moveSpeed = 5f;
    public float maxRotationAngle = 1f;
    private Vector3 randomDirection;
    public float toiletTime = 0f;
    public float eatingTime = 0f;
    public float time_to_toilet =5f;
    public float time_to_eat = 13f;
    
    void Update()
    {

        if (eatingTime<=time_to_eat && toiletTime <= time_to_toilet)
        {
            eatingTime += Time.deltaTime;
            toiletTime += Time.deltaTime;
            elapsedTime += Time.deltaTime;
        if (elapsedTime >= 5f)
        {
            // Generate a new random direction after 2 seconds
            randomDirection = Random.insideUnitSphere;
            randomDirection.y = 0f;
            elapsedTime = 0f;
        }

        // Check the dot product between the current and target directions
        float forwardDot = Vector3.Dot(transform.forward, randomDirection);

        // Rotate towards the random direction if the dot product is below the threshold
        if (forwardDot < minForwardDot)
        {
            Quaternion targetRotation = Quaternion.LookRotation(randomDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, maxRotationAngle);
        }

        // Move forward
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
            else if(eatingTime>=time_to_eat){
                eating eat  = GetComponent<eating>();
                eat.going_to_eat();
                
            }
            else if(toiletTime>=time_to_toilet){
                toilet toileting = GetComponent<toilet>();
                toileting.going_toilet();
               
        }
    }
}
