using System;
using UnityEngine;

namespace Appsulove.Settings
{
    [CreateAssetMenu(menuName = "Appsulove/Prefabs")]
    public class Prefabs : ScriptableObject
    {
        public Player Player;
        public Enemy Enemy;
    }
}