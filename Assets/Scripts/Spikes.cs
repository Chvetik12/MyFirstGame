using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spikes : MonoBehaviour
{
    [SerializeField] private Ui_Life Uilife;
    private int life;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "spikes")
        {
            life -= 1;
            //Uilife.RemuveLife();

            //if (life == 0)
            //{
            //    var currentSceneIndex = SceneManager.GetActiveScene().buildIndex
            //   SceneManager.LoadScene(currentSceneIndex);
            //}
        }
    }
}

    //    if (сollision.collider.tag == "spikes")
    //    {
    //        DecreaseHP();
    //    }
    //private void DecreaseHP()
    //    {
    //        life--;
    //        Uilife.RemuveLife();
    //        if (life == 0)
    //        {

    //            //щоб сцена поточна ПОВЕРНЕННЯ було не з1ї
    //            var currentSceneIndex = SceneManager.GetActiveScene().buildIndex
    //            SceneManager.LoadScene(currentSceneIndex);
    //        }
    //    }


