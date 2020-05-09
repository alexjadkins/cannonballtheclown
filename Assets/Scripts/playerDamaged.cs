using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDamaged : MonoBehaviour
{

  void Start(){

    GetComponent<BoxCollider2D>().enabled = true;

  }

  void Update(){

        Debug.Log(GetComponent<BoxCollider2D>().enabled);
  }
    private void OnTriggerEnter2D(Collider2D other){

      //Debug.Log(other.gameObject.tag);
      if(other.gameObject.tag == "pinClap"){

        GetComponent<Player>().TakeDamage(5);

      }

    }
}
