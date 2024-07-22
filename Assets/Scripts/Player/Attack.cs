using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.Netcode;
using UnityEngine;

public class Attack : NetworkBehaviour
{

    public Vector2 halfExtents;
    [HideInInspector]public float damage;
    [HideInInspector]public float speed;
    [SerializeField]private LayerMask attackLayer;
    [HideInInspector]public Vector2 swordStartPos;

     private void Update()
    {
        if (IsOwner && Input.GetKeyDown(KeyCode.Space))
        {
           // ApplyDamage();
            Debug.Log("AA");
        }
    }
    //Obje yeterince uzunsa diresel bir yörünge izlemesine gerek yok kendine hasar uygulayamaz bu yüzden sadece aşağı doğru bir haraket başalatmak oldukça mantıklı


   /* public void ApplyDamage()
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
    }*/

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject != IsOwner && other.gameObject.CompareTag("Player"))
        {
            var targetPlayer = other.gameObject.GetComponent<NetworkObject>();
            DamageManager.instance.DealDamageServerRpc(targetPlayer.OwnerClientId,damage);
        }
    }
}


