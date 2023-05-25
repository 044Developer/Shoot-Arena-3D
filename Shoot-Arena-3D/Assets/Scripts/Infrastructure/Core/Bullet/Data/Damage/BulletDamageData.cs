﻿using UnityEngine;

namespace ShootArena.Infrastructure.Core.Bullet.Data.Damage
{
    public class BulletDamageData : IBulletDamageData
    {
        public float BulletDamage { get; }
        public float BulletSpeed { get; }
        public Vector3 BulletDirection { get; }
        public float SpawnStartTime { get; }
        public float BulletLifeTime { get; }

        public BulletDamageData(float bulletDamage, Vector3 bulletDirection, float spawnStartTime, float bulletLifeTime, float bulletSpeed)
        {
            BulletDamage = bulletDamage;
            BulletDirection = bulletDirection;
            SpawnStartTime = spawnStartTime;
            BulletLifeTime = bulletLifeTime;
            BulletSpeed = bulletSpeed;
        }
    }
}