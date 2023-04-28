using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randommove : MonoBehaviour
{
    public float elapsedTime = 0f;
    public float minForwardDot = 0.7f;
    public float moveSpeed = 0.5f;
    public float maxRotationAngle = 1f;
    private Vector3 randomDirection;
    public float toiletTime = 0f;
    public float eatingTime = 0f;
    public float time_to_toilet = 0f;
    public float time_to_eat = 0f;
    
    public Animator anim;
    public bool _move = true;
    public bool _come = true;
    public bool iseating = false;
    public bool walking = true;
    public bool turning = true;
    

    void Start(){
     
        anim = GetComponent<Animator>();
        time_to_toilet = 3f;//UnityEngine.Random.Range(1f, 5f);
        time_to_eat = 2f;//UnityEngine.Random.Range(4f, 10f);
    }
    void Update()
    {
        if(_come){

        if (eatingTime<time_to_eat && toiletTime < time_to_toilet )
        {
            action act = GetComponent<action>();
            act.mood();
            eatingTime += Time.deltaTime;
            toiletTime += Time.deltaTime;
            elapsedTime += Time.deltaTime;
        if (elapsedTime >= 5f && turning)
        {
            // Generate a new random direction after 2 seconds
            randomDirection = Random.insideUnitSphere;
            randomDirection.y = 0f;
            elapsedTime = 0f;
        }

        // Check the dot product between the current and target directions
        float forwardDot = Vector3.Dot(transform.forward, randomDirection);
        if (forwardDot > 0)
        {
     
        }
        else if (forwardDot < 0)
        {
    
        }

        // Rotate towards the random direction if the dot product is below the threshold
        if (forwardDot < minForwardDot)
        {
            Quaternion targetRotation = Quaternion.LookRotation(randomDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, maxRotationAngle);
        }

        // Move forward
        if (act._walk_long == 0 ){
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        
        }
        else if(!iseating && eatingTime>=time_to_eat)
            {
                _move = false;
                eating eat  = GetComponent<eating>();
                eat.going_to_eat();
            }
            else if( toiletTime>time_to_toilet)
            {
                _move = false;
                toilet toileting = GetComponent<toilet>();
                toileting.going_toilet();
            }
             else
            {
                havefood finding = GetComponent<havefood>();
                finding.check_for_food();
            }
             
    
    }
    
    }
}

