using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToDoManager : MonoBehaviour
{
    public Text todoText;
    public Text taskText;

    public Animator animator;
    private Queue<string> tasks;
    void Start()
    {
        tasks = new Queue<string>();
    }

    public void StartToDo(TODOLIST tODOLIST)
    {
        animator.SetBool("IsOpen", true);

        todoText.text = tODOLIST.toDO;

        tasks.Clear();

        foreach(string sentence in tODOLIST.tasks)
        {
            tasks.Enqueue(sentence);
        }
        Display();
    }

    public void Display()
    {
        if(tasks.Count == 0)
        {
            End();
            return;
        }

        string sentence = tasks.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }
    
    
    IEnumerator TypeSentence (string sentence)
    {
        taskText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            taskText.text += letter;
            yield return null;
        }
    }
    void End()
    {
        animator.SetBool("IsOpen", false);
    }

}
