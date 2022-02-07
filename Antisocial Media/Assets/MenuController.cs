using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{

	[SerializeField] private string nextScene;

	void Update()
	{
		if(Input.GetKeyDown("space"))
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene(nextScene);
		}
	}
}
