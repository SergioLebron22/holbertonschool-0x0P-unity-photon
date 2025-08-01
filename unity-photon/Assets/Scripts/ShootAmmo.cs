using UnityEngine;
using Photon.Pun;

public class ShootAmmo : MonoBehaviour
{
    public GameObject ammo;
    private Rigidbody rb;
    public float shootForce = 1000f;
    public Camera playerCamera;
    private PhotonView photonView;

    void Awake()
    {
        photonView = GetComponent<PhotonView>();
    }
    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine && Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        float forwardOffset = 1.0f;
        Vector3 spawnPos = playerCamera.transform.position + playerCamera.transform.forward * forwardOffset;

        GameObject spawnedAmmo = Instantiate(ammo, spawnPos, playerCamera.transform.rotation);

        rb = spawnedAmmo.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(playerCamera.transform.forward * shootForce);
        }
    }
}
