using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Internal.Experimental.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class LoadSceneScript : MonoBehaviour
{

	public Button YourFirstButton;
	private bool Shift;
	
	void Start()
	{
		//Calls the TaskOnClick/TaskWithParameters/ButtonClicked method when you click the Button
		YourFirstButton.onClick.AddListener(TaskOnClick);

	}
	
	public void TaskOnClick()
	{
		//Output this to console when Button1 or Button3 is clicked
		StartCoroutine(DoFade());
		Debug.Log("You have clicked the button!");
	}
	
	/*public void Wrapper(){
		StartCoroutine(MyCoroutine());
	}
	
	private IEnumerator MyCoroutine(){
		yield return null;
	}*/

	IEnumerator DoFade(){
		CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
		while (canvasGroup.alpha > 0)
		{
			canvasGroup.alpha -= Time.deltaTime / 4;
			yield return null;
		}

		if (canvasGroup.alpha < 0.01 && !Shift)
		{
			StartCoroutine(LoadYourAsyncScene());
			Shift = true;
		}
		canvasGroup.interactable = false;
		yield return null;
	}
	
	IEnumerator LoadYourAsyncScene()
	{
		// The Application loads the Scene in the background as the current Scene runs.
		// This is particularly good for creating loading screens.
		// You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
		// a sceneBuildIndex of 1 as shown in Build Settings.

		AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Scenes/Hospital_Hall", LoadSceneMode.Single);
		AsyncOperation asyncLoad2 = SceneManager.LoadSceneAsync("Scenes/Hospital_Hall_Scene2", LoadSceneMode.Additive);
 
		//Wait until the asynchronous scene fully loads
		while (!asyncLoad.isDone)
		{
			yield return null;
		}

		while (!asyncLoad2.isDone)
		{
			yield return null;
		}
	
	}
	
	}	
	
