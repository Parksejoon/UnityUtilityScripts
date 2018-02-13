using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TextFade : MonoBehaviour, IPointerClickHandler
{
    // 인스펙터 노출 변수
    // 일반
    [Multiline(3), SerializeField]
    private string text = "";                        // 입력될 텍스트
    [SerializeField]
    private Text   textBox = null;                   // 텍스트가 입력될 텍스트 박스

    [Space(20)]
 
    // 수치
    [SerializeField]
    private float  speed = 1f;                       // 텍스트 출력 속도
    [SerializeField]
    private bool   touchSkip = false;                // 터치시 스킵기능 사용할지


    // 인스펙터 비노출 변수
    // 일반
    private char[] textArray;                        // char배열로 변환된 텍스트
    private int    textIndex = 0;                    // 배열 인덱스
    private bool   isDone = true;                    // 끝났는지
    
    // 수치



    // 시작 초기화
    private void Awake()
    {
        if (textBox == null)
        {
            textBox = GetComponent<Text>();
        }

        Initialize(text);
        StartOutputText();
    }

    // 초기화
    public void Initialize(string newText)
    {
        // 변수 초기화
        text = newText;

        textArray = text.ToCharArray();
        textIndex = 0;
        isDone = true;
    }

    // 텍스트 출력 시작
    public void StartOutputText()
    {
        isDone = false;
        StartCoroutine(OutputText());
    }

    // 텍스트 출력 중지
    public void StopOutputText()
    {
        isDone = true;
        StopCoroutine(OutputText());
    }

    // 텍스트 출력 스킵
    public void SkipOutputText()
    {
        StopOutputText();
        textBox.text = text;
    }

    // 마우스 클릭시
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (touchSkip && !isDone)
        {
            SkipOutputText();
        }
    }

    // 텍스트 출력
    private IEnumerator OutputText()
    {
        if (textIndex < textArray.Length)
        {
            textBox.text += textArray[textIndex++];

            yield return new WaitForSeconds(0.01f * speed);
            
            StartCoroutine(OutputText());
        }

        yield return null;
    }
}
