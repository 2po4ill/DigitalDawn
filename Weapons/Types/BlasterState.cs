using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class BlasterState : MonoBehaviour
{
    public GameObject[] list;

    Animator animator;

    const string IS_TRIGGERED = "IsTriggered";
    const string IS_ALL_TRIGGERED = "IsAllTriggered";

    

    public void ChangeState(int id){
        ChangeAnimatorBool(id);
    }
    
    void ChangeAnimatorBool(int id){
        if (id == list.Length){
            foreach (GameObject gameObject in list){
                animator = gameObject.GetComponent<Animator>();
                animator.SetBool(IS_ALL_TRIGGERED, true);
            }
        }
        else {
            animator = list[id-1].GetComponent<Animator>();
            animator.SetBool(IS_TRIGGERED, true);
        }
    }

    public void Reset(){
        foreach (GameObject gameObject in list){
                animator = gameObject.GetComponent<Animator>();
                animator.SetBool(IS_ALL_TRIGGERED, false);
                animator.SetBool(IS_TRIGGERED, false);
            }
    }
}
