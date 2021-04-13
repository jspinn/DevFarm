using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TodoTrigger : MonoBehaviour
{
    public TODOLIST tODOLIST; 

    public void TriggerToDo ()
    {
        FindObjectOfType<ToDoManager>().StartToDo(tODOLIST);
    }
}

