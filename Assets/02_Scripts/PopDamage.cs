using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopDamage : MonoBehaviour
{
    [SerializeField]
    GameObject damageObj;
    // 데미지 텍스트 오브젝트

    bool inATKRange;
    // 공격 범위 내에 있는지 여부
    Button rangeBTN;
    // 공격 버튼 UI 객체
    
    // Start is called before the first frame update
    void Start()
    {
        rangeBTN = GameObject.Find("Click_Range_Btn").GetComponent<Button>();
        // 공격 버튼 오브젝트의 버튼 컴포넌트를 가져옴

        rangeBTN.onClick.AddListener(Attacked);
        // 버튼 클릭 시 Attacked 메서드 호출
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 일반 오브젝트와 충돌했을 때 데미지 100을 입힘.
        // 플레이어 UI에 골드를 추가
        if (collision.gameObject.tag == "AttackRange")
        {
            GM.instance.playerHaveGold += GM.instance.defaultIncome;
            UIManager.Instance.updateGold();
            GameObject go = Instantiate(damageObj, GameObject.Find("Canvas2").transform);
            go.transform.position = this.transform.position;
            Destroy(gameObject, 0.7f);
            // 오브젝트를 0.7초 후에 파괴
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        // 공격 범위 내에 있는지 확인하는 조건
        // 공격 범위에 들어오면 isATKRange를 true로 설정
        if (collision.gameObject.tag == "AttackRange")
        {
            inATKRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        // 공격 범위를 벗어나면 isATKRange를 false로 설정
        if (collision.gameObject.tag == "AttackRange")
        {
            inATKRange = false;
        }
    }

    void Attacked()
    {
        // 공격 버튼이 눌렸을 때 
        // 공격 범위 내에 있을 경우 데미지를 입힘
        if (inATKRange == true)
        {
            GameObject gg = Instantiate(damageObj, GameObject.Find("Canvas2").transform);
            gg.transform.position = this.transform.position;
            GetComponent<MobMove>().HitedFromPlayer();
            // 데미지 텍스트를 생성하고 몬스터에게 공격
        }
    }
}
