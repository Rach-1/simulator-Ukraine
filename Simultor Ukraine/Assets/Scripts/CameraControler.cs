using UnityEngine;

public class CameraControler : MonoBehaviour
{
    public float PanSpeed = 20f; 
    public float PanBorderThickness = 20f; //для миші
    public Vector2 PanLimit; //рамки руху камери
    public Camera cam;

    public float ZoomChange = 1f;
    public float SmoothChange = 1f;
    public float MinCamSize = 10f;
    public float MaxCamSize = 10f;
    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        
        if(Input.GetKey("w")|| Input.mousePosition.y >= Screen.height - PanBorderThickness)
        {
            pos.y += PanSpeed * Time.deltaTime;
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= PanBorderThickness)
        {
            pos.y -= PanSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - PanBorderThickness)
        {
            pos.x += PanSpeed * Time.deltaTime;
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= PanBorderThickness)
        {
            pos.x -= PanSpeed * Time.deltaTime;
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if(Input.mouseScrollDelta.y < 0f)
        {
            ZoomIn();
        }
        else if(Input.mouseScrollDelta.y > 0f)
        {
            ZoomOut();
        }
        cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, MinCamSize, MaxCamSize);

        pos.x = Mathf.Clamp(pos.x, -PanLimit.x, PanLimit.x);
        pos.y = Mathf.Clamp(pos.y, -PanLimit.y, PanLimit.y);
              
        transform.position = pos;
    }

    public void ZoomIn()
    {
        cam.orthographicSize += ZoomChange * Time.deltaTime * SmoothChange;
    }

    public void ZoomOut()
    {
        cam.orthographicSize -= ZoomChange * Time.deltaTime * SmoothChange;
    }
}
