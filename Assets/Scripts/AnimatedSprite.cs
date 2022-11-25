using UnityEngine;

public class AnimatedSprite : MonoBehaviour
{
    public Sprite[] sprites;
    
    private SpriteRenderer spriteRenderer;
    private int _frame;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        Invoke(nameof(Animate), 0f);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void Animate()
    {
        _frame++;
        if(_frame >= sprites.Length)
        {
            _frame = 0;
        }
        if(_frame >= 0 && _frame < sprites.Length) spriteRenderer.sprite = sprites[ _frame ];

        Invoke(nameof(Animate), 1f / GameManager.instance.gameSpeed); 
    }
}
