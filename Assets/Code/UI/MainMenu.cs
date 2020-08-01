using UnityEngine;
using UnityEngine.SceneManagement;
using Utilities;

/*
 * This code handles behavior in the main menu such as loading scenes and other
 * menus.
 */

namespace UI
{
    public class MainMenu : MonoBehaviour
    {
        #region Menu Buttons

        public void PlayPVE()
        {
            SceneManager.LoadScene(Constants.PVE_SCENE);
        }

        public void PlayPVP()
        {
            return;
        }

        public void ExitGame()
        {
            Debug.Log("Game exited.");
            Application.Quit();
        }

        #endregion

    }
}