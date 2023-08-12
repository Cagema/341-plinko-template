using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickListener : MonoBehaviour
{
	private void Update()
	{
		if (GameManager.Single.GameActive)
		{
			if (Input.GetMouseButtonDown(0))
			{
				Vector2 mousePos = GameManager.Single.MainCamera.ScreenToWorldPoint(Input.mousePosition);

				GameManager.Single.Spawn(mousePos);
			}
		}
	}
}
