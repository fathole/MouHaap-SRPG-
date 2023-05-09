using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace ChessScene
{
    public class MenuScript
    {
        [MenuItem("Tools/Assign Tile Script")]
        public static void AssignTileScript()
        {
            GameObject[] tileArray = GameObject.FindGameObjectsWithTag("Tile");

            foreach (GameObject tile in tileArray)
            {
                if (tile.GetComponent<Tile>() == null)
                {
                    tile.AddComponent<Tile>();
                }
            }
        }
    }
}