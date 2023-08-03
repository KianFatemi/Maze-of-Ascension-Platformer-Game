using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour, UIManager.ISelectable
{
    public void Select()
    {
        Application.Quit(1);
    }
}
