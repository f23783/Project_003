using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerHealth : NetworkBehaviour
{
    [SerializeField]private StatsSO statsSO;
    [SerializeField]private NetworkVariable<float> health = new NetworkVariable<float>(0,NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Server);

    private void Start() {
        health.Value = statsSO.Health;
    }

    public void TakeDamage(float damage)
    {
        health.Value -= damage;
    }

}
