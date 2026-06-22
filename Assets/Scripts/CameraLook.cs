using UnityEngine;
using UnityEngine.InputSystem;

public class CameraLook : MonoBehaviour
{
    [SerializeField] float lookSpeed = 7f;
    [SerializeField] float minPitch = -60f;
    [SerializeField] float maxPitch = 60f;
    float currentPitch = 0f;

    public void Look(InputAction.CallbackContext context)
    {
        Vector2 lookInput = context.ReadValue<Vector2>();
        LookUpDown(lookInput.y);
    }

    void LookUpDown(float lookInput)
    {
        currentPitch -= lookInput * lookSpeed * Time.deltaTime;
        currentPitch = Mathf.Clamp(currentPitch, minPitch, maxPitch);
        transform.localRotation = Quaternion.Euler(currentPitch, 0f, 0f);
    }
}
