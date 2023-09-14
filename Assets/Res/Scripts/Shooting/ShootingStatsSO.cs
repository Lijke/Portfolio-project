using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ShootingStatsSO", menuName = "ScriptableObjects/ShootingStatsSO")]
public class ShootingStatsSO : ScriptableObject{
    public int bulletDamage;
    public ParticleSystem particleShoot;
}
