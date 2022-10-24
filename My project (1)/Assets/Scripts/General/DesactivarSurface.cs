using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivarSurface : MonoBehaviour
{
  public GameObject objetoActivadoyDesactivado;

  public SurfaceEffector2D mancha;

    
    private void Start() {
    

    }

    private void Update() {
        
        if(Input.GetButtonUp("Horizontal") || Input.GetButtonUp("Vertical"))
        {

            Debug.Log("Desactivar");
            mancha.enabled = false;

        }

    }
  
}
