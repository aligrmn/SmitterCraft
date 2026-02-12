using UnityEngine;
using UnityEngine.InputSystem;

public class ItemSackLogic : MonoBehaviour
{
    public ItemSO IronOre;
    private Camera mainCamera;
    private bool isDragging;
    public GameObject IronOrePrefab
;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current == null) return;

        // Mouse Down
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector3 mouseWorldPos = GetMouseWorldPosition();
            RaycastHit2D hit = Physics2D.Raycast(mouseWorldPos, Vector2.zero);

            if (hit.collider != null && hit.transform == transform)
            {
                if (IronOre.itemQuantity > 0)
                {
                    // Create visual drag object
                    
                    IronOrePrefab.transform.position = mouseWorldPos;
                        isDragging = true;
                        
                    }
            }
        }

        // Mouse Drag
        if (isDragging)
        {
            IronOrePrefab.transform.position = GetMouseWorldPosition();
            IronOre.isCraftable = true;
        }

        // Mouse Up
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
