using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Pinman : MonoBehaviour
{

    public int maxHealth = 25;
    public int currentHealth;
    public Animator animator;
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

        if(currentHealth <= 0)
          animator.SetTrigger("Dead");
    }

    void TakeDamage(int damage){

      currentHealth -= damage;
      healthBar.SetHealth(currentHealth);

    }

    private void OnTriggerEnter2D(Collider2D other){
      TakeDamage(5);
      animator.SetTrigger("hurtTrig");

    }
}
