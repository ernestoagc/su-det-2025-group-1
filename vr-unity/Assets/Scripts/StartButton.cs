using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
   private Material defaultColor;
   private Renderer renderer;
   public Material hoverColor;

   // Start is called before the first frame update
   void Start()
   {
      renderer = this.gameObject.GetComponent<Renderer>();
      defaultColor = renderer.material;
   }

   // Update is called once per frame
   void Update()
   {

   }

   public void Hover()
   {
      renderer.material = hoverColor;
   }

   public void Unhover()
   {
      renderer.material = hoverColor;
   }
}
