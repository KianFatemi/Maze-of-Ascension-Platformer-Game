using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour, UIManager.ISelectable
{
   
   public void Select()
    {
        SceneManager.LoadScene("Game");
    }
   
}
