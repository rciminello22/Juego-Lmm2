using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GomitaBaniada : MonoBehaviour
{
    private Rigidbody2D rgb;

    private Animator animator;


    [Header("Liberacion")]
    
   
    [SerializeField] private float velocidad;

    [SerializeField] private bool moviendoIzquierda;


    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
        animator= GetComponent<Animator>();

    }

 

    private void OnCollisionEnter2D(Collision2D other) 
    {

        if(other.gameObject.CompareTag("Player"))
        {

            foreach(ContactPoint2D punto in other.contacts)
            {

                if(punto.normal.y <= -0.9)
                {
                    animator.SetTrigger("Golpe");
                    other.gameObject.GetComponent<MovimientoPersonaje>().Rebote();
                    Liberacion();
                }

            }

        }

    }


    public void Liberacion()
    {
        
        animator.SetTrigger("Liberar");
        moviendoIzquierda = !moviendoIzquierda;
        rgb.position = new Vector2(rgb.position.x, 0) * velocidad;
        
    }
}
