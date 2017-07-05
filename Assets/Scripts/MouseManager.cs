using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject currentTile = GroundTile.currentTile;
            currentTile.GetComponent<MeshRenderer>().material.color = Color.cyan;
        }
    }
}
