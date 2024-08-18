using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Seesaw : MonoBehaviour
{

    public float tiltAngle = 5f;
    public float tiltSpeed = 10f;
    public float currentAngle { get; private set; }
    private bool isTiltLeft = false;
    private bool isTiltRight = false;

    public Button playButton;
    public Button optionsButton;

    public float buttonMoveDistance = 35f;
    public float buttonMoveSpeed = 5f;
    private Vector3 initialPlayPosition;
    private Vector3 initialOptionsPosition;
    private Quaternion initialPlayRotation;
    private Quaternion initialOptionsRotation;

    public int nextScene;






    void Start()
    {
        playButton.onClick.AddListener(ClickPlay);
        optionsButton.onClick.AddListener(ClickOptions);


        initialPlayPosition = playButton.transform.position;
        initialOptionsPosition = optionsButton.transform.position;

        initialPlayRotation = playButton.transform.rotation;
        initialOptionsRotation = optionsButton.transform.rotation;
    }

    void Update()
    {
        if (isTiltLeft)
        {
            currentAngle = Mathf.Lerp(currentAngle, -tiltAngle, Time.deltaTime * tiltSpeed);
        }
        else if (isTiltRight)
        {
            currentAngle = Mathf.Lerp(currentAngle, tiltAngle, Time.deltaTime * tiltSpeed);
        }
        else
        {
            currentAngle = Mathf.Lerp(currentAngle, 0f, Time.deltaTime * tiltSpeed);
        }

        transform.rotation = Quaternion.Euler(0f, 0f, currentAngle);
        playButton.transform.rotation = Quaternion.Euler(0f, 0f, currentAngle);
        optionsButton.transform.rotation = Quaternion.Euler(0f, 0f, currentAngle);

        playButton.transform.position = Vector3.Lerp(playButton.transform.position, GetTargetPosition(initialPlayPosition, isTiltLeft), Time.deltaTime * buttonMoveSpeed);
        optionsButton.transform.position = Vector3.Lerp(optionsButton.transform.position, GetTargetPosition(initialOptionsPosition, isTiltRight), Time.deltaTime * buttonMoveSpeed);
    }

    void ClickOptions()
    {
        isTiltLeft = false;
        isTiltRight = true;

        Invoke("ResetSeesaw", 0.5f);
    }

    void ClickPlay()
    {
        isTiltLeft = true;
        isTiltRight = false;

        Invoke("LoadNextScene", 0.5f);
    }

    void ResetSeesaw()
    {
        isTiltLeft = false;
        isTiltRight = false;

        playButton.transform.position = initialPlayPosition;
        optionsButton.transform.position = initialOptionsPosition;

        playButton.transform.rotation = initialPlayRotation;
        optionsButton.transform.rotation = initialOptionsRotation;
    }

    Vector3 GetTargetPosition(Vector3 initialPosition, bool isMovingDown)
    {
        return isMovingDown ? initialPosition - new Vector3(0f, buttonMoveDistance, 0f) : initialPosition + new Vector3(0f, buttonMoveDistance, 0f);
    }

    void LoadNextScene()
    {
        SceneManager.LoadSceneAsync(nextScene);
    }

}
