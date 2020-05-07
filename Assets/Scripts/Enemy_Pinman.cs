using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Pinman : MonoBehaviour
{

    public int maxHealth = 25;
    public int currentHealth;
    public Animator animator;
    public Animator playerAnimator;
    public HealthBar healthBar;

    public Collider2D pin_body;
    public Collider2D pin_clapCol;
    public Collider2D cannon_rollCol;
    public Collider2D cannon_slapCol;
    public Collider2D cannon_Body;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {

        if(currentHealth <= 0){
          animator.SetBool("Dead",true);
          healthBar.enabled = false;
        }

    }

    void TakeDamage(int damage){

      currentHealth -= damage;
      healthBar.SetHealth(currentHealth);

    }

    void AddHealth(int health){

      currentHealth += health;
      healthBar.SetHealth(currentHealth);

    }
    void fin_RollStun(){

      animator.SetBool("RollStun",false);

    }

    void test(){
      
    }
    void fin_Hurt(){
        animator.SetBool("isHurt",false);
    }

    public Collider2D getBody(){
      return pin_body;
    }
    public Collider2D getClap(){
      return pin_clapCol;
    }
    private void OnTriggerEnter2D(Collider2D other){

      if(playerAnimator.GetBool("IsSlap")==true && pin_body.IsTouching(cannon_slapCol) && animator.GetBool("isHurt")==false){
        if(animator.GetBool("RollStun")==false)
          animator.SetBool("isHurt",true);
        TakeDamage(5);


        /*if(pin_body.IsTouching(cannon_Body))
          AddHealth(5);*/
      }
      else if(playerAnimator.GetBool("isRoll")==true && pin_body.IsTouching(cannon_rollCol) && animator.GetBool("RollStun")==false){
        TakeDamage(2);
        animator.SetBool("RollStun",true);
      }

    }
}
