using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pinMan_Clap : MonoBehaviour
{

    public Animator animator;
    public Collider2D clapCollider;

    void Start(){

      clapCollider.enabled = false;

    }
    // Update is called once per frame
    void Update()
    {

      if(animator.GetBool("isClap")==true){
        if(clapCollider.enabled == false)
          clapCollider.enabled = true;
      }

    }
}
