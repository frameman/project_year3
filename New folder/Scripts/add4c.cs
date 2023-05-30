using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class add4c : MonoBehaviour
{
    
//adding 4 concers
    public GameObject DepthCursor;
    private const float _waypointYOffset = 0.1f;
    public GameObject lu; 
    public GameObject ld;
    public GameObject ru;
    public GameObject rd;
    private GameObject _lu;
    private GameObject _ld;
    private GameObject _rd;
    private GameObject _ru;

    public  bool _luf= false;
    public  bool _ldf= false;
    public  bool _ruf= false;
    public  bool _rdf= false;
    
    public void adding_4_points(){
    if(!_lu){
            if (_lu == null)
            {
                _lu = new GameObject("lu");
            }

            Vector3 pos = DepthCursor.transform.position;
            pos.y += _waypointYOffset;

            GameObject marker = Instantiate(lu, pos, Quaternion.identity);
            marker.transform.parent = _lu.transform;
            _luf= true;
        }
        
        else if(!_ld ){
            if (_ld == null)
            {
                _ld = new GameObject("ld");
            }

            Vector3 pos = DepthCursor.transform.position;
            pos.y += _waypointYOffset;

            GameObject marker = Instantiate(ld, pos, Quaternion.identity);
            marker.transform.parent = _ld.transform;
            _ldf = true;
        }
        else if(!_ru ){
            if (_ru == null)
            {
                _ru = new GameObject("ru");
            }

            Vector3 pos = DepthCursor.transform.position;
            pos.y += _waypointYOffset;

            GameObject marker = Instantiate(ru, pos, Quaternion.identity);
            marker.transform.parent = _ru.transform;
            _ruf = true;
        }   
        else if(!_rd ){
            if (_rd == null)
            {
                _rd = new GameObject("rd");
            }

            Vector3 pos = DepthCursor.transform.position;
            pos.y += _waypointYOffset;

            GameObject marker = Instantiate(rd, pos, Quaternion.identity);
            marker.transform.parent = _rd.transform;
            _rdf = true;
        }

   }
    
}
