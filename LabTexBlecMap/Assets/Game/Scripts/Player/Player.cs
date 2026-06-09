using UnityEngine;

public class Player : MonoBehaviour
{
    

    [Header("��������")]
    public float moveSpeed = 5f;
    public float jumpForce = 5f;

    [Header("������")]
    public Transform cameraTransform;
    public float mouseSensitivity = 2f;
    public float verticalLookLimit = 80f;

    [Header("�������� �����")]
    public LayerMask groundLayer; // ������ ���� "Everything" ����� "Ignore Raycast"
    public float groundCheckDistance = 0.2f;

    private Rigidbody rb;
    private float xRotation = 0f;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // ������������ ��������, ����� ������� �� ������
        rb.freezeRotation = true;

        // ������ ������
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        HandleLook();

        // ������ ��������� � Update, ����� �� ���������� �������
        if (Input.GetButtonDown("Jump") && CheckGrounded())
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        HandleMove();
    }

    void HandleLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // �������� ���� (�����-������)
        transform.Rotate(Vector3.up * mouseX);

        // �������� ������ (�����-����)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -verticalLookLimit, verticalLookLimit);
        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }

    void HandleMove()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        Vector3 moveDir = (transform.forward * moveZ + transform.right * moveX).normalized;

        // ��������� ��������, �������� ������� ������������ �������� (����������/������)
        rb.linearVelocity = new Vector3(moveDir.x * moveSpeed, rb.linearVelocity.y, moveDir.z * moveSpeed);
    }

    void Jump()
    {
        // ���������� ������������ �������� ����� ������� ��� ���������� ������
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    bool CheckGrounded()
    {
        // ������� �������� ��� ���� �� ������ �������
        // (0.1f � ��������� ����� ���� ����������)
        float height = GetComponent<CapsuleCollider>().height / 2;
        return Physics.Raycast(transform.position, Vector3.down, height + groundCheckDistance, groundLayer);
    }
}

