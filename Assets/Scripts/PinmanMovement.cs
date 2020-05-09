using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinmanMovement : MonoBehaviour
{

    public float speed;
    private Transform target;
    public Animator animator;
    public Collider2D clapCollider;
    public float attackDelayNum;
    private bool wait;
    private bool hasStarted;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        wait = false;
        hasStarted = false;
    }

    // Update is called once per frame
    void Update()
    {

      if(wait == true && hasStarted == false)
        StartCoroutine("AttackDelay");


      if(animator.GetBool("Dead")==false && animator.GetBool("RollStun")==false && animator.GetBool("isHurt")==false){

        animator.SetFloat("Horizontal", transform.position.x);
        animator.SetFloat("Vertical", transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, target.position)<.25 && animator.GetBool("RollStun")==false && animator.GetBool("Dead")==false && wait == false){
          animator.SetBool("isClap",true);
          clapCollider.enabled = true; 
        }
      }


    }

    void fin_Clap(){
        animator.SetBool("isClap",false);
        clapCollider.enabled = false;
        wait = true;
    }

    IEnumerator AttackDelay(){

      hasStarted = true;
      yield return new WaitForSeconds(attackDelayNum);
      wait = false;
      hasStarted = false;

    }

    void moveInDirection(){

      float moveX = 0;
      float moveY = 0;
      if(animator.GetFloat("Horizontal") > 0 && animator.GetFloat("Vertical") > 0){
        moveX -= .01f;
        moveY -= .01f;
      }
      else if(animator.GetFloat("Horizontal") > 0 && animator.GetFloat("Vertical") == 0)
        moveX -= .01f;

      else if(animator.GetFloat("Horizontal") > 0 && animator.GetFloat("Vertical") < 0){
        moveX -= .01f;
        moveY += .01f;
      }
      else if(animator.GetFloat("Horizontal") < 0 && animator.GetFloat("Vertical") > 0){
        moveX += .01f;
        moveY -= .01f;
      }

      else if(animator.GetFloat("Horizontal") < 0 && animator.GetFloat("Vertical") == 0)
        moveX += .01f;

      else if(animator.GetFloat("Horizontal") < 0 && animator.GetFloat("Vertical") < 0){
        moveX += .01f;
        moveY += .01f;
      }
      else if(animator.GetFloat("Horizontal") == 0 && animator.GetFloat("Vertical") < 0)
        moveY += .01f;
      else if(animator.GetFloat("Horizontal") == 0 && animator.GetFloat("Vertical") > 0){
        moveY -= .01f;
      }

      Vector3 temp = new Vector3(moveX,moveY,0);
      transform.position += temp;
      animator.SetFloat("Horizontal", transform.position.x);
      animator.SetFloat("Vertical", transform.position.y);


    }


}
