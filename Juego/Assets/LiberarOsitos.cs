using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LiberarOsitos : MonoBehaviour
{
   private float ososLibres;

   private TextMeshProUGUI textMesh;

   private void Start()
   {
    textMesh = GetComponent<TextMeshProUGUI>();
   }

    private void Update() 
    {
        textMesh.text = ososLibres.ToString("0");
    }

    public void LiberarOso(float puntosEntrada)
    {
        ososLibres += puntosEntrada;
    }

}
