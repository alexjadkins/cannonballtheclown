using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

  public Collider2D slapCollider;
  public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        slapCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

      if(animator.GetBool("IsSlap")==true){
        if(slapCollider.enabled == false)
          slapCollider.enabled = true;

      }

      if(animator.GetBool("IsSlap")==false)
        slapCollider.enabled = false;

    }
}
