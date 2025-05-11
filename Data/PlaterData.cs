using UnityEngine;

namespace AQLibrary.Data
{
    public class PlayerData
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Vector3 Position { get; set; }
        public Quaternion Rotation { get; set; }
        public float Health { get; set; }
        public int Level { get; set; }
        public string Class { get; set; } = string.Empty;
        public int CellID { get; set; }
        public float XP { get; set; }
    }
}