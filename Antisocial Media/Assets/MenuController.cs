using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
	void Update()
	{
		if(Input.GetKeyDown("space"))
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene("Assets/Scenes/SampleScene.unity");
		}
	}
}
