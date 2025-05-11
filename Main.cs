



namespace AQLibrary
{
    public static class Main
    {
        private static PlayerData? player;
        private static NPCData[]? npcs;

        public static void Initialize()
        {
            Chat.Notify("AQLibrary Initialized");

            AssemblyResolver.Initialize();

            var npcs = EntityService.GetAllNPCs();
            var player = EntityService.GetPlayerData();

            if (player != null)
            {
            }

            if(npcs != null)
            {
                foreach (var npc in npcs)
                {
                    Chat.Notify($"Found NPC: {npc.Name} at position {npc.Position} with {npc.Health}% health");

                    if (npc.HasAgro)
                    {
                        Chat.Notify($"Warning: {npc.Name} has aggro!");
                    }
                }
            }
        }
    }
}