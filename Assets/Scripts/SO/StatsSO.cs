using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;


[CreateAssetMenu(fileName = "StatsSO", menuName = "StatsSO", order = 0)]
public class StatsSO : ScriptableObject
{
    public float Health;
    public float Damage;
}


