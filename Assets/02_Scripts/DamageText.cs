using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageText : MonoBehaviour
{
    // 데미지 텍스트 객체

    TextMeshProUGUI dmgTXT;
    // 데미지 표시를 위한 TMP 객체
    
    // Start is called before the first frame update
    void Start()
    {
        dmgTXT = GetComponent<TextMeshProUGUI>();
        // 텍스트 TMP 컴포넌트를 가져옴

        dmgTXT.text = string.Format("{0}", GM.instance.playerAttackPower);
        // 데미지 텍스트를 설정 => 플레이어 공격력
    }

    // Update is called once per frame
    void Update()
    {
        DissolveFont();
        // 텍스트를 서서히 사라지게 하는 함수 호출
        if (dmgTXT.color.a <= 0f)
        {
            Destroy(gameObject);
            // 텍스트의 알파가 0 -> 오브젝트를 파괴
        }
    }
    void DissolveFont()
    {   
        dmgTXT.color = new Color(dmgTXT.color.r, dmgTXT.color.g, dmgTXT.color.b, dmgTXT.color.a - 0.005f);
        // 텍스트의 알파를 줄여서 서서히 사라지게 함
        dmgTXT.transform.position += (Vector3.up + Vector3.left) / 10;
        // 텍스트의 위치를 서서히 위쪽과 왼쪽으로 이동
    }
}
