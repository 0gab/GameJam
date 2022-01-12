using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlerPersonnageGuillaume : MonoBehaviour
{
    public float vitesseX;      //vitesse en gauche et droite
    public float vitesseY;      //vitesse en haut et bas
    public float Vitesse;

    bool glisse;


    void Update()
    {
        /* D�tection des touches et modification de la vitesse de d�placement;
       "A" et "D" pour bouger horizontalement
       "W" et "S" pour bouger verticalement
        */

        vitesseY = Mathf.Round(Input.GetAxis("Vertical")) * Vitesse;
        vitesseX = Mathf.Round(Input.GetAxis("Horizontal")) * Vitesse;

        GetComponent<Rigidbody2D>().velocity = new Vector2(vitesseX, vitesseY);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Si le personnage entre en contact avec la mouche
        if (collision.gameObject.tag == "Mouche")
        {
            // Ins�rer ici tout ce qui est n�cessaire apr�s le contact de la mouche
            Debug.Log("hit");
        }

        // Si le personnage entre en contact avec une flaque,
        if (collision.gameObject.tag == "Flaque")
        {
            // Ex�cuter la fonction qui alt�re le mouvement du personnage
            StartCoroutine(EffetFlaque());
        }
    }

    IEnumerator EffetFlaque()
    {
        // Si le personnage ne glisse pas,
        if (!glisse)
        {
            // Faire glisser le personnage
            glisse = true;

            // Inverser la vitesse de d�placement
            Vitesse *= -1;

            // Attendre 5 secondes
            yield return new WaitForSeconds(5);

            // R�tablir la vitesse de d�placement
            Vitesse *= -1;

            // Faire r�tablir le personnage
            glisse = false;
        }
    }
}