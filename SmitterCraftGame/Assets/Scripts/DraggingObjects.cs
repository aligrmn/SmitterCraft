using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class DraggingObjects : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private Camera mainCamera;

    void Awake()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Mouse.current == null) return;

        // On Mouse Down
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector3 mouseWorldPos = GetMouseWorldPosition();
            // Check if we clicked on THIS object's collider
            RaycastHit2D hit = Physics2D.Raycast(mouseWorldPos, Vector2.zero);
            if (hit.collider != null && hit.transform == transform)
            {
                isDragging = true;
                offset = transform.position - mouseWorldPos;
            }
        }

        // On Mouse Drag
        if (isDragging && Mouse.current.leftButton.isPressed)
        {
            transform.position = GetMouseWorldPosition() + offset;
        }

        // On Mouse Up
        if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            isDragging = false;
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector2 mousePos = Mouse.current.position.ReadValue();
        Vector3 worldPos = mainCamera.ScreenToWorldPoint(mousePos);
        worldPos.z = 0f; // Ensure z is 0 for 2D
        return worldPos;
    }
}
