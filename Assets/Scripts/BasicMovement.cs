using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{

    public Animator animator;
  //  public float moveSpeed = 4f;
    float lastX, lastY;
    //float rollLeft;
    // Update is called once per frame

    void Update()
    {
      if(animator.GetBool("isRoll")==false && Input.GetKeyDown(KeyCode.LeftShift))
        animator.SetBool("isRoll", true);

      if(!animator.GetBool("isRoll"))
        Move();
      else
        Roll();

    }



    void Move(){

      Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);

      animator.SetFloat("Horizontal", movement.x);
      animator.SetFloat("Vertical", movement.y);
      animator.SetFloat("Magnitude", movement.magnitude);

      transform.position += movement * Time.deltaTime;

      if(!Input.anyKey){
        animator.SetFloat("LastHorz", lastX);
        animator.SetFloat("LastVert", lastY);
        animator.SetBool("Movement",false);
      }

      else if((movement.x <= 1f || movement.x >= -1f) && (movement.y <= 1f || movement.y >= -1f)){
        lastX = movement.x;
        lastY = movement.y;
        animator.SetBool("Movement", true);
      }

    }

    void Roll(){



      if(animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !animator.IsInTransition(0)){
        animator.SetBool("isRoll",false);
      }

      else{
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);

        if(animator.GetFloat("Horizontal") > 0 && animator.GetFloat("Vertical") > 0){
          movement.x += .5f;
          movement.y += .5f;
        }
        else if(animator.GetFloat("Horizontal") > 0 && animator.GetFloat("Vertical") == 0)
          movement.x += .5f;

        else if(animator.GetFloat("Horizontal") > 0 && animator.GetFloat("Vertical") < 0){
          movement.x += .5f;
          movement.y -= .5f;
        }
        else if(animator.GetFloat("Horizontal") < 0 && animator.GetFloat("Vertical") > 0){
          movement.x -= .5f;
          movement.y += .5f;
        }

        else if(animator.GetFloat("Horizontal") < 0 && animator.GetFloat("Vertical") == 0)
          movement.x -= .5f;

        else if(animator.GetFloat("Horizontal") < 0 && animator.GetFloat("Vertical") < 0){
          movement.x -= .5f;
          movement.y -= .5f;
        }
        else if(animator.GetFloat("Horizontal") == 0 && animator.GetFloat("Vertical") < 0)
          movement.y -= .5f;
        else if(animator.GetFloat("Horizontal") == 0 && animator.GetFloat("Vertical") > 0){
          movement.y += .5f;
        }

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Magnitude", movement.magnitude);

        transform.position += movement * Time.deltaTime;

      }
    }
}
