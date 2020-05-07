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
    void AddHealth(int health){

      currentHealth += health;
      healthBar.SetHealth(currentHealth);

    }

    /*private void OnTriggerEnter2D(Collider2D other){

      Debug.Log("Collide");
      if(other.gameObject.tag == "pinMan" && animator.GetBool("isRoll")==false){
        if(cannonBody.IsTouching(other.gameObject.GetComponent<Enemy_Pinman>().getBody()))
          TakeDamage(5);

      }

    }*/

}
