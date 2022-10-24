using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionadorPerder : MonoBehaviour
{
  
  private void OnCollisionEnter2D(Collision2D collision) 
  {
    if(collision.transform.CompareTag("Player"))
    {
        Debug.Log("ColisionPerder");
       //Destroy(collision.gameObject);
    }
  }
}
