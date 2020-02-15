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
    float tempsMortSkill = 1.8f;
    float coolDownSkill = 0f;
    private bool canCast = false;

    void Update()
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b, tempsMortSkill*100/180);
        if(tempsMortSkill <= coolDownSkill)
        {
            canCast = true;
        }
        if (Input.GetMouseButton(1))
        {
            if (Input.GetMouseButton(0) && tempsMort >= tempsAttente)
            {
                shoot();
            }
            tempsMort++;
            if (Input.GetMouseButtonDown(2) && canCast)
            {
                skill();
            }
            
        }
        tempsMortSkill -= 0.01f;
    }

    public void shoot()
    {
        cannonParticleShooter.Play();
        tempsMort = 0;
    }

    public void skill()
    {
        megaAttack.Play();
        canCast = false;
        tempsMortSkill = 1.8f;
    }
}
