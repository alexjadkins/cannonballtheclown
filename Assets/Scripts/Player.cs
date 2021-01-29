using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if(currentHealth <= 0){
          StartCoroutine("LoseDelay");
        }
    }

    IEnumerator LoseDelay(){

      yield return new WaitForSeconds(1.5f);
      SceneManager.LoadScene("Lose");

    }
    //remeber that for some reason the player will take damage*4
    public void TakeDamage(int damage){

      if(!bossFunc.isDead){
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
      }
    }

    void fin_Hurt(){
      animator.SetBool("isHurt",false);
    }

    public void AddHealth(int health){

      if(currentHealth+health > maxHealth)
        currentHealth = maxHealth;
      else
        currentHealth += health;

      healthBar.SetHealth(currentHealth);

    }

    private void OnTriggerEnter2D(Collider2D other){

      if(other.CompareTag("hUp")){
        AddHealth(25);
        playerAudioScript.PlaySound("healthUp");
        Destroy(other.gameObject);
      }

      else if(other.gameObject.tag == "pinClap" && animator.GetBool("isRoll")==false){
        if(animator.GetBool("isHurt")==false){
          animator.SetBool("isHurt",true);
        }
          TakeDamage(2);

      }

      else if(other.gameObject.tag == "acrobatKick" && animator.GetBool("isRoll")==false){
        if(animator.GetBool("isHurt")==false){
          animator.SetBool("isHurt",true);
        }
          TakeDamage(3);

      }
      else if(other.CompareTag("ball") && animator.GetBool("isRoll")==false){
        if(animator.GetBool("isHurt")==false){
          animator.SetBool("isHurt",true);
        }
        TakeDamage(5);
        Destroy(other.gameObject);
      }
      else if(other.CompareTag("whip") && animator.GetBool("isRoll")==false){
        if(animator.GetBool("isHurt")==false){
          animator.SetBool("isHurt",true);
        }
        TakeDamage(15);
      }
    }
    void playHurt(){
      playerAudioScript.PlaySound("cannonHit");
    }
    void playSlap(){
      playerAudioScript.PlaySound("cannonSlap");
    }
}
