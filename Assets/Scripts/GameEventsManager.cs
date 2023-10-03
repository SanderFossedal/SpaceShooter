using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEventsManager : MonoBehaviour
{

    private bool isSpawned = false;
    [SerializeField] private Rigidbody2D rb2d;
    private void OnEnable()
    {
        PlayerHandler.onDeath += playerDeath;
        BossHandler.onDeath += bossDeath;
        Enemy_Spawn.enemySpawnFinished += spawnBoss;
    }

    private void OnDisable()
    {
        PlayerHandler.onDeath -= playerDeath;
        BossHandler.onDeath -= bossDeath;
        Enemy_Spawn.enemySpawnFinished -= spawnBoss;
    }

    private void playerDeath()
    {
        StartCoroutine(playerDeathWaiter());
    }

    private void bossDeath()
    {
        StartCoroutine(bossDeathWaiter());
       
    }

    private void spawnBoss()
    {
        if(isSpawned == false)
        {
            isSpawned = true;
            Instantiate(Resources.Load("Boss_1") as GameObject, new Vector2(0, 0), Quaternion.identity);
        }
        
    }

    IEnumerator bossDeathWaiter()
    {
        Spawn_Bullets script = FindObjectOfType<Spawn_Bullets>();
        //PlayerHandler player = FindObjectOfType<PlayerHandler>();
        //rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
        //rb2d.AddForce(Vector2.up * Time.deltaTime * 2);
        yield return new WaitForSeconds(2);

        Boundaries.screenBounds = new Vector3(Screen.width, Screen.height + 10, Camera.main.transform.position.z);
       

        
        //player.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 2);
        script.CancelInvoke();

        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Menu");

    }

    IEnumerator playerDeathWaiter()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Menu");
    }
}
