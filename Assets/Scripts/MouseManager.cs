using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    private float moveScreenBorder = 20f;
    private float cameraMoveSpeed = 10f;
    private int cameraMoveLimitOffset = 5;
    private Vector2 cameraMoveLimit;
    private Vector3 cameraPosition;

    private void Start()
    {
        cameraPosition.y = Camera.main.transform.position.y;
        cameraMoveLimit = new Vector2(MapManager.groundTiles.GetLength(0), MapManager.groundTiles.GetLength(1));
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject currentTile = GroundTile.currentTile;
            currentTile.GetComponent<MeshRenderer>().material.color = Color.cyan;
        }

        HandleMapMovement();
        MoveCamera();
    }

    private void HandleMapMovement()
    {
        if (Input.GetAxisRaw("Horizontal") > 0 || Input.mousePosition.x > (Screen.width - moveScreenBorder))
        {
            cameraPosition.x += cameraMoveSpeed * Time.deltaTime;
        }

        if (Input.GetAxisRaw("Horizontal") < 0 || Input.mousePosition.x < moveScreenBorder)
        {
            cameraPosition.x -= cameraMoveSpeed * Time.deltaTime;
        }

        if (Input.GetAxisRaw("Vertical") > 0 || Input.mousePosition.y >= (Screen.height - moveScreenBorder))
        {
            cameraPosition.z += cameraMoveSpeed * Time.deltaTime;
        }

        if (Input.GetAxisRaw("Vertical") < 0 || Input.mousePosition.y <= moveScreenBorder)
        {
            cameraPosition.z -= cameraMoveSpeed * Time.deltaTime;
        }
    }

    private void MoveCamera()
    {
        cameraPosition.x = Mathf.Clamp(cameraPosition.x, 0, cameraMoveLimit.x);
        cameraPosition.z = Mathf.Clamp(cameraPosition.z, -cameraMoveLimitOffset, cameraMoveLimit.y - cameraMoveLimitOffset);

        Camera.main.transform.position = cameraPosition;
    }
}
