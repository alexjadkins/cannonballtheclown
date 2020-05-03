using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{

    public Animator animator;
    float lastX, lastY;

    // Update is called once per frame
    void Update()
    {

      //Checks if rolling or slapping, otherwise move goes as normal
      if(!animator.GetBool("isRoll") && !animator.GetBool("IsSlap"))
        Move();

      //Case: slap, you can move and slap at same time
      else if(!animator.GetBool("isRoll") && animator.GetBool("IsSlap")){
        Slap();
        Move();
      }
      //case: roll, you can move and roll at same time but moving while rolling is handing in roll function
      else if(animator.GetBool("isRoll"))
        Roll();

      //if the user hits shift, isRoll is set to true, triggering the roll blend tree
      if(animator.GetBool("isRoll")==false && Input.GetKeyDown(KeyCode.Space))
        animator.SetBool("isRoll", true);

      //if the user hits e, IsSlap is set to true, triggering the slap blend tree, uses .GetKeyDown to prevent holding
      //down e to continously slap
      else if(animator.GetBool("isRoll")==false && Input.GetKeyDown(KeyCode.RightShift))
        animator.SetBool("IsSlap",true);

    }



    //Movement function, if the keys are let go then the last horizontal and vertical values are stored so the
    //idle blend tree can play the correct directional idle animation
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

      else if(!Input.GetKey(KeyCode.RightShift)){
        lastX = movement.x;
        lastY = movement.y;
        animator.SetBool("Movement", true);
      }


  }

    void Roll(){

      //if rolling animation has finished, isRoll is set to false so animation returns to the running blend tree
      if(animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !animator.IsInTransition(0))
        animator.SetBool("isRoll",false);

      //Otherwise the rolling animation is still playing, so the movement is taking from directional Input
      //if no directional input is put in, then the player still moves in the last direction used until animation is over
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

    //Once slap animation is finished, isSlap is set to false, returning back to either the running blend tree or idle blend tree
    void Slap(){
      if(animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !animator.IsInTransition(0))
        animator.SetBool("IsSlap",false);

    }
}
