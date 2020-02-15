using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    ParticleSystem cannonParticleShooter;
    [SerializeField]
    ParticleSystem megaAttack;
    int tempsMort = 0;
    int tempsAttente = 8;
    int tempsMortSkill = 0;
    int coolDownSkill = 180;

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            if (Input.GetMouseButton(0) && tempsMort >= tempsAttente)
            {
                shoot();
                tempsMort = 0;
            }
            tempsMort++;
            if (Input.GetMouseButtonDown(2) && tempsMortSkill >= coolDownSkill)
            {
                skill();
                tempsMortSkill = 0;
            }
            tempsMortSkill++;
        }
    }

    public void shoot()
    {
        cannonParticleShooter.Play();
    }

    public void skill()
    {
        megaAttack.Play();
    }
}
