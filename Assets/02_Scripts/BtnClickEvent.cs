using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BtnClickEvent: MonoBehaviour
{
    // 버튼 클릭 이벤트 스크립트

    float random_Attack;                                                            
    // 랜덤 공격 수치를 생성하기 위한 변수
    float anim_time;
    // 애니메이션의 진행 상태를 0.0~1.0으로 나타내는 변수
    


    public GameObject projectile;
    // 발사체 프리팹 객체
    Button myBtn;
    // 버튼 UI 객체
    Animator anim;
    // 캐릭터의 애니메이터 객체

    // Start is called before the first frame update
    void Start()
    {
        myBtn = GetComponent<Button>();
        // 현재 게임 오브젝트의 버튼 컴포넌트를 가져옴
        anim = GameObject.Find("Character").GetComponent<Animator>();
        // 캐릭터의 애니메이터 컴포넌트를 가져옴

        myBtn.onClick.AddListener(ClickBtn);
        // 버튼 클릭 시 ClickBtn 메서드 호출
    }

    // Update is called once per frame
    void Update()
    {
        anim_time = anim.GetCurrentAnimatorStateInfo(0).normalizedTime;
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Blend_Attack"))
        {
            anim.SetFloat("attack_Speed", GM.instance.playerAttackSpeed);
            if (anim_time >= 0.7f || anim_time <= 0f)
            {
                myBtn.interactable = true;
            }
            else
            {
                myBtn.interactable = false;
            }
        }
    }    
    void ClickBtn()
    {
        random_Attack = Random.Range(0.0f, 1.0f);
        // 0.0~ 1.0 사이의 랜덤 값을 생성
        anim.SetFloat("random_Attack", random_Attack);
        // 애니메이터의 random_Attack 파라미터에 랜덤 값을 설정
        anim.SetTrigger("isAttack");
        // 애니메이터의 isAttack 트리거를 ON
        StartCoroutine("createProjectile");
        // 발사체 생성 코루틴 시작
    }
    IEnumerator createProjectile()
    {
        GameObject gg = Instantiate(projectile);
            gg.transform.position = new Vector3(450,
                                                Random.Range(-150, 350),
                                                    0);
        // 발사체를 생성, 위치는 x축 450, y축 -150~350 사이의 랜덤 값
        yield return null;
    }
}
