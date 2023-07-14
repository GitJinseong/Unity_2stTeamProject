using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HitEffect : MonoBehaviour
{
    public static HitEffect instance;
    public Color targetColor; // 색상 지정
    public Color originalColor;
    private float hitDuration = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void RunSetEnemyHitEffect(Renderer renderer, Transform transform)
    {
        StartCoroutine(SetEnemyHitEffect(renderer, transform));
    }

    public IEnumerator SetEnemyHitEffect(Renderer renderer, Transform transform)
    {
            float x = transform.position.x;
            float y = transform.position.y;
            float move_Y = 0.3f;

            // 피격 색상으로 변경
            renderer.material.color = targetColor;

                transform.position = new Vector2(x, y + move_Y);
                yield return new WaitForSeconds(0.1f);

            // 대기
            yield return new WaitForSeconds(hitDuration);

            // 위치 되돌리기
            transform.position = new Vector2(x, y);

            // 원래 색상으로 변경
            renderer.material.color = originalColor;
    }

    public void RunSetPlayerHitEffect(Renderer renderer, Transform transform)
    {
        StartCoroutine(SetPlayerHitEffect(renderer, transform));
    }

    public IEnumerator SetPlayerHitEffect(Renderer renderer, Transform transform)
    {
        float x = transform.position.x;
        float y = transform.position.y;
        float move_Y = 0.3f;

        // 피격 색상으로 변경
        renderer.material.color = targetColor;

        transform.position = new Vector2(x, y + move_Y);
        yield return new WaitForSeconds(0.1f);

        // 대기
        yield return new WaitForSeconds(hitDuration);

        // 원래 색상으로 변경
        renderer.material.color = originalColor;
    }
}
