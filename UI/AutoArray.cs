﻿using UnityEngine;

public class AutoArray : MonoBehaviour
{
	// 인스펙터 노출 변수
	// 일반
	[SerializeField]
	private Transform 	tile;                   	// 배치될 타일

	// 수치
	public  int 		height = 1;             	// 세로 개수
	public  int 		width = 1;              	// 가로 개수
	public  float 		gap = 0.1f;              	// 타일 사이 간격
	
	[SerializeField]
	private string 		tileName = "Tile";       	// 타일 이름
	[SerializeField]
	private bool 		isStartInit;				// 시작 초기화 사용 여부
	
	// 인스펙터 비노출 변수
	// 일반
	[HideInInspector]
	public Object[,] 	tileArray;               	// 생성된 타일 집합


	// 시작
	private void Start()
	{
		if (isStartInit)
		{
			TileInitialize();
		}
	}

	// 가로 세로 설정
	public void SetSize(int height, int width)
	{
		this.height = height;
		this.width  = width;
	}

	// 타일 초기화
	public Object[,] TileInitialize()
	{
		tileArray = new Object[height, width];

		for (int i = 0; i < height; i++)
		{
			for (int j = 0; j < width; j++)
			{
				// 타일 생성
				Transform newTile = Instantiate(tile);

				newTile.name = tileName + " " + (i + 1) + " / " + (j + 1);
				newTile.SetParent(transform);


				// 타일 배치
				RectTransform tileRect = newTile.GetComponent<RectTransform>();
				float xGap = ((1f / width * (j + 1f)) - (1f / width * j)) * gap;
				float yGap = ((1f - 1f / height * i) - (1f - 1f / height * (i + 1f))) * gap;
				
				tileRect.anchorMax = new Vector2(1f / width * (j + 1f) - xGap, 1f - 1f / height * i - yGap);
				tileRect.anchorMin = new Vector2(1f / width * j + xGap, 1f - 1f / height * (i + 1f) + yGap);
				tileRect.offsetMin = Vector2.zero;
				tileRect.offsetMax = Vector2.zero;
				
				tileArray[i, j] = newTile;
			}
		}

		return tileArray;
	}
}
