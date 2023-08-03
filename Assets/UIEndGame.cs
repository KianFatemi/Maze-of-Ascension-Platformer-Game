using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;


public class UIEndGame : MonoBehaviour
{
    public static Action<Vector2> move;
    public static Action<float> enter;  
    public static UIEndGame instance;
    public GameObject[] menuOptions;
    int selectionIndex = 0;
    bool wrapUp = false;
    bool wrapDown = true;

    UIControls actions;

    void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            actions = new UIControls();
            actions.Enable();
        }
        menuOptions = new GameObject[1];
        menuOptions[0] = GameObject.Find("Quit");
    }

    void Start()
    {
        selectionIndex = 0;
        SelectOption(selectionIndex);
    }

    public interface ISelectable
    {
        void Select();
    }

    void OnEnable()
    {
        actions.Keyboard.Up.performed += OnUpArrow;
        actions.Keyboard.Down.performed += OnDownArrow;
        actions.Keyboard.Enter.performed += OnEnter;
        actions.Keyboard.Space.performed += OnEnter;
    }

    void OnDisable()
    {
        actions.Keyboard.Up.performed -= OnUpArrow;
        actions.Keyboard.Down.performed -= OnDownArrow;
        actions.Keyboard.Enter.performed -= OnEnter;
        actions.Keyboard.Space.performed -= OnEnter;
    }

    void OnUpArrow(InputAction.CallbackContext ctx)
    {
        if (wrapUp == true)
        {
            selectionIndex--;
            SelectOption(selectionIndex);
            wrapDown = true;
            if (selectionIndex == 0)
            {
                wrapUp = false;
            }
        }

    }

    void OnDownArrow(InputAction.CallbackContext ctx)
    {
        if (wrapDown == true)
        {
            selectionIndex++;
            SelectOption(selectionIndex);
            wrapUp = true;
            if (selectionIndex == menuOptions.Length - 1)
            {
                wrapDown = false;
            }
        }
    }

    void OnEnter(InputAction.CallbackContext ctx)
    {
        if (menuOptions[selectionIndex] != null)
        {
            ISelectable selectable = menuOptions[selectionIndex].GetComponentInChildren<ISelectable>();
            if (selectable != null)
            {
                selectable.Select();
            }
        }


    }

    void SelectOption(int selectionIndex)
    {
        for (int i = 0; i < menuOptions.Length; i++)
        {
            TextMeshProUGUI text = menuOptions[i].GetComponentInChildren<TextMeshProUGUI>();
            if (i == selectionIndex)
            {
                text.color = Color.red;
            }
            else
            {
                text.color = Color.black;
            }
        }
    }
}
