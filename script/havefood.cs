using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class havefood : MonoBehaviour
{
  public GameObject food;

   public void check_for_food(){
    food = GameObject.FindWithTag("food");
    if (food != null) 
    {
    move_towards find_master = GetComponent<move_towards>();
    find_master.finding_sOne();
    } 
    }
}
