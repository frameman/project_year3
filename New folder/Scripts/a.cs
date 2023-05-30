
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class a : MonoBehaviour
{
   public GameObject DepthCursor;
    private const float _waypointYOffset = 0.1f;
    public GameObject toilet;
    public GameObject Bowl;
    public GameObject cat;
    private GameObject _toilet;
    private GameObject _Bowl;
    private GameObject _cat;
    public  bool __buildToilet= false;
    public  bool __buildBowl= false;
    public  bool __buildCat= false;

    public void B_toilet()
    {
        if(!__buildToilet ){
            if (_toilet == null)
            {
                _toilet = new GameObject("toilet");
            }

            Vector3 pos = DepthCursor.transform.position;
            pos.y += _waypointYOffset;

            GameObject marker = Instantiate(toilet, pos, Quaternion.identity);
            marker.transform.parent = _toilet.transform;
            __buildToilet= true;
        }
    }  
     public void B_Bowl()
     {
        if(!__buildBowl ){
            if (_Bowl == null)
            {
                _Bowl = new GameObject("Bowl");
            }

            Vector3 pos = DepthCursor.transform.position;
            pos.y += _waypointYOffset;

            GameObject marker = Instantiate(Bowl, pos, Quaternion.identity);
            marker.transform.parent = _Bowl.transform;
            __buildBowl = true;
        }
     }
    public void B_cat()
    {
            if(!__buildCat){
             if (_cat == null)
            {
                _cat = new GameObject("cat");
            }

            Vector3 pos = DepthCursor.transform.position;
            pos.y += _waypointYOffset;

            GameObject marker = Instantiate(cat, pos, Quaternion.identity);
            marker.transform.parent = _cat.transform;
        }
        __buildCat = true;
    }
    
    
}
   
    
    

 
