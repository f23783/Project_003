using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Mathematics;
using Unity.Netcode;
using UnityEngine;

public class Attack : NetworkBehaviour
{
    public Rigidbody2D rb;
    public Vector2 halfExtents;
    public float damage;
    public float speed;
    public float rotation;
    public Vector2 attackV;
    [SerializeField]private LayerMask attackLayer;
    [HideInInspector]public Vector2 swordStartPos;
    [HideInInspector]private bool test = false;

    private void Start() {
        
    }
     private void Update()
    {
        transform.rotation = Quaternion.Euler(0,0,rotation);
        if (IsOwner && Input.GetKeyDown(KeyCode.Space))
        {
            Test(0);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject != IsOwner && other.gameObject.CompareTag("Player"))
        {
            var targetPlayer = other.gameObject.GetComponent<NetworkObject>();
            DamageManager.instance.DealDamageServerRpc(targetPlayer.OwnerClientId,damage);
        }
    }

    public IEnumerator enumerator()
    {
        test = true;
        yield return new WaitForSeconds(2);
        Debug.Log("Waited 2 Seconds");
        test = false;
    }
    public async void Test(int i)
    {
        test = true;
        while (i == 10)
        {
            transform.position = Vector2.Lerp(transform.position, attackV , speed * Time.deltaTime);
            Debug.Log("AA");
            i++;
        }
        await Task.Yield();
    }
}


