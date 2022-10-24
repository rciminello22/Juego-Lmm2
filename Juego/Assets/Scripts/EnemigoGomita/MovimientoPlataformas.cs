using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPlataformas : MonoBehaviour
{
   [SerializeField] private float velocidad;

   [SerializeField] private Transform controladorPiso;

   [SerializeField] private float distancia;

   [SerializeField] private bool moviendoDerecha;

    private Rigidbody2D rb;

    private void Start()
    {
        
        rb =  GetComponent<Rigidbody2D>();

    }

    private void FixedUpdate() 
    {

        RaycastHit2D informacionPiso = Physics2D.Raycast(controladorPiso.position, Vector2.down,distancia);

        rb.velocity = new Vector2( velocidad, rb.velocity.y);

        if(informacionPiso == false) 
        {
            Girar();
        }  
    }

    private void Girar()
    {

        moviendoDerecha = !moviendoDerecha;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        velocidad *= -1;
    }

}
