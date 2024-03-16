using UnityEngine;
using UnityEngine.Events;

public class AutomaticShooting : MonoBehaviour
{
    public int rpm;
    private float lastShot;
    private float interval;
    public GameObject hitMarkerPrefab;
    public Camera aimingCamera;
    public LayerMask layerMask;
    public UnityEvent onShoot;
    private void Start() => interval = 60f / rpm;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            UpdateFiring();

        }
    }
    private void UpdateFiring()
    {
        if (Time.time - lastShot >= interval)
        {
            Shoot();
            lastShot = Time.time;
        }
    }
    private void Shoot()
    {
        PerformRaycasting();
        onShoot.Invoke();
    }
    private void PerformRaycasting()
    {
        Ray aimingRay = new Ray(aimingCamera.transform.position, aimingCamera.transform.forward);
        if (Physics.Raycast(aimingRay, out RaycastHit hitInfo, 1000f, layerMask))
        {
            Quaternion effectRotation = Quaternion.LookRotation(hitInfo.normal);
            Instantiate(hitMarkerPrefab, hitInfo.point, effectRotation);
        }
    }
}