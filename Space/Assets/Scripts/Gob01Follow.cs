using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gob01Follow : MonoBehaviour
{
    public float speed;
    private Transform player;
    private Animator animator;
    private int state;

    private void Start()
    {    
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        state = ChangeState();
        State();
    }

    /// <summary>
    /// ����� ��������� ��������� ��������
    /// </summary>
    /// <returns></returns>
    private int ChangeState()
    {
        if (player != null)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance < 15f)
            {
                return 2;
            }
            if (distance < 50f)
            {
                return 1;
            }
        }
        return 0;
    }

    /// <summary>
    /// ����� �������� ��� ������������ ���������
    /// </summary>
    private void State()
    {
        switch (state)
        {
            case 0:
                animator.SetBool("Walk", false);
                speed = 0;
                break;
            case 1:
                PlayerPursuit();
                break;
            case 2:
                Attack();
                break;
        }
    }

    /// <summary>
    /// ����� ������������� 
    /// </summary>
    private void PlayerPursuit()
    {
        speed = 10;
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        transform.LookAt(player);
        animator.SetBool("Walk", true);
    }

    /// <summary>
    /// ����� �����
    /// </summary>
    private void Attack()
    {
        speed = 0;
        transform.LookAt(player);
        animator.SetBool("Run", false);
        animator.SetTrigger("Attack");
    }
}
