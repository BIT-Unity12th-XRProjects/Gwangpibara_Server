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

    class Marker
    {
        public int ID;
        public string name;
        public int dropItemID;
        public int acquireStep;
        public int removeStep;
        public Vector3Value position { get; set; }
        public QuaternionValue rotation;
        public MarkerSpawnType markerSpawnType = MarkerSpawnType.Base;
        public MarkerType markerType = MarkerType.DropItem;
    }
}
