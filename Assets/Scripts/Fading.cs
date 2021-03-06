﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Fading : MonoBehaviour {

	public Texture2D fadeOutTexture;	// the texture that will overlay the screen. This can be a black image or a loading graphic
	public float fadeSpeed = 0.8f;      // the fading speed
    public string nextSceneName = "level*";
    private int drawDepth = -1000;		// the texture's order in the draw hierarchy: a low number means it renders on top
	private float alpha = 1.0f;			// the texture's alpha value between 0 and 1
	private int fadeDir = -1;           // the direction to fade: in = -1 or out = 1

    




    void OnGUI()
	{
		// fade out/in the alpha value using a direction, a speed and Time.deltaTime to convert the operation to seconds
		alpha += fadeDir * fadeSpeed * Time.deltaTime;
		// force (clamp) the number to be between 0 and 1 because GUI.color uses Alpha values between 0 and 1
		alpha = Mathf.Clamp01(alpha);
		
		// set color of our GUI (in this case our texture). All color values remain the same & the Alpha is set to the alpha variable
		GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);
		GUI.depth = drawDepth;																// make the black texture render on top (drawn last)
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);		// draw the texture to fit the entire screen area
	}
	
	// sets fadeDir to the direction parameter making the scene fade in if -1 and out if 1
	public float BeginFade (int direction)
	{
		fadeDir = direction;
		return (fadeSpeed);
	}
	
	// OnLevelWasLoaded is called when a level is loaded. It takes loaded level index (int) as a parameter so you can limit the fade in to certain scenes.
	void OnSceneLoaded()
	{
		// alpha = 1;		// use this if the alpha is not set to 1 by default
		BeginFade(-1);		// call the fade in function
	}


    

	IEnumerator ChangeTo(string SceneName){
		float fadeTime = BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
        SceneManager.LoadScene(SceneName, LoadSceneMode.Single);
	}


    IEnumerator ChangeToNext()
    {
        float fadeTime = BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
    }

    IEnumerator ResetCurrentScene()
    {
        float fadeTime = BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }
     
    public void ChangeToScene(string SceneName)
    {
		Time.timeScale = 1.0f;
		StartCoroutine (ChangeTo (SceneName));
	}

    public void changeToNextScene()
    {
        Time.timeScale = 1.0f;
        StartCoroutine(ChangeToNext());
    }

    public void resetCurrentScene()
    {
        Time.timeScale = 1.0f;
        StartCoroutine(ResetCurrentScene());
    }

    
    public void QuitGame()
    {
        Application.Quit();
    }
}
