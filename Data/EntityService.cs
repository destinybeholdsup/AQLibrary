using AQLibrary.Data;
using UnityEngine;

public static class EntityService
{
        public static NPCData[] GetAllNPCs()
        {
            int npcCount = 0;

            // Count
            foreach (var entity in Entities.Instance.AllEntities)
                if (entity is NPC) npcCount++;

            // Populate
            NPCData[] npcArray = new NPCData[npcCount];
            int index = 0;

            foreach (var entity in Entities.Instance.AllEntities)
            {
                if (entity is NPC npc)
                {
                    npcArray[index++] = new NPCData
                    {
                        Id = npc.ID,
                        Name = npc.name,
                        Position = npc.position,
                        Health = npc.HealthPercent,
                        HasAgro = npc.HasAggro()
                    };
                }
            }
            return npcArray;
        }

        public static PlayerData GetPlayerData()
        {
            foreach (var entity in Entities.Instance.AllEntities)
            {
                if (entity is Player player && entity.isMe)
                {
                    return new PlayerData
                    {
                        Id = player.ID,
                        Name = player.name,
                        Position = player.position,
                        Rotation = player.rotation,
                        Health = player.HealthPercent,
                        Level = player.Level,
                        Class = player.CombatClass.Name,
                        CellID = player.cellID,
                        XP = player.XP,
                    };
                }
            }
            return null;
        }
}