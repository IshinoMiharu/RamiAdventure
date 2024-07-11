using UnityEngine;

public class MiheiruCoin : ItemBase
{
    public int coinValue = 1;
    public string coinID;

    private void Start()
    {
        if (ScoreManager.instance.HasCollectedCoin(coinID))
        {
            Destroy(gameObject); // Šù‚ÉûW‚³‚ê‚½ƒRƒCƒ“‚Í”j‰ó‚·‚é
        }
    }


    public override void Activate()
    {
        ScoreManager.instance.AddScore(coinValue, coinID);
    }
}
