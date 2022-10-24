using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
   void OnTriggerEnter2D(Collider2D col){

        if(col.CompareTag("Player")){
            col.GetComponent<ReaparecePersonaje>().CheckPointReached(transform.position.x, transform.position.y);
        }

    }
}
