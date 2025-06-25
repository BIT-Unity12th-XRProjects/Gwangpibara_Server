using Microsoft.EntityFrameworkCore;
using System.Numerics;
using System.Text.Json.Serialization;

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

    [Owned]
    public class Vector3Value
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
       // public Marker Marker { get; set; }

    }
    [Owned]
    public class QuaternionValue
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public float W { get; set; }

        //public Marker Marker { get; set; }
    }
    public class Marker
    {
        public int ID { get; set; }
        public int PrefabID { get; set; } 
        public int NeedItemID { get; set; } 
        public int DropItemID { get; set; }
        public int AcquireStep { get; set; }
        public int RemoveStep { get; set; }

        public Vector3Value Position { get; set; }
        public QuaternionValue Rotation { get; set; }
        public Vector3Value Scale { get; set; }

        public MarkerSpawnType MarkerSpawnType { get; set; }
        public MarkerType MarkerType { get; set; } 
    }
}
