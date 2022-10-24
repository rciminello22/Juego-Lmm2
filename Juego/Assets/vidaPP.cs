using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class vidaPP : MonoBehaviour
{
    private float vida;

   private TextMeshProUGUI textMesh;

   private void Start()
   {
    textMesh = GetComponent<TextMeshProUGUI>();
   }

    private void Update() 
    {
        textMesh.text = vida.ToString("5");
    }

    public void ColisionoLaBala(float colisionBala)
    {
        vida -= colisionBala;
    }

}
