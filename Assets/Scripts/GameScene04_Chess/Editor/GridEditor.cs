using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace ChessScene
{
    public class GridEditor : EditorWindow
    {
        #region Declaration

        private GameObject parent;
        private GameObject tile;
        private Vector3 gridPosition;
        private Vector2Int gridSize = new Vector2Int(15, 12);

        #endregion

        [MenuItem("Window / Tools / Grid Generator")]
        public static void ShowWindow()
        {
            EditorWindow editorWindow = GetWindow(typeof(GridEditor));
        }

        private void OnGUI()
        {
            Fields();
            Buttons();
        }

        private void Fields()
        {
            tile = (GameObject)EditorGUILayout.ObjectField("Tile", tile, typeof(GameObject), true);

            if (parent != null)
            {
                GUILayout.Label("Parent Grid: " + parent.name);
            }
            else
            {
                GUILayout.Label("No active grid focused!");
            }

            EditorGUILayout.Space(10f);

            gridPosition = EditorGUILayout.Vector3Field("Grid Start Position", gridPosition);

            gridSize.x = Mathf.Clamp(EditorGUILayout.IntField("Width", gridSize.x), 0, 99);
            gridSize.y = Mathf.Clamp(EditorGUILayout.IntField("Length", gridSize.y), 0, 99);

            EditorGUILayout.Space(20f);
        }

        private void Buttons()
        {
            GUILayout.Label("Grid selection");

            if (GUILayout.Button("Create new grid"))
            {
                CreateNewParent();
            }

            if (GUILayout.Button("Focus Grid"))
            {
                FocusOnGrid();
            }

            EditorGUILayout.Space(20f);
            GUILayout.Label("Grid manipulation");

            if (tile == null || parent == null)
            {
                return;
            }

            if (GUILayout.Button("(re)Generate"))
            {
                if (tile != null)
                {
                    GenerateGrid();
                }
                else
                {
                    Debug.Log("Select a tile to generate");
                }
            }

            if (GUILayout.Button("Connect two tiles"))
            {
                CreateLadder();
            }

            if (GUILayout.Button("Connect character and tile"))
            {
                SetCharacterStartTile();
            }
        }

        private void GenerateGrid()
        {
            TileGenerator tileGenerator;

            if (parent == null)
            {
                CreateNewParent();
            }

            parent.transform.position = gridPosition;

            if (!parent.GetComponent<TileGenerator>())
            {
                tileGenerator = parent.AddComponent<TileGenerator>();
            }
            else
            {
                tileGenerator = parent.GetComponent<TileGenerator>();
            }

            tileGenerator.GenerateGrid(tile, gridSize);
        }

        private void CreateNewParent()
        {
            parent = new GameObject("Grid");
        }

        private void SetCharacterStartTile()
        {
            GameObject character = Selection.activeTransform.gameObject;

            if (Physics.Raycast(character.transform.position, Vector3.down, out RaycastHit hit, 200))
            {
                character.GetComponent<Chess>().chessData.chessTile = hit.transform.GetComponent<Tile>();
                Debug.Log("Successfully coupled character with a tile");
            }
            else
            {
                Debug.LogError("<color=red>Error</color>");
            }
        }

        private void CreateLadder()
        {
            GameObject[] tiles = Selection.gameObjects;
            if (tiles.Length != 2)
            {
                return;
            }

            if (tiles[0].GetComponent<Tile>() && tiles[1].GetComponent<Tile>())
            {
                tiles[0].GetComponent<Tile>().connectedTile = tiles[1].GetComponent<Tile>();
                tiles[1].GetComponent<Tile>().connectedTile = tiles[0].GetComponent<Tile>();
                Debug.Log($"Created ladder between tile {tiles[0].name} and {tiles[1].name}");
            }
        }

        private void FocusOnGrid()
        {
            GameObject grid = Selection.activeGameObject;
            
            if (!grid.GetComponent<TileGenerator>())
            {
                return;
            }

            parent = grid;
            gridPosition = parent.transform.position;

            Debug.Log("Focusing on grid with name: " + parent.name);
        }
    }
}