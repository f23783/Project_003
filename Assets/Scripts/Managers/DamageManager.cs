using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class DamageManager : NetworkBehaviour
{
    public static DamageManager instance;

    private void Awake() {
        instance = this;
    }

    public void DealDamage(ulong targetClientId, float damage)
    {
        if (IsServer)
        {
            var targetPlayer = NetworkManager.Singleton.ConnectedClients[targetClientId].PlayerObject;
            var playerHealth = targetPlayer.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }
    }

    [ServerRpc]
    public void DealDamageServerRpc(ulong targetClientId, float damage)
    {
        DealDamage(targetClientId, damage);
    }
}
