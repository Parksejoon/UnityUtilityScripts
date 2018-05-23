using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class AlphaMask : MonoBehaviour
	{
		// 인스펙터 노출 변수
		// 수치
		public float 		defaultAlpha = 1f;			// 알파
		
		// 인스펙터 비노출 변수
		// 일반
		private Image[] 	imageArray;
		private Text[] 		textArray;

		
		// 초기화
		private void Awake()
		{
			imageArray = GetComponentsInChildren<Image>();
			textArray  = GetComponentsInChildren<Text>();
		}
		
		// 시작
		private void Start()
		{
			SetAlpha(defaultAlpha);
		}

		// 알파 설정
		public void SetAlpha(float alpha)
		{
			Color newColor;
				
			
			foreach (Image target in imageArray)
			{
				newColor = target.color;
				newColor.a = alpha;
				
				target.color = newColor;
			}

			foreach (Text target in textArray)
			{
				newColor = target.color;
				newColor.a = alpha;

				target.color = newColor;
			}
		}
	}
}
