using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    ParticleSystem cannonParticleShooter;
    [SerializeField]
    ParticleSystem megaAttack;
    [SerializeField]
    UnityEngine.UI.Image image;
    int tempsMort = 0;
    int tempsAttente = 8;
    int tempsMortSkill = 180;
    int coolDownSkill = 0;

    void Update()
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b, (tempsMortSkill*100)/180);
        if (Input.GetMouseButton(1))
        {
            if (Input.GetMouseButton(0) && tempsMort >= tempsAttente)
            {
                shoot();
                tempsMort = 0;
            }
            tempsMort++;
            if (Input.GetMouseButtonDown(2) && tempsMortSkill <= coolDownSkill)
            {
                skill();
                tempsMortSkill = 180;
            }
            tempsMortSkill--;
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
