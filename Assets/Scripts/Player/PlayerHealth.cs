using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerHealth : NetworkBehaviour
{
    [SerializeField]private StatsSO statsSO;
    [SerializeField]private NetworkVariable<float> health = new NetworkVariable<float>();


    private void Start() {
        health.Value = statsSO.Health;
    }

    public void TakeDamage(float damage)
    {
        if (IsServer)
        {
            health.Value -= damage;
        }
    }

}
