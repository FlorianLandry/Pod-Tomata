using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    ParticleSystem cannonParticleShooter;
    int tempsMort = 0;
    int tempsAttente = 8;

    void Update()
    {
        if (Input.GetMouseButton(0) && tempsMort >= tempsAttente)
        {
            shoot();
            tempsMort = 0;
        }
        tempsMort++;
    }

    public void shoot()
    {
        cannonParticleShooter.Play();
    }
}
