using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    public bool IsBreaking { get; private set; }
    public float HorizontalInput { get; private set; }
    public float VerticalInput { get; private set; }


    private void FixedUpdate()
    {
        IdentifyInput();
    }
    private void IdentifyInput()
    {
        IsBreaking = Input.GetKey(KeyCode.Space);
        HorizontalInput = Input.GetAxisRaw(HORIZONTAL);
        VerticalInput = Input.GetAxisRaw(VERTICAL);
    }

}
