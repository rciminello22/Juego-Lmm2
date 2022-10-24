using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colsionadorBala : MonoBehaviour
{
  private AudioSource audioSource;

  [SerializeField] private float dano;

  private void Start() 
  {
    audioSource = GetComponent<AudioSource>();

  }

  private void OnTriggerEnter2D(Collider2D other) 
  {
    if(other.CompareTag("Player"))
    {
      other.GetComponent<movimientoPP>().TomarDano(dano);      
      Debug.Log("ColisionBala");
      Destroy(gameObject);
    }
  }

}
