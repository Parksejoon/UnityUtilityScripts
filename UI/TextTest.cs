using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTest : MonoBehaviour
{
	// 인스펙터 노출 변수
	[SerializeField]
	private TextFade textFade;


	// 시작 초기화
	private void Start()
	{
		Queue<string> temp = new Queue<string>();

		temp.Enqueue("1. ALKDJALKasd\nfasdfasdfasdfasdfasdfDSADang");
		temp.Enqueue("2. wioenfdasfasd\nfsadfsdfsdsdfsadfjfsdf");
		temp.Enqueue("3. asfdlkdflsadlfj\nasldfjasldgjlasdgjlsadfasdjf;a");

		textFade.Initialize(temp);
	}
}
