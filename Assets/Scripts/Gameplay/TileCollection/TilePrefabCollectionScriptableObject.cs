using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TilePrefabCollection")]
public class TilePrefabCollectionScriptableObject : ScriptableObject
{
    public GameObject TileLShapePrefab;
    public GameObject TileStraightPrefab;
    public GameObject TileJunctionPrefab;
    public GameObject TileTJunctionPrefab;
    public GameObject TileEntrancePrefab;
    public GameObject TileExitPrefab;
    public GameObject TileBlockPrefab;
}