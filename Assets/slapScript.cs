using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slapScript : MonoBehaviour
{


    public GameObject player;
    //public Transform transform;

    void Update(){
      transform.position = player.GetComponent<Transform>().position;
    }
}
