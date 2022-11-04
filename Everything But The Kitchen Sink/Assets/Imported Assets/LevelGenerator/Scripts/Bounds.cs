using System.Collections.Generic;
using UnityEngine;

namespace LevelGenerator.Scripts
{
    public sealed class Bounds : MonoBehaviour
    {
            public IEnumerable<Collider> Colliders => GetComponentsInChildren<Collider>();
    }
}
