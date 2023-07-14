using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HitEffect : MonoBehaviour
{
    public static HitEffect instance;
    public Color targetColor; // ���� ����
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

            // �ǰ� �������� ����
            renderer.material.color = targetColor;

                transform.position = new Vector2(x, y + move_Y);
                yield return new WaitForSeconds(0.1f);

            // ���
            yield return new WaitForSeconds(hitDuration);

            // ��ġ �ǵ�����
            transform.position = new Vector2(x, y);

            // ���� �������� ����
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

        // �ǰ� �������� ����
        renderer.material.color = targetColor;

        transform.position = new Vector2(x, y + move_Y);
        yield return new WaitForSeconds(0.1f);

        // ���
        yield return new WaitForSeconds(hitDuration);

        // ���� �������� ����
        renderer.material.color = originalColor;
    }
}
