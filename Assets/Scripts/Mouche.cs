using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouche : MonoBehaviour
{
    public Transform[] Points;

    int valeurAleatoire;


    void Start()
    {
        // Appeler la fonction qui modifie la valeur de la destination al�atoirement
        ModifierValeurAleatoire();
    }

    void ModifierValeurAleatoire()
    {
        // Appliquer une valeur al�atoire entre 0 et 5
        valeurAleatoire = Random.Range(0, Points.Length);
    }


    void Update()
    {
        // Pour chaque point de destination,
        for (int i = 0; i < Points.Length; i++)
        {
            // Si la position de la mouche est � la position de sa destination,
            if (transform.position == Points[i].position)
            {
                // Changer la valeur al�atoire
                ModifierValeurAleatoire();
            }
        }

        // Bouger la mouche en fonction de la direction demand�e
        transform.position = Vector3.MoveTowards(transform.position, Points[valeurAleatoire].position, 0.05f);
    }
}
