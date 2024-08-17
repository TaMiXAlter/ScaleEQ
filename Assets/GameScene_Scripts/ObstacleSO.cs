using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ObstacleSO : ScriptableObject
{
    public GameObject Obstacle;
    public int Damage;
    [SerializeField] public bool hasSpawned { get; set; }



}
