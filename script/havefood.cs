using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class havefood : MonoBehaviour
{
  private GameObject food;
   
  //public void Update(){
  //  check_for_food();
  //}

   public void check_for_food(){
    food = GameObject.FindWithTag("food");
    if (food == null) 
    {
      ReturnToCamera findsone = GetComponent<ReturnToCamera>();
      findsone.find_master();
    }
    else
    {
      randommove ran=GetComponent<randommove>();
      ran.iseating = false;
      StartCoroutine(WaitAndPrint(10f));
    }
    
    IEnumerator WaitAndPrint(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Debug.Log("Waited for " + waitTime + " seconds.");
        randommove ran  = GetComponent<randommove>();
        ran.eatingTime = 0f;
        GameObject[] foodObjects = GameObject.FindGameObjectsWithTag("food");
        foreach (GameObject food in foodObjects)
        {
        Destroy(food);
        }
    }
   
    }
    }

