using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class havefood : MonoBehaviour
{
  public float finish_eating= 5f;
  public float time_to_eat =0f;
  public bool eating_food = false;
  public bool hasPlayedStartAnim = false;
  private GameObject food;
   
  //public void Update(){
  //  check_for_food();
  //}

   public void check_for_food(){
    randommove ran  = GetComponent<randommove>();
    food = GameObject.FindWithTag("food");
    if (food == null) 
    {
      ReturnToCamera findsone = GetComponent<ReturnToCamera>();
      findsone.find_master();
    }
    else
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
    
            }
        
    }
  }
  private void ResetToiletTime()
  {
    print("eat");
    randommove ran  = GetComponent<randommove>();
    time_to_eat = 0;
    ran.eatingTime =0f;
    hasPlayedStartAnim = false;
    eating_food = false;
  }
 
  
}
  

