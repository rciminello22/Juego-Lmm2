using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReaparecePersonaje : MonoBehaviour
{
   private float CheckPointPositionX, CheckPointPositionY;

    public void CheckPointReached(float x, float y){

        PlayerPrefs.SetFloat("CheckPointPositionX", x);
        PlayerPrefs.SetFloat("CheckPointPositionY", y);
    }

    private void OnTriggerEnter2D(Collider2D col){

        if(col.gameObject.CompareTag("Chocolate")){
            Invoke ("RespawnPlayer", 1.0f);
        }
    }

    private void RespawnPlayer(){
        transform.position = (new Vector2 (PlayerPrefs.GetFloat("CheckPointPositionX"), PlayerPrefs.GetFloat("CheckPointPositionY")));
    }
}
