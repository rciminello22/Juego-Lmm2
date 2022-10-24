using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaColision : MonoBehaviour
{

  [SerializeField] private float leDio;

  [SerializeField] private vidaPP vida;

  private void OnTriggerEnter2D(Collider2D other) 
  {
    if(other.transform.CompareTag("Player"))
    {
      vida.ColisionoLaBala(leDio);
      Debug.Log("BalaColision");
      Destroy(other.gameObject);
    }
  }
}
