using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

  public Collider2D slapCollider;
  public Collider2D rollCollider;
  public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        slapCollider.enabled = false;
        rollCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

      if(animator.GetBool("IsSlap")==true){
        if(slapCollider.enabled == false)
          slapCollider.enabled = true;

      }

      if(animator.GetBool("isRoll")==true){
        if(rollCollider.enabled == false)
          rollCollider.enabled = true;

      }

      if(animator.GetBool("IsSlap")==false && animator.GetBool("isRoll")==false){
        slapCollider.enabled = false;
        rollCollider.enabled = false;
      }

    }

    void turnOnSlapCollider(){

      slapCollider.enabled = true;

    }

    void turnOffSlapCollider(){

      slapCollider.enabled = false;

    }

    void turnOnRollCollider(){

      rollCollider.enabled = true;

    }

    void turnOffRollCollider(){

      rollCollider.enabled = false;

    }
}
