using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class action : MonoBehaviour
{
    public int choice = 0;
    public bool _active = true;
    public bool _lie = false;
    public bool _lie_end = false;
    public Animator anim;
    public float walktime = 0;
    public float restTime = 1;
    public bool re_judgment = true;
    public bool flag = true;
    public int changeMod = 0;
    public int _walk_long = 0;
    public bool _find = true;
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void mood(){
        randommove ran = GetComponent<randommove>();
        if (_find){
            if(re_judgment)
            {
                if(flag){
                rand();
                flag = false;
                }
            re_judgment = false;
        
            if(choice<=7)
            {
              _walking();
              ran.turning = true;
            }

            else
            {
                if(changeMod ==0)
                {
                    liedown();
                    ran.turning = false;
                }

                else
                {
                    _walking();
                    changeMod = 0;
                    ran.turning = true;
                }   
            }
            }
        
        }
    }


    void Update()
    {
        
    }

    private void ResetToiletTime()
    {
        
    }
    IEnumerator Delayedwalk(){
        yield return new WaitForSeconds(walktime);
        re_judgment = true;
        flag = true;
    }

    IEnumerator Delayedrest(){
        yield return new WaitForSeconds(1f);
        restTime = restTime - 1;
        re_judgment = true;
    }
    IEnumerator Delayedlie(){

        yield return new WaitForSeconds(1f);
        re_judgment = true;
    }
    IEnumerator Delayedlie1(){
  
        yield return new WaitForSeconds(1f);
        re_judgment = true;
        flag = true;
    }

public void rand(){
    choice = UnityEngine.Random.Range(1,10);
}

public void _walking(){
                _walk_long = 0;
                walktime = UnityEngine.Random.Range(3,5);
                print(walktime);
                anim.Play("atSimple_Walk_F_IPP");
                Invoke("ResetToiletTime", 1f);
                StartCoroutine(Delayedwalk());
}

public void liedown(){
                _walk_long = 1;
                
                if (!_lie)
                {
                        restTime = UnityEngine.Random.Range(3,5);
                        print(restTime);
                        anim.Play("CatSimple_Lie_side_start");
                        Invoke("ResetToiletTime", 1f);
                        StartCoroutine(Delayedlie());
                        _lie = true;
                        _lie_end = false;
                    }
                    else if( !anim.GetCurrentAnimatorStateInfo(0).IsName("CatSimple_Lie_side_loop_2") || restTime>0){
                        anim.Play("CatSimple_Lie_side_loop_2");
                        Invoke("ResetToiletTime", 1f);
                        StartCoroutine(Delayedrest());
                    
                    }

                    if(restTime <= 0 && !_lie_end){
                        anim.Play("CatSimple_Lie_side_end");
                        Invoke("ResetToiletTime", 1f);
                        StartCoroutine(Delayedlie1());
                        _lie_end = true;
                        _lie = false;
                        changeMod = 1;
                    }
                }
}
