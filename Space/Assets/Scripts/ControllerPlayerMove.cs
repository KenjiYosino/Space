using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPlayerMove : MonoBehaviour
{
    public bool examination = true;
    public float speedMove; //�������� ���������
    [SerializeField] private Camera mainCamera;  
    
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float bulletForce = 25f;
    
    private Vector3 moveVector3;
    private float gravityForce = 1.0f;//���������� ���������

    //������ �� ����������
    private CharacterController characterController;
    private Animator animator;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }
    
    private void Update()
    {
        LookAtMousePointer();
        CharacterMove();
        GamingGravity();
        MouseButtonDow();
    } 

    /// <summary>
    /// ����� �������� � ������� ����� ������ ����
    /// </summary>
    private void MouseButtonDow()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (examination == true)
            {                
                Attack();
            }
        }
    }
  
    /// <summary>
    /// ����� �������� ��������� �� ����������� �������
    /// </summary>
    private void LookAtMousePointer()
    {
        var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, maxDistance: 300f))
        {
            if (examination == true)
            {
                var target = hitInfo.point;
                target.y = transform.position.y;
                transform.LookAt(target);
            }
        }   
    }
     
    /// <summary>
    /// ����� ���������� ���������
    /// </summary>
    private void CharacterMove()
    {
        //����������� �� �����������
        moveVector3 = Vector3.zero;
        moveVector3.x = Input.GetAxis("Horizontal");
        moveVector3.z = Input.GetAxis("Vertical");
        var forward = Vector3.Dot(-transform.forward, moveVector3);
        var right = Vector3.Dot(transform.right, moveVector3);
        animator.SetFloat("Forward", forward);
        animator.SetFloat("Right", right);

        moveVector3.x = moveVector3.x * speedMove;
        moveVector3.z = moveVector3.z * speedMove;
        moveVector3.y = gravityForce;
        characterController.Move(moveVector3 * Time.deltaTime);
    }

    /// <summary>
    /// ����� �������� �� ������
    /// </summary>
    private void Attack()
    {
        if(BullletPlusText.ArrowPlus > 0)
        {
            animator.SetTrigger("Shooting");
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody rigidbody = bullet.GetComponent<Rigidbody>();
            rigidbody.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);
            BullletPlusText.ArrowPlus -= 1;
            Destroy(bullet, 2);
        }       
    }

    /// <summary>
    /// ����� ����������
    /// </summary>
    private void GamingGravity()
    {
        if (!characterController.isGrounded) gravityForce -= 20f * Time.deltaTime;
        else gravityForce = -1f;
    }

}
