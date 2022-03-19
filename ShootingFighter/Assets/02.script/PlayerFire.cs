using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletPrefab;//bullet 오브젝트를 멤버로 가지고 이걸 쏠 수 있게 됨
    //참고로 프리팹은 옵젝을 생성 밎 저장한다는 의미, 그것 자체를 폴더같은걸로 압축해 다른데다가 재사용할 수 있게 만듦
    public Transform firePoint;//총알이 생성되는 위치
    public float fireTimeGap = 0.3f;
    private float fireTimer;
   
    private void Update()//유니티에서의 인스턴스화-만들어진 오브젝트를 실시간으로 생성한다는 의미(예: 총알)
    {
        if(Input.GetKeyDown(KeyCode.Space))//누르는 순간 초기화가 됨
        {
            Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            fireTimer = fireTimeGap;//누를 때 한번 돌기
        }
        if (fireTimer < 0 &&
Input.GetKey(KeyCode.Space))//총알 간 딜레이 생성
        //키가 눌려있으면 쭉 트루 반환
        {
            Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);//.position을 하면 그저 위치만 따라감
            fireTimer = fireTimeGap;                                           //하지만 저걸 빼면 파이어포인트 자체에 종속
                                                                               //쿼터니온은 각도를 표현하는 것
                                                                               //축이 겹쳐서 차원이 줄어드는 현상을 방지
        }
        else
            fireTimer -= Time.deltaTime;

    }
}
