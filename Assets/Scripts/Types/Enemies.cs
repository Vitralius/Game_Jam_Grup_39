using Types;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Enemies
{
    public struct EnemyType
    {
        public DamageType damageType;
        public float factor;
        public Attributes attributes;
        public EnemyType(DamageType damageType = DamageType.Default, float factor = 1.0f, Attributes attributes = null)
        {
            this.damageType = damageType;
            this.factor = factor;
            this.attributes = attributes;
        }
        public static readonly EnemyType warriorSkeleton = new EnemyType(DamageType.Slashing, 1.0f, 
                        new Attributes("Warrior Skeleton", 80, 80, 0, 0, 5, 10));
        public static readonly EnemyType archerSkeleton = new EnemyType(DamageType.Slashing, 1.0f, 
                        new Attributes("Archer Skeleton", 50, 50, 0, 0, 10, 5));
        public static readonly EnemyType alien = new EnemyType(DamageType.Slashing, 1.0f, 
                        new Attributes("Alien", 60, 60, 0, 0, 10, 10));
        public static readonly List<EnemyType> enemyList = new List<EnemyType>() {
            {warriorSkeleton},
            {archerSkeleton},
            {alien},
        };
    };

}
