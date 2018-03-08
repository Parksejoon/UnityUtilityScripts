using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	// 인스펙터 노출 변수
	// 일반
	[SerializeField]
	private AudioSource audioSource;            // 해당 오디오 소스
	[SerializeField]
	private AudioClip[] audioClip;				// 오디오 클립의 모음

	// 수치


	// 해당 인덱스의 소리 재생
	public bool StartAudio(int index)
	{
		// 오버 인덱싱
		if (index >= audioClip.Length)
		{
			return false;
		}

		// 초기화
		AudioClip targetClip = audioClip[index];

		// 존재하지 않는 인덱스
		if (targetClip == null)
		{
			return false;
		}





		return true;
	}
}
