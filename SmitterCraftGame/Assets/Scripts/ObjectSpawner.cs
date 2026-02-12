using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectSpawner : MonoBehaviour
{
    [Tooltip("The prefab to spawn when holding the mouse over this object.")]
    public GameObject prefabToSpawn;

    private Camera mainCamera;
    private Collider2D col;
    private bool hasSpawned = false;

    void Awake()
    {
        mainCamera = Camera.main;
        col = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (Mouse.current == null || prefabToSpawn == null || col == null) return;

        // Check if Left Mouse Button is currently pressed
        if (Mouse.current.leftButton.isPressed)
        {
            Vector3 mouseWorldPos = GetMouseWorldPosition();

            // Check if the mouse is inside the collider
            if (col.OverlapPoint(mouseWorldPos))
            {
                // Only spawn once per click-hold interaction
                if (!hasSpawned)
                {
                    SpawnObject(mouseWorldPos);
                    hasSpawned = true;
                }
            }
        }

        // Reset the flag when the mouse button is released
        if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            hasSpawned = false;
        }
    }

    private void SpawnObject(Vector3 position)
    {
        Instantiate(prefabToSpawn, position, Quaternion.identity);
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector2 mousePos = Mouse.current.position.ReadValue();
        Vector3 worldPos = mainCamera.ScreenToWorldPoint(mousePos);
        worldPos.z = 0f; // Ensure z is 0 for 2D
        return worldPos;
    }
}
