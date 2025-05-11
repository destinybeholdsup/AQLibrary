using UnityEngine;

namespace AQLibrary
{
    public class EntityData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Vector3 Position { get; set; }
        public float Health { get; set; }
        public bool IsAlive => Health > 0;
    }

    public class PlayerData : EntityData
    {
        public int Level { get; set; }
        public string Class { get; set; }
        public int CellID { get; set; }
        public int XP { get; set; }
        public Quaternion Rotation { get; set; }
    }

    public class NPCData : EntityData
    {
        public string Faction { get; set; }
        public bool HasAgro { get; set; }
    }
}