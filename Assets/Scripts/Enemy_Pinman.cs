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

    public AudioSource hit;

    public bool active = false;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        playerAnimator = GameObject.FindGameObjectWithTag("cannonBody").GetComponent<Animator>();
        cannon_rollCol = GameObject.FindGameObjectWithTag("cannonRoll").GetComponent<Collider2D>();
        cannon_slapCol = GameObject.FindGameObjectWithTag("cannonSlap").GetComponent<Collider2D>();
        cannon_Body = GameObject.FindGameObjectWithTag("cannonBody").GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if(currentHealth <= 0 && !animator.GetBool("Dead")){
          ScoreScript.scoreValue += 500;
          animator.SetBool("Dead",true);
          Destroy(gameObject, 4f);
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

      if(other.CompareTag("dark"))
        active = false;
      else if(other.CompareTag("activate"))
        active = true;

      if(active == true){
        if(playerAnimator.GetBool("IsSlap")==true && pin_body.IsTouching(cannon_slapCol) && animator.GetBool("isHurt")==false){
          if(animator.GetBool("RollStun")==false)
            animator.SetBool("isHurt",true);
          TakeDamage(5);
        }
        else if(playerAnimator.GetBool("isRoll")==true && pin_body.IsTouching(cannon_rollCol) && animator.GetBool("RollStun")==false){
          TakeDamage(2);
          animator.SetBool("RollStun",true);
        }
      }

    }
    void playFall(){
      int num = Random.Range(0,1);

      if(num == 0)
        AudioScriptPinman.PlaySound("pinmanFall1");
      else
        AudioScriptPinman.PlaySound("pinmanFall2");
    }
    void playHit(){
      AudioScriptPinman.PlaySound("pinmanClap");
    }
    void playDie(){
      int num = Random.Range(0,3);

      Debug.Log(num);

      if(num == 0)
        AudioScriptPinman.PlaySound("pinmanDie1");
      else if(num == 1)
        AudioScriptPinman.PlaySound("pinmanDie2");
      else
        AudioScriptPinman.PlaySound("pinmanDie3");
    }
}
