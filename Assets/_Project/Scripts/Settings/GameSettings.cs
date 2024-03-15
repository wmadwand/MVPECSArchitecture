using System;
using UnityEngine;

namespace Appsulove.Settings
{
    [CreateAssetMenu(menuName = "Appsulove/Settngs")]
    public class GameSettings : ScriptableObject
    {
        public int EnemyPositionOffset = 25;
        public int PlayerPositionOffset = 30;
        public int EnemySpawnRate = 5;
        public int EnemyMaxCount = 15;
        public float PlayerSpeed = 5;
    }
}