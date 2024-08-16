using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 300f;
    public float rotationSmoothTime = 0.05f;

    public Transform playerBody;

    private float xRotation = 0f;
    private float yRotation = 0f;
    private Vector3 currentRotation;
    private Vector3 rotationVelocity;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        Vector3 targetRotation = new Vector3(xRotation, yRotation);
        currentRotation = Vector3.SmoothDamp(currentRotation, targetRotation, ref rotationVelocity, rotationSmoothTime);
        transform.localRotation = Quaternion.Euler(currentRotation.x, 0f, 0f);
        playerBody.localRotation = Quaternion.Euler(0f, currentRotation.y, 0f);
    }
}
