using System;
using UnityEngine;

namespace Panda.Minigames.Memory
{
    [Serializable]
    public struct Settings
    {
        [Min(1)] public int rows;
        [Min(1)] public int columns;
    }
}