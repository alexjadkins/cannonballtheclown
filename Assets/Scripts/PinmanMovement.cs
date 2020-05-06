﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinmanMovement : MonoBehaviour
{

    public float speed;
    private Transform target;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {


      if(animator.GetBool("Dead")==false && animator.GetBool("RollStun")==false && animator.GetBool("isHurt")==false){

        animator.SetFloat("Horizontal", transform.position.x);
        animator.SetFloat("Vertical", transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

      }
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