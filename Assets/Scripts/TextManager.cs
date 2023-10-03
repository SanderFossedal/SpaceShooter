
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public Text scoreText;
    public Text gameOverText;
    public Text upgradeCounter;
    private int score;
    private int upgradeCount;
    private int maxUpgradeCount = 8;

    private void Start()
    {
        scoreText.text = "Kills: ";
        gameOverText.text = "";
        upgradeCounter.text = $"{upgradeCount}/{maxUpgradeCount}";
    }

    private void OnEnable()
    {
        EnemyHandler.onDeath += incrementScore;
        PlayerHandler.onDeath += gameOver;
        BossHandler.onDeath += stageComplete;
        Upgrade.onUpgradeTaken += incrementUpgrade;
    }

    private void OnDisable()
    {
        EnemyHandler.onDeath -= incrementScore;
        PlayerHandler.onDeath -= gameOver;
        BossHandler.onDeath -= stageComplete;
        Upgrade.onUpgradeTaken -= incrementUpgrade;
    }

    private void incrementScore()
    {
        score++;
        scoreText.text = $"Kills: {score}";
    }

    private void gameOver()
    {
        gameOverText.text = "Game Over :(";
    }

    private void stageComplete()
    {
        StartCoroutine(waiter());
    }

    private void incrementUpgrade()
    {
        upgradeCount++;
        if(upgradeCount > maxUpgradeCount)
        {
            upgradeCount = maxUpgradeCount;
        }
        upgradeCounter.text = $"{upgradeCount}/{maxUpgradeCount}";
    }
    IEnumerator waiter()
    {
        //Wait for 1 seconds
        yield return new WaitForSeconds(1);

        gameOverText.text = "Stage Complete!";
    }

}
