using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class toilet : MonoBehaviour
{
    public float toilet_finish= 10f;
    public float time_to_toilet =0f;
    private Vector3 _initialOffset;
    public Transform targetObject;
    public float moveSpeed = 100f;
    public float maxRotationAngle = 5f;
    public float fixedDistance = 0.1f;
    public bool hasPlayedStartAnim = false;
    public bool waiting = false;

    public void Start(){
      
    }

    // Update is called once per frame
    public void going_toilet(){
            randommove ran  = GetComponent<randommove>();
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
        if (distanceToTarget > 0 )
        {
            action act = GetComponent<action>();
            act._walking();
            // Move the object towards the target offset position
            transform.position = Vector3.MoveTowards(transform.position, targetOffsetPosition, moveSpeed * Time.deltaTime);
    
        }   
    else
        {
            if (!hasPlayedStartAnim)
            {
                ran.anim.Play("CatSimple_Idle_6");
                Invoke("Sit", 6f);
                
            }
            
            else if (!waiting)
            {
                if (!ran.anim.GetCurrentAnimatorStateInfo(0).IsName("CatSimple_Sit_loop_2") && time_to_toilet>1.2)
                {
                ran.anim.Play("CatSimple_Sit_loop_2");
                }
                time_to_toilet += Time.deltaTime;
            

                if (time_to_toilet > toilet_finish )
                {
                    waiting = true;
                    ran.anim.Play("CatSimple_Sit_end");
                    Invoke("ResetToiletTime", 7f);
                }
            }
           

        }
        

    }

    private void ResetToiletTime()
    {
     reset();
    }

    private void Sit()
    {
        hasPlayedStartAnim = true;
    }


    public void reset(){
        randommove ran  = GetComponent<randommove>();
        time_to_toilet = 0;
        ran.toiletTime =0f;
        ran.time_to_toilet =UnityEngine.Random.Range(60f, 181f);
        hasPlayedStartAnim = false;
        waiting = false;
    }



IEnumerator DelayeUP(){
    yield return new WaitForSeconds(1f);
    
    }
}