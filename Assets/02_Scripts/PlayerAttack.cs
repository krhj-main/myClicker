using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour
{
    // 공격 스크립트, 공격할 수 있는 오브젝트

    Button btn;
    // UI 버튼을 제어하기 위한 버튼 객체

    GameObject boxcol;
    // 공격 범위에 해당하는 오브젝트

    float count;
    // 공격 쿨타임을 측정하기 위한 변수
    // Start is called before the first frame update
    void Start()
    {
        boxcol = transform.Find("Attack_Range").gameObject;
        boxcol.SetActive(false);
        // 공격 범위를 비활성화
        btn = GameObject.Find("Click_Range_Btn").GetComponent<Button>();
        // UI 버튼 객체를 찾기

        btn.onClick.AddListener(AttackMotion);
        // 버튼 클릭 시 AttackMotion 메서드 호출
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AttackMotion()
    {
        count = 0;
        // 공격 쿨타임 변수를 0으로 초기화
        StartCoroutine("CountAttackTime");        
        // 공격 쿨타임을 측정하는 코루틴 시작
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        // 충돌한 오브젝트가 나가면 실행
        if (collision.gameObject.tag == "Projectile")
        {            
            boxcol.SetActive(false);
            // 오브젝트가 Projectile일 경우 공격 범위를 비활성화
            StopCoroutine("CountAttackTime");          
            // 공격 쿨타임 코루틴 중지
        }   
    }
    IEnumerator CountAttackTime()
    {
        // 공격 쿨타임을 측정하는 코루틴
        while (true)
        {
            count += Time.deltaTime;
            // 매 프레임마다 시간 누적
            if (count > 1/GM.instance.playerAttackSpeed)
            {
                // 1 / 공격 속도에 따라 쿨타임을 결정
                // 쿨타임이 끝나면 공격 범위를 활성화
                boxcol.SetActive(true);
                // 공격 범위를 ON
                count = 0;
                // 공격 쿨타임 변수를 0으로 초기화
                yield return null;
            }
        }
        // While 문이 종료되지 않으면, 공격 범위가 비활성화된 오브젝트에 대해 계속 실행
    }

}
