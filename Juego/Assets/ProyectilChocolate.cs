using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilChocolate : MonoBehaviour
{
   public float Velocidad = 3.0f;
   

    void Update()
    {
        transform.position += transform.right * Time.deltaTime * Velocidad;
    }

    private void OnCollisionEnter2D(Collision2D collision) {

       /* var personaje = collisiom.collider.GetComponent<VidaPersonaje>();
        if(personaje)
        {
            personaje.TakeHit(1);
        }*/
        Destroy(gameObject);
    }
}
