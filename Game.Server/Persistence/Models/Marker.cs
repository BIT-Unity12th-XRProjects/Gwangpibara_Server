using System.Numerics;

namespace Persistence.Models
{
    public enum MarkerType
    {
        DropItem, Clue, SelfClue, Decoration, Trap
    }

    public enum MarkerSpawnType
    {
        Base, OnClose
    }

    public struct Vector3Value { 
        public float X, Y, Z;
        public Vector3Value(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
    public struct QuaternionValue { 
        public float X, Y, Z, W;

        public QuaternionValue(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }
    }

    public class Marker
    {
        public int ID { get; set; }
        public int PrefabID { get; set; } 
        public int DropItemID { get; set; }
        public int AcquireStep { get; set; }
        public int RemoveStep { get; set; }
        public Vector3Value Position { get; set; } = new Vector3Value();
        public QuaternionValue Rotation { get; set; } = new QuaternionValue();
        public MarkerSpawnType MarkerSpawnType { get; set; } = MarkerSpawnType.Base;
        public MarkerType MarkerType { get; set; } = MarkerType.DropItem;
    }
}
