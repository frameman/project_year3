using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationtesting : MonoBehaviour
{
    public float elapsedTime = 0f;
    public float minForwardDot = 0.7f;
    public float moveSpeed = 5f;
    public float maxRotationAngle = 1f;
    private Vector3 randomDirection;
    public Animator anim;


    void Start(){
      

    }
    void Update()
    {
        elapsedTime += Time.deltaTime;
        anim = GetComponent<Animator>();
        anim.Play("CatSimple_Swim_R_RM");
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
}

