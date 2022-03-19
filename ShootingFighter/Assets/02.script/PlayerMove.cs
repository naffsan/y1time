using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
    
{
    private Transform tr;

    Vector3 move;//hv 받고 와이축 0
    public float speed = 1f;
    // 키보드 화살표 왼쪽 오른쪽 방향키로 x축무빙
    //위아래 방향키로 z축무빙
    private void Awake()//start보다 먼저 실행됨
    {
        tr = GetComponent<Transform>();//한번 불러와서 캐싱시키기-오브젝트와 코드를 잇는 징검다리로
                                       //이게 없을 시 옵젝이 움직이질 않음


    }
  

   private void Update()//어딜 어떻게 얼만큼 움직일지 주기
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        //각각 키 입력을 받았을 때 x z축으로 무빙을 주겠다는 의미
        //이 hv에 따라 움직임, 참고로 움직이는 건 픽스드업데이트에서 해야 자연스럽
        move=new Vector3(h,0,v).normalized;//normalized는 방향벡터로 사용하기/누르는 순간 움직이게 하기,
                                           //만약 자연스럽게 움직이게하려면 이거 빼면 됨
    }
    private void FixedUpdate()//실제로 움직이시오 하고 명령하기
    {
        tr.Translate(move*speed*Time.fixedDeltaTime);//움직이기
                                                     //deltatime은 컴 프레임레이트가 후져도
                                                     //좋은 유저랑 후진 유저랑 별 차이가 없게 만드는 것

    }

}//1. 