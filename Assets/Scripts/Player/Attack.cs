using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.Netcode;
using UnityEngine;

public class Attack : NetworkBehaviour
{
    public Vector2 halfExtents = new Vector2(2, 3);
    [SerializeField]private float damage;
    [SerializeField]private LayerMask attackLayer;


     private void Update()
    {
        if (IsOwner && Input.GetKeyDown(KeyCode.Space))
        {
            ApplyDamage();
            Debug.Log("AA");
        }
    }

    public void ApplyDamage()
    {
        Debug.Log("Apply Damage Test");
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, halfExtents, 0f, attackLayer);
        foreach (var item in colliders)
        {
            var targetPlayer = item.gameObject.GetComponent<NetworkObject>();
            DamageManager.instance.DealDamageServerRpc(targetPlayer.OwnerClientId,damage);
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, halfExtents);
    }
}


