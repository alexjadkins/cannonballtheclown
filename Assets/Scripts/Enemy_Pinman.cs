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

    void fin_RollStun(){

      animator.SetBool("RollStun",false);

    }

    void fin_Hurt(){
        animator.SetBool("isHurt",false);
    }

    private void OnTriggerEnter2D(Collider2D other){

      if(playerAnimator.GetBool("IsSlap")==true){
        if(animator.GetBool("RollStun")==false)
          animator.SetBool("isHurt",true);
        TakeDamage(5);
      }
      else if(playerAnimator.GetBool("isRoll")==true){
        TakeDamage(2);
        animator.SetBool("RollStun",true);
      }
    }
}
