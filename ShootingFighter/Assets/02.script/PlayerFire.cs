using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletPrefab;//bullet ������Ʈ�� ����� ������ �̰� �� �� �ְ� ��
    //����� �������� ������ ���� �G �����Ѵٴ� �ǹ�, �װ� ��ü�� ���������ɷ� ������ �ٸ����ٰ� ������ �� �ְ� ����
    public Transform firePoint;//�Ѿ��� �����Ǵ� ��ġ
    public float fireTimeGap = 0.3f;
    private float fireTimer;
   
    private void Update()//����Ƽ������ �ν��Ͻ�ȭ-������� ������Ʈ�� �ǽð����� �����Ѵٴ� �ǹ�(��: �Ѿ�)
    {
        if(Input.GetKeyDown(KeyCode.Space))//������ ���� �ʱ�ȭ�� ��
        {
            Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            fireTimer = fireTimeGap;//���� �� �ѹ� ����
        }
        if (fireTimer < 0 &&
Input.GetKey(KeyCode.Space))//�Ѿ� �� ������ ����
        //Ű�� ���������� �� Ʈ�� ��ȯ
        {
            Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);//.position�� �ϸ� ���� ��ġ�� ����
            fireTimer = fireTimeGap;                                           //������ ���� ���� ���̾�����Ʈ ��ü�� ����
                                                                               //���ʹϿ��� ������ ǥ���ϴ� ��
                                                                               //���� ���ļ� ������ �پ��� ������ ����
        }
        else
            fireTimer -= Time.deltaTime;

    }
}
