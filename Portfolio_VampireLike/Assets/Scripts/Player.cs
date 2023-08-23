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
        // 오래된 이동 방식
        //- Input.GetAxis(string name)
        // 수평, 수직 버튼 입력을 받으면 float
        // -1f ~1f 의 값을 반환한다
        // 부드러운 이동이 필요한경우 사용한다

        //- Input.GetAxisRaw(string name)
        // 수평, 수직 버튼 입력을 받으면 float
        // -1f , 0f, 1f 의 값을 반환한다
        // 즉각적인 반응이 필요할때 사용한다
        // -> 더욱 명확한 컨트롤 구현 가능
        //inputVec.x = Input.GetAxisRaw("Horizontal");
        //inputVec.y = Input.GetAxisRaw("Vertical");
    }

    // 물리 연산 프레임마다 호출되는 생명주기 함수
    private void FixedUpdate()
    {
        // normalized : 벡터 값의 크기가 1이 되도록 좌표가 수정된 값.

        // 오래된 이동 방식
        //nextVec = inputVec.normalized * speed * Time.deltaTime;

        nextVec = inputVec * speed * Time.deltaTime;

        // 1. 힘을 준다
        //rigid.AddForce(inputVec);

        // 2. 속도 제어
        //rigid.velocity = inputVec;

        // 3. 위치 이동 -> 현재 위치 + 입력한 위치
        rigid.MovePosition(rigid.position + nextVec);
    }

    /// <summary>
    /// InputSystem 이용한 이동 최신 방식
    /// </summary>
    /// <param name="value">입력값</param>
    private void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }
}
