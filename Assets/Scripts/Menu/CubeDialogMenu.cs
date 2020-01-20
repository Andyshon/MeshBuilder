using UnityEngine;

namespace Menu
{
    public class CubeDialogMenu : MonoBehaviour
    {
        private Rect _windowRect = new Rect ((Screen.width - 200)/2, (Screen.height - 90)/2, 150, 90);
        private bool _show = false;

        void OnGUI () 
        {
            if (Event.current.Equals(Event.KeyboardEvent("M")))
            {
                Open();
            }
            if(_show)
                _windowRect = GUI.Window (0, _windowRect, DialogWindow, "Build a Cube");
        }

        void DialogWindow (int windowId)
        {
            float y = 25;
            // GUI.Label(new Rect(5, y, _windowRect.width, 20), "1 or 2 levels");

            if(GUI.Button(new Rect(10, y, _windowRect.width - 20, 20), "One level"))
            {
                _show = false;
                CubeManager.DrawCube(1);
            }

            y = 55;
            if(GUI.Button(new Rect(10,y, _windowRect.width - 20, 20), "Two levels"))
            {
                _show = false;
                CubeManager.DrawCube(2);
            }
        }

        // To open the dialogue from outside of the script.
        private void Open()
        {
            Debug.Log("Open");
            _show = true;
        }
    }
}