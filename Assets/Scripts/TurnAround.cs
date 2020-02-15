using UnityEngine;

public class TurnAround : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    private Vector3 origine;
    [SerializeField]
    private Transform aim;
    [SerializeField]
    private GameObject panel;
    [SerializeField]
    Cinemachine.CinemachineFreeLook camera;

    private void Start()
    {
        origine = new Vector3(0.8161659f, 2.007817f, 0.02263665f);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            camera.m_Lens.FieldOfView -= 10;
        }
        if (Input.GetMouseButtonUp(1))
        {
            camera.m_Lens.FieldOfView += 10;
        }
        if (!Input.GetMouseButton(1))
        {
            panel.SetActive(false);
            transform.RotateAround(target.position, Vector3.up, -30 * Time.deltaTime);
        }
        else
        {
            panel.SetActive(true);
            transform.localPosition = Vector3.Lerp(origine, transform.position, Time.deltaTime/10000);
            transform.LookAt(aim);
        }
    }
}
