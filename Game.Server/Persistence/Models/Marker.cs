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

    class Marker
    {
        public string name;
        public int dropItemID;
        public int acquireStep;
        public int removeStep;
        public Vector3 position;
        public Quaternion rotation;
        public MarkerSpawnType markerSpawnType = MarkerSpawnType.Base;
        public MarkerType markerType = MarkerType.DropItem;
    }
}
