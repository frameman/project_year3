using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class eating : MonoBehaviour
{
    public Transform targetObject;
    public float moveSpeed = 0.5f;
    public float maxRotationAngle = 5f;
    public float fixedDistance = 3f;
    private Vector3 _initialOffset;
    public float finish_eating= 5f;
    public float time_to_eat =0f;
    public bool eating_food = false;
    public bool hasPlayedStartAnim = false;
    
    private void Start()
    {
        // Calculate initial offset based on target's rotation
        _initialOffset = targetObject.transform.forward * fixedDistance;
    }

    public void going_to_eat()
    {
            randommove ran  = GetComponent<randommove>();
            havefood hfd  = GetComponent<havefood>();
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
            action act = GetComponent<action>();
            act._walking();
            // Move the object towards the target offset position
            transform.position = Vector3.MoveTowards(transform.position, targetOffsetPosition, moveSpeed * Time.deltaTime);
        }
        
        else
        {
            ran.iseating = true;
            if(hfd.h_f)
            {
             if (!hasPlayedStartAnim)
            {
                ran.anim.Play("CatSimple_EatDrink_start");
                hasPlayedStartAnim = true;
            }
                
            if (!eating_food)
            {
                
                if (!ran.anim.GetCurrentAnimatorStateInfo(0).IsName("CatSimple_Eating") && time_to_eat>1.2)
                    {
                        ran.anim.Play("CatSimple_Eating");
                    }
                
                time_to_eat += Time.deltaTime;
            }
            
            if (time_to_eat  > finish_eating)
            {
                eating_food = true;
                ran.anim.Play("CatSimple_EatDrink_end");
                Invoke("ResetToiletTime", 1f);
                GameObject[] foodObjects = GameObject.FindGameObjectsWithTag("food");
                foreach (GameObject food in foodObjects)
                {
                    Destroy(food);
                }
                ran._come = true;
            }
            
            } 
        }   
    }
    
    private void ResetToiletTime()
    {
        print("eat");
        randommove ran  = GetComponent<randommove>();
        havefood hfd  = GetComponent<havefood>();
        hfd.h_f = false;
        time_to_eat = 0;
        ran.eatingTime =0f;
        hasPlayedStartAnim = false;
        eating_food = false;
        ran.iseating = false;
    }
}