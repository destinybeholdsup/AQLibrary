using UnityEngine;

namespace AQLibrary.Data
{
    public class NPCData
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Vector3 Position { get; set; }
        public float Health { get; set; }
        public bool HasAgro { get; set; }
    }
}