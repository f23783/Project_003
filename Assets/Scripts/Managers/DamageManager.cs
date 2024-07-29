using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class DamageManager : NetworkBehaviour
{
    public static DamageManager instance;

   private void Awake()
{
    if (instance != null && instance != this)
    {
        Destroy(gameObject);
    }
    else
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
        Debug.Log("DamageManager singleton instance oluşturuldu.");
    }
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

    [ServerRpc(RequireOwnership = false)]
    public void DealDamageServerRpc(ulong targetClientId, float damage)
    {
        Debug.Log(targetClientId);
        DealDamage(targetClientId, damage);
    }
}
