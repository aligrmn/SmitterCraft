using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Collider2D ingotcollider;
    public Collider2D borderscollider;
    public float cameraSpeed = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ingotcollider.IsTouching(borderscollider))
        {
            Camera.main.transform.position += Vector3.right * cameraSpeed * Time.deltaTime;
        }
    }
}
