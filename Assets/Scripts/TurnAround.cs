using UnityEngine;

public class TurnAround : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    void Update()
    {
        transform.RotateAround(target.position, Vector3.up, -30 * Time.deltaTime);
    }
}
