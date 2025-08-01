using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class AmmoCollision : MonoBehaviour
{
    public float damage = 0.25f;
    void OnCollisionEnter(Collision collision)
    {
        Movement movement = collision.gameObject.GetComponent<Movement>();
        if (movement != null)
        {
            PhotonView targetPhotonView = movement.GetComponent<PhotonView>();
            if (targetPhotonView != null)
            {
                Player targetPlayer = targetPhotonView.Owner;
                targetPhotonView.RPC("TakeDamage", RpcTarget.AllBuffered, damage, targetPlayer);
            }
        }
        Destroy(gameObject);
    }
}
