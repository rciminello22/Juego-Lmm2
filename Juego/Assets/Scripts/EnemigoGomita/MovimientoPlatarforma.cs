using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPlatarforma : MonoBehaviour
{
   [SerializeField] private float velocidad;

   [SerializeField] private Transform controladorPiso;

   [SerializeField] private float distancia;

   [SerializeField] private bool moviendoDerecha;

   private Rigidbody2D rb;

   public GameObject enemigo;

   public GameObject personaje;

    public float distanciaPP;

   private void Start()
    {
   
    rb = GetComponent<Rigidbody2D>();
  
    
    }

    private void FixedUpdate()
    {
        distanciaPP = Vector2.Distance(enemigo.transform.position, personaje.transform.position);

        RaycastHit2D informacionPiso = Physics2D.Raycast(controladorPiso.position, Vector2.down, distancia);

        rb.velocity = new Vector2(velocidad, rb.velocity.y);

        if(informacionPiso == false || distanciaPP > 5)
        {
            Girar(); 
        }
        Debug.Log(distanciaPP);
    
        if(distanciaPP < 5 )
        {
            Frenar();
        }

    }

    private void Girar()
    {

        moviendoDerecha = !moviendoDerecha;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y +180, 0);
        velocidad *= -1;

    }

  private void Frenar()
    {
      
        distancia = 0;
        velocidad = 0;
       
    }


    private void OnDrawGizmos() 
    {
        
        Gizmos.color= Color.red;
        Gizmos.DrawLine(controladorPiso.transform.position, controladorPiso.transform.position + Vector3.down);

    }

  
}
