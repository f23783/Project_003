using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public enum Stances
{
    defence,balance,attack,fast
}

[Serializable]
public class StancesClass
{
    public string name;
    public List<Vector2> attackVectors = new List<Vector2>();
    public List<Vector3> attackRotation = new List<Vector3>();
    public float attackBaseDamage;
    public float attackSpeed;
    public float attackLength;
    public float attackWidth;
    public Vector2 stancesSwordStartPos;

}

public class AttackPaterns : NetworkBehaviour
{
    [SerializeField]private List<StancesClass> stancesList;
    [SerializeField]private InputManager inputManager;
    [SerializeField]private Attack attack;
    private Stances enumStances;

    private void Start() {
        inputManager = GetComponent<InputManager>();
        attack = GetComponentInChildren<Attack>();
        ChangeStance();
    }

    public void ChangeStance(int currentStance = 0)
    {
        if (IsOwner)
        {
            attack.halfExtents = new Vector2(stancesList[currentStance].attackLength,stancesList[currentStance].attackWidth);

            attack.damage = stancesList[currentStance].attackBaseDamage;

            attack.speed = stancesList[currentStance].attackSpeed;

            attack.rotation = stancesList[currentStance].attackRotation[0].z;
        }
    }
}
