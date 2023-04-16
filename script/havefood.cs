using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class havefood : MonoBehaviour
{
  public bool h_f = false;
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
      h_f = true;
      eating eat  = GetComponent<eating>();
      eat.going_to_eat();
 
    }
  }
  
 
}
  

