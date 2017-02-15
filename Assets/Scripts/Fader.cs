
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Fader : MonoBehaviour
{
    public float fadeSpeed = 1.5f;            // Speed that the screen fades to and from black.
    private bool sceneStarting = true;     // Whether or not the scene is still fading in.
    private GUITexture guitex;

    void Awake()
    {
        guitex = GetComponent<GUITexture>();
        guitex.enabled = true;
        // Set the texture so that it is the the size of the screen and covers it.
        guitex.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
    }


    void Update()
    {
        // If the scene is starting...
        if (sceneStarting)
            // ... call the StartScene function.
            StartScene();
    }


    void FadeToClear()
    {
        // Lerp the colour of the texture between itself and transparent.
        guitex.color = Color.Lerp(guitex.color, Color.clear, fadeSpeed * Time.deltaTime);
    }


    void FadeToBlack()
    {
        // Lerp the colour of the texture between itself and black.
        guitex.color = Color.Lerp(guitex.color, Color.black, 0.5f * Time.deltaTime);
    }


    void StartScene()
    {
        // Fade the texture to clear.
        FadeToClear();

        // If the texture is almost clear...
        if (guitex.color.a <= 0.05f)
        {
            // ... set the colour to clear and disable the GUITexture.
            guitex.color = Color.clear;
            guitex.enabled = false;

            // The scene is no longer starting.
            sceneStarting = false;
        }
    }


    public void EndScene()
    {
        // Make sure the texture is enabled.
        guitex.enabled = true;

        // Start fading towards black.
        FadeToBlack();

        // If the screen is almost black...
        if (guitex.color.a >= 0.95f)
        {
            // ... reload the level.
            Application.LoadLevel(1);
        }
    }
}