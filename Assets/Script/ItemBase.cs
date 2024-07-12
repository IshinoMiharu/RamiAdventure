using UnityEngine;

/// <summary>
/// アイテムを制御する基底クラス
/// アイテムの共通機能を実装する
/// </summary>
[RequireComponent(typeof(Collider2D))]
public abstract class ItemBase : MonoBehaviour
{
    /// <summary>アイテムを取った時に鳴る効果音</summary>
    [Tooltip("アイテムを取った時に鳴らす効果音")]
    [SerializeField] AudioClip _sound = default;
    /// <summary>アイテムの効果をいつ発揮するか</summary>
    [Tooltip("trueだとラミィが取った時に効果が発動する。falsだとゼリーマがとった時に発動する")]
    [SerializeField] bool UsePlayer = true;
    //   [SerializeField] GameObject Player;
    //private PlatformerPlayerController2D Playerbuh;
    /// <summary>
    /// アイテムが発動する効果を実装する
    /// </summary>
    public abstract void Activate();

    //{
    //    Debug.LogError("派生クラスでメソッドをオーバーライドしてください。");
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player") && UsePlayer)
        {
            if (_sound)
            {
                AudioSource.PlayClipAtPoint(_sound, Camera.main.transform.position);
            }

            if (UsePlayer)
            {
                Activate();
                Destroy(this.gameObject);
            }

        }
        if (collision.gameObject.tag.Equals("Zerima") && !UsePlayer)
        {
            if (_sound)
            {
                AudioSource.PlayClipAtPoint(_sound, Camera.main.transform.position);
            }

            else if (!UsePlayer)
            {
                Activate();
                Destroy(this.gameObject);
            }
        }
    }


}
