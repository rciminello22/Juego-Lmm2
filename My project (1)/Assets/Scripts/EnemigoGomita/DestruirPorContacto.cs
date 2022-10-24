using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestruirPorContacto : MonoBehaviour
{
   [SerializeField] private GameObject efecto;

   [SerializeField] private float libreInicial = 0;

  [SerializeField] private float ososLibres = 1;

   [SerializeField] private BarraDeVida barraDeVida;

    private void Start() 
    {
        
    barraDeVida.InicializarBarraVida(libreInicial);

    
    }

  private void OnTriggerEnter2D(Collider2D other)   
    {
        if (other.CompareTag("Player"))
        {
           libreInicial += ososLibres;
            barraDeVida.CambiarVidaActual(libreInicial);
            Instantiate(efecto, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

}
   


