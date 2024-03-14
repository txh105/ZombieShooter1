using BigRookGames.Weapons;
using UnityEngine;

public class GunAmmo : MonoBehaviour
{
    public int magSize;
    public GunfireController gun;
    private int _loadedAmmo;
    public int LoadedAmmo
    {
        get => _loadedAmmo;
        set
        {
            _loadedAmmo = value;
            if (_loadedAmmo <= 0)
            {
                Reload();
            }
            else
            {
                UnlockShotting();
            }
        }
    }
    private void Start() => RefillAmmo();
    public void SingleFireAmmoCounter() => LoadedAmmo--;
    private void LockShotting() => gun.enabled = false;
    private void UnlockShotting() => gun.enabled = true;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }
    private void Reload()
    {
        LockShotting();
    }
    public void AddAmmo() => RefillAmmo();
    private void RefillAmmo() => LoadedAmmo = magSize;
}
