using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]
    float speed;

    Vector2 inputVec;
    Vector2 nextVec;

    Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // ������ �̵� ���
        //- Input.GetAxis(string name)
        // ����, ���� ��ư �Է��� ������ float
        // -1f ~1f �� ���� ��ȯ�Ѵ�
        // �ε巯�� �̵��� �ʿ��Ѱ�� ����Ѵ�

        //- Input.GetAxisRaw(string name)
        // ����, ���� ��ư �Է��� ������ float
        // -1f , 0f, 1f �� ���� ��ȯ�Ѵ�
        // �ﰢ���� ������ �ʿ��Ҷ� ����Ѵ�
        // -> ���� ��Ȯ�� ��Ʈ�� ���� ����
        //inputVec.x = Input.GetAxisRaw("Horizontal");
        //inputVec.y = Input.GetAxisRaw("Vertical");
    }

    // ���� ���� �����Ӹ��� ȣ��Ǵ� �����ֱ� �Լ�
    private void FixedUpdate()
    {
        // normalized : ���� ���� ũ�Ⱑ 1�� �ǵ��� ��ǥ�� ������ ��.

        // ������ �̵� ���
        //nextVec = inputVec.normalized * speed * Time.deltaTime;

        nextVec = inputVec * speed * Time.deltaTime;

        // 1. ���� �ش�
        //rigid.AddForce(inputVec);

        // 2. �ӵ� ����
        //rigid.velocity = inputVec;

        // 3. ��ġ �̵� -> ���� ��ġ + �Է��� ��ġ
        rigid.MovePosition(rigid.position + nextVec);
    }

    /// <summary>
    /// InputSystem �̿��� �̵� �ֽ� ���
    /// </summary>
    /// <param name="value">�Է°�</param>
    private void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }
}
