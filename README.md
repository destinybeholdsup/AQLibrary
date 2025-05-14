Make a Class Library using Standard 2.1 framework

Reference these dependencies in your project
```
UnityEngine.dll
UnityEngine.CoreModule.dll
Stat Curves.dll
Assembly-CSharp.dll
```

open assembly-csharp.dll in DNSPY
Go into Game, Find Update(), edit method

copy and paste this

```c#
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.IO;
using System.Reflection;

using UnityEngine;

public partial class Game : State
{
	private bool modLoaded = false;
	private Assembly modAssembly;
	
	private void Update()
	{
		if (!this.isReady)
		{
			return;
		}
		
		if (!modLoaded)
		{
			LoadMod();
			modLoaded = true;
		}
		
		InputManager.Update();
		foreach (NPC npc in this.entities.NpcList)
		{
			npc.Update();
		}
		foreach (Player player in this.entities.PlayerList)
		{
			player.Update();
		}
		if (!UICamera.inputHasFocus && this.entities.me != null)
		{
			this.ProcessShortcuts();
		}
		this.UpdateCursor();
		this.UpdateDraggable();
	}
	private void LoadMod()
	{
		try
		{
			string modPath = "AQLibrary.dll";
			byte[] modBytes = File.ReadAllBytes(modPath);
			Assembly modAssembly = Assembly.Load(modBytes);
			
			Type mainType = modAssembly.GetType("AQLibrary.Main");
			MethodInfo initMethod = mainType.GetMethod("Initialize");
			
			initMethod.Invoke(null, null);
			Debug.Log("[+] AQLibrary loaded successfully!");
		}
		catch (Exception ex)
		{
			Debug.LogError($"[+] Failed to load AQLibrary: {ex}");
		}
	}
}
```

When you build AQLibrary, place it in `C:\Program Files (x86)\Steam\steamapps\common\AdventureQuest3D`
The only thing in AdventureQuest3D folder should be the DLL and aq3d folder which is main game data
Run AQ3D
Enjoy
