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
            // 애니메이션 재생 전에 대기
            yield return new WaitForSeconds(delayBeforeStart);
            
            // 애니메이션 재생
            animator.Play("ThunderAnimation");
            Debug.Log("A");

            // 애니메이션 재생 후 대기
            yield return new WaitForSeconds(duration);

            // 애니메이션 정지
            animator.StopPlayback();
            Debug.Log("B");

        }
    }
}
