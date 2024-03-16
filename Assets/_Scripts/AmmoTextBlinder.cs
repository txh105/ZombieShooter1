using UnityEngine;
using UnityEngine.UI;

public class AmmoTextBlinder : MonoBehaviour
{
    public Text loadedAmmoText;
    public GunAmmo gunAmmo;
    private void Start()
    {
        gunAmmo.loadAmmoChanged.AddListener(UpdateGunAmmo);
    }
    public void UpdateGunAmmo() => loadedAmmoText.text = gunAmmo.LoadedAmmo.ToString();
}
