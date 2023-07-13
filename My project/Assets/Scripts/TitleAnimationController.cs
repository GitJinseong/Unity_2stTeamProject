using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleAnimationController : MonoBehaviour
{
    public Animator animator;
    public float delayBeforeStart = 3f;
    public float duration = 4.5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlayAnimation());
    }

    private IEnumerator PlayAnimation()
    {
        animator.StopPlayback();
        while (true)
        {
            // �ִϸ��̼� ��� ���� ���
            yield return new WaitForSeconds(delayBeforeStart);
            
            // �ִϸ��̼� ���
            animator.Play("ThunderAnimation");
            Debug.Log("A");

            // �ִϸ��̼� ��� �� ���
            yield return new WaitForSeconds(duration);

            // �ִϸ��̼� ����
            animator.StopPlayback();
            Debug.Log("B");

        }
    }
}
