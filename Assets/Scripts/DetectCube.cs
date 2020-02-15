using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DetectCube : MonoBehaviour
{
    [SerializeField]
    private BoxCollider colliderPod;
    private List<GameObject> objetsDansCollider;
    private Transform target;
    [SerializeField]
    private TurnAround enRotation;
    private int tempsMort = 0;
    private int tempsAttente = 12;
    [SerializeField]
    private Shoot shoot;

    private void Start()
    {
        objetsDansCollider = new List<GameObject>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "ennemi")
        {
            objetsDansCollider.Add(other.gameObject);
            Debug.Log("Ajout d'un ennemi !");
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "ennemi")
        {
            objetsDansCollider.Remove(other.gameObject);
            transform.LookAt(new Vector3(transform.position.x + 5, transform.position.y, transform.position.z));
            Debug.Log("Suppression d'un ennemi !");
        }
    }

    private void Update()
    {
        if (objetsDansCollider.Any())
        {
            float distanceMin = -1;
            foreach (GameObject game in objetsDansCollider)
            {
                if(distanceMin < 0 || distanceMin > Vector3.Distance(game.transform.position, transform.position))
                {
                    distanceMin = Vector3.Distance(game.transform.position, transform.position);
                    target = game.transform;
                }
            }
        }
        else
        {
            target = null;
        }

        if(target != null)
        {
            transform.LookAt(target);
            enRotation.enabled = false;
            if (!Input.GetMouseButton(0) && tempsMort >= tempsAttente)
            {
                shoot.shoot();
                tempsMort = 0;
            }
            tempsMort++;
        }
        else
        {
            enRotation.enabled = true;
        }
    }
}
