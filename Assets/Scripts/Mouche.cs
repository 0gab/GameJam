using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouche : MonoBehaviour
{
    public Transform[] Points;

    int valeurAleatoire;

    /*
    [Range(5, 15)]
    public int tempsVarie;
    */

    public int valeurDelaiMin;
    public int valeurDelaiMax;
    private int valeurDelai;

    bool valeurModifieeEnCours;


    void Start()
    {
        // Appeler la fonction qui modifie la valeur de la destination al�atoirement
        ModifierValeurAleatoire();
    }

    void ModifierValeurAleatoire()
    {
        // Appliquer une valeur al�atoire entre 0 et 5
        valeurAleatoire = Random.Range(0, Points.Length);

        // La valeur ne se fait plus modifier
        valeurModifieeEnCours = false;
    }


    void Update()
    {
        // Donner un temps d'attente al�atoire entre 5 et 8s
        valeurDelai = Random.Range(valeurDelaiMin, valeurDelaiMax);

        // Pour chaque point de destination,
        for (int i = 0; i < Points.Length; i++)
        {
            // Si la position de la mouche est � la position de sa destination ET que la valeur al�atoire ne se fait pas modifier,
            if (transform.position == Points[i].position && !valeurModifieeEnCours)
            {
                // La valeur est en train de se faire modifier
                valeurModifieeEnCours = true;

                // Changer la valeur al�atoire
                Invoke("ModifierValeurAleatoire", valeurDelai);
            }
        }

        // Si la valeur al�atoire est paire,
        if (valeurAleatoire % 2 == 0)
        {
            // Orienter le sprite vers la gauche
            GetComponent<SpriteRenderer>().flipX = false;
        }

        // Sinon,
        else
        {
            //Orienter le sprite vers la droite
            GetComponent<SpriteRenderer>().flipX = true;
        }

        // Bouger la mouche en fonction de la direction demand�e
        transform.position = Vector3.MoveTowards(transform.position, Points[valeurAleatoire].position, 0.25f);
    }
}
