using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.Events;
using TMPro;
using UnityEngine.SceneManagement;

public class ErrorHandler : MonoBehaviour
{
    public static ErrorHandler Instance;
    public GameObject errorhandlerPrefab;
    public GameObject errorhandlerinstance;
    [SerializeField] Transform errorhandlerUIParent;
    
    public UnityAction calltoAction;

    private void Start()
    {
        
    }
    private void OnEnable()
    {
        calltoAction += OnCLickCallTOActionButton;
    }
    private void OnDisable()
    {
        calltoAction -= OnCLickCallTOActionButton;
    }
    private void Awake()
    {
        Instance = this;
    }
    public void InstantiateErrorHandlerUI(string title, string desctext, string actionText, bool haveAction, int timeleft)
    {
        if(GameObject.FindGameObjectWithTag("Error Handler Prefab") == null)
        {
            errorhandlerinstance = Instantiate(errorhandlerPrefab, errorhandlerUIParent);

        }
        if(errorhandlerinstance != null)
        {
            errorhandlerinstance.GetComponent<ErrorHandlerUI>().titleText.text = title;
            errorhandlerinstance.GetComponent<ErrorHandlerUI>().errorText.text = desctext;
            if (haveAction)
            {
                errorhandlerinstance.GetComponent<ErrorHandlerUI>().calltoactionButton.SetActive(true);
                if (actionText == "OKAY")
                {
                    Debug.Log("actionText is " + actionText);
                    errorhandlerinstance.GetComponent<ErrorHandlerUI>().calltoactionButton.GetComponent<Button>().onClick.AddListener(OnCLickCallTOActionButton);

                }
                else if (actionText == "GO")
                {
                    errorhandlerinstance.GetComponent<ErrorHandlerUI>().calltoactionButton.GetComponent<Button>().onClick.AddListener(OnCLickGo);
                }
                else
                {

                }
                errorhandlerinstance.GetComponent<ErrorHandlerUI>().timerCircle.SetActive(false);
                errorhandlerinstance.GetComponent<ErrorHandlerUI>().calltoactionButton.transform.GetChild(0).GetComponent<TMP_Text>().text = actionText;

            }
            else
            {
                errorhandlerinstance.GetComponent<ErrorHandlerUI>().calltoactionButton.SetActive(false);
                errorhandlerinstance.GetComponent<ErrorHandlerUI>().timerCircle.SetActive(true);
                errorhandlerinstance.GetComponent<ErrorHandlerUI>().timeLeftText.text = timeleft.ToString();

            }
        }
        
    }

    public void OnCLickCallTOActionButton( )
    {
        Destroy(errorhandlerinstance.gameObject);
    }

    public void OnCLickGo()
    {
        SceneManager.LoadScene(1);
    }
}
