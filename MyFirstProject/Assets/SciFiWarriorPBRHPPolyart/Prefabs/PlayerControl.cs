using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{ //필드의 인스펙터창 노출 설정
  //public: 외부클래스 접근가능 인스펙터 노출
  //private: 외브클래스 접근불가 인스펙터 비노출
  //[HideInsperctor] public: 외부클래스  접근가능 인스펙터 비노출
  // [SerializeField]private: 외부클래스 접근불가 인스펙터창 노출



    //this 키워드
    //객체 자신을 반환하는 키워드
    // Start is called before the first frame update
    public int a = 3;
    private Transform tr;
    public float moveSpeed;
    Vector3 move;

    private void Awake()
    {
        Debug.Log(this);
        Debug.Log(this.gameObject);
        Debug.Log(gameObject);
        tr = this.gameObject.GetComponent<Transform>();
        tr = GetComponent<Transform>();
        tr = transform;
        //어둡게 표시되는건 생략가능하단 의미->그냥 gameObject로 써도 된다는 뜻
    }
    void Start()
    {
        tr.position = Vector3.zero;
        transform.position = Vector3.zero;
        GetComponent<Transform>().position = Vector3.zero;
        gameObject.GetComponent<Transform>().position = Vector3.zero;
        this.gameObject.GetComponent<Transform>().position = Vector3.zero;

    }
    private void Update()
    {
        float h = Input.GetAxis("Horizontal");

        float v = Input.GetAxis("Vertical");
        Debug.Log($"h={h}, v={v}");
        move = new Vector3(h, 0, v);
    }
    // Update is called once per frame
    void FixedUpdate()
    {// 포지션 변경 시 프레임 당 변화량을 더해줘야 함 
        //시간 당 위치 변화량(속도)=위치변화량/시간
        //프레임 시간 당 위치 변화량(프레임 단위 속도)=위치/프레임 시간
        //위치변화량=프레임 시간 당 위치 변화량*프레임 시간

        //tr.position += Vector3.forward*Time.deltaTime;
        //한 프레임마다 이만큼 이동시키겠다는 의미
        tr.position += move *moveSpeed* Time.fixedDeltaTime;
    }
}
