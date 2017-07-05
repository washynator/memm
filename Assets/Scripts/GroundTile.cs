using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    public static GameObject currentTile;

    private Color newColor = Color.red;
    private Color clickedColor = Color.cyan;
    private Color originalColor;
    private MeshRenderer meshRenderer;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        originalColor = meshRenderer.material.color;
    }

    public void OnMouseEnter()
    {
        if (meshRenderer.material.color != clickedColor)
        {
            meshRenderer.material.color = newColor;
        }

        currentTile = MapManager.Instance.GetCurrentTile((int)transform.position.x, (int)transform.position.z);
    }

    public void OnMouseExit()
    {
        if (meshRenderer.material.color != clickedColor)
        {
            meshRenderer.material.color = originalColor;
        }
    }
}
