using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;
    public Animator animator;
    public HealthBar healthBar;
  
    public Collider2D cannonBody;
    public Collider2D cannon_slapCol;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
          TakeDamage(10);
    }

    public void TakeDamage(int damage){

      currentHealth -= damage;
      healthBar.SetHealth(currentHealth);

    }

    void fin_Hurt(){
      animator.SetBool("isHurt",false);
    }

    public void AddHealth(int health){

      currentHealth += health;
      healthBar.SetHealth(currentHealth);

    }

    private void OnTriggerEnter2D(Collider2D other){

      if(other.gameObject.tag == "pinClap" && animator.GetBool("isRoll")==false){
        if(animator.GetBool("isHurt")==false){
          animator.SetBool("isHurt",true);
        }
          TakeDamage(2);


      }

    }

}
