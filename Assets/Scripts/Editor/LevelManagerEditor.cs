using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

// script made to get all modules (that is, prefabs that are "implementing" Level class MonoBehaviour)
// then populates the Modules field of the LevelManager.
	class LevelManagerEditor 
	{
		// adds an entry to the file menu
		[MenuItem("GDC/Fetch Modules")]
		public static void FetchModules()
		{
			var lm = GameObject.Find(typeof(LevelManager).Name);
			if (lm == null)
			{
				Debug.LogError("No level manager in this scene bauss.");
				return;
			}
			var prefabs = AssetDatabase.GetAllAssetPaths()																// Gets all assets from the asset database (basically every files in /Assets)
								.Where(path => Path.GetExtension(path) == ".prefab")									// that are prefabs
								.Select(path => AssetDatabase.LoadAssetAtPath(path, typeof(GameObject)) as GameObject)	// instanciate every path to a gameobject
								.Where(go => go.GetComponent<Level>() != null)											// check if it has a Level component
								.OrderBy(go => go.name)																	// sorts it to be pretty
								.ToArray();


			var manager = lm.GetComponent<LevelManager>();
			manager.Modules = prefabs;						 // set everything on the level manager

			EditorUtility.SetDirty(manager);				 // tells the editor that the field is dirty (to refresh the view)
		}
	}
