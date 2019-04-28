using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    private Player player;
    private string id;

    private void Start()
    {
        player = Builder.FindGameObject<Player>("Player");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void Switch(string id, string scene)
    {
        this.id = id;

        if(scene != null && scene != "")
            SceneManager.LoadScene(scene);
        else Warp();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Warp();
    }

    private void Warp()
    {

        Debug.Log("" + id + "..." +
        SceneManager.GetActiveScene().name);

        GameObject target = GameObject.FindGameObjectsWithTag("Gate")
             .Where(value => value.GetComponent<GateRegion>() != null)
             .FirstOrDefault(value => value.GetComponent<GateRegion>().ID == id);


        foreach (var item in GameObject.FindGameObjectsWithTag("Gate"))
        {
            GateRegion r = item.GetComponent<GateRegion>();
            if (r != null) Debug.Log(r.ID);
        }

        player.transform.position = target.transform.position;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
