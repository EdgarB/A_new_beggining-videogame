using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sceneManager : MonoBehaviour {

    public Text txtGemas;
    public GameObject portalSalida;
    public GameObject[] bloquesPortal;
    public bool gemTextEnabled = true;
    static public int iGemasRecolectadas;
    

    private int iCantGemasEscena;
	// Use this for initialization
	void Start () {
        iGemasRecolectadas = 0;
        GameObject[] arr;
        arr =  GameObject.FindGameObjectsWithTag("gem");
        iCantGemasEscena = arr.Length;
        if (gemTextEnabled)
        {
            txtGemas.text = "0 of " + iCantGemasEscena + " gems collected";
        }
        
    }
	
	

    public void recolectarGema()
    {
        iGemasRecolectadas += 1;
        if (gemTextEnabled)
        {
            txtGemas.text = iGemasRecolectadas + " of " + iCantGemasEscena + " gems collected";
        }
       
        if(iGemasRecolectadas >= iCantGemasEscena)
        {
            aparecerPortalSalida();
        }
    }

    public void aparecerPortalSalida()
    {
        portalSalida.gameObject.SetActive(true);
        portalSalida.GetComponent<Animator>().SetTrigger("Aparecer");
        
        foreach (GameObject bloque in bloquesPortal)
        {
            bloque.GetComponent<Animator>().SetTrigger("Desaparecer");
            Destroy(bloque, 5.0f);
        }
        

       Debug.Log("Aparecete!!!") ;
    }

    
}
