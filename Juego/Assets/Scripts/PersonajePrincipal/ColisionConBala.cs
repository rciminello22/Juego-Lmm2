using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionConBala : MonoBehaviour
{

[SerializeField] private int vida;

public void TomarDano(int cantidadDano)
{

vida -= cantidadDano;
if(vida <= 0)
{
    Destroy(gameObject);
}
}

}
