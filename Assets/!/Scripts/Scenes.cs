using System;

namespace Panda
{
    public static class Scenes
    {
        public static readonly Data MainMenu = new Data("MainMenu", "UI");
        
        public static class Adventure
        {
            public static readonly Data Level1 = new Data("Level_1", "Adventure");
            public static readonly Data Dialogue = new Data("Dialogue", "UI");
        }

        public struct Data : IEquatable<Data>
        {
            public readonly string Name;
            public readonly string InputMap;

            public Data(string name, string inputMap)
            {
                Name = name;
                InputMap = inputMap;
            }

            public bool Equals(Data other)
            {
                return Name == other.Name && InputMap == other.InputMap;
            }

            public override bool Equals(object obj)
            {
                return obj is Data other && Equals(other);
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(Name, InputMap);
            }
        }
    }
}