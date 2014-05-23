using SFML.Window;
using System;


/// <summary>
/// Represents mouse. Just call update() every tick once (at the beginning).
/// </summary>
class MouseInput
{
    bool[] oldMouse;
    bool[] currentMouse;

    Vector2i oldMousePos;
    Vector2i currentMousePos;

    Window relativeWindow;

    public MouseInput(Window relativeWindow = null)
    {
        oldMouse = new bool[(int)Mouse.Button.ButtonCount];
        currentMouse = new bool[(int)Mouse.Button.ButtonCount];
        this.relativeWindow = relativeWindow;
    }

    public void update()
    {
        oldMousePos = currentMousePos;
        currentMousePos = Mouse.GetPosition(relativeWindow);

        for (int i = 0; i < oldMouse.Length; i++)
            oldMouse[i] = currentMouse[i];

        //update every mouseKey:
        for (int i = 0; i < oldMouse.Length; i++)
            currentMouse[i] = Mouse.IsButtonPressed((Mouse.Button)i);
    }

    public Vector2f getMousePos()
    {
        return new Vector2f(currentMousePos.X, currentMousePos.Y);
    }

    public Vector2f getOldMousePos()
    {
        return new Vector2f(oldMousePos.X, oldMousePos.Y); ;
    }

    /// <summary>
    /// Returns the direction the mouse was moved to.
    /// </summary>
    /// <returns>CurrentMousePosition - OldMousePosition.</returns>
    public Vector2f getMouseDirection()
    {
        return new Vector2f(currentMousePos.X - oldMousePos.X, currentMousePos.Y - oldMousePos.Y);
    }


    /// <summary>
    /// Checks if the left mouse button was clicked (presser right now and not pressed last tick).
    /// </summary>
    /// <returns>True if the left mouse button was clicked.</returns>
    public bool leftClicked()
    {
        return !oldMouse[(int)Mouse.Button.Left] && currentMouse[(int)Mouse.Button.Left];
    }

    /// <summary>
    /// Checks if the left mouse button is pressed.
    /// </summary>
    /// <returns>True if the left button is pressed right now.</returns>
    public bool leftPressed()
    {
        return currentMouse[(int)Mouse.Button.Left];
    }

    /// <summary>
    /// Checks if the left mouse button was released (not pressed right now and pressed last tick).
    /// </summary>
    /// <returns>True if the left mouse button is released, false otherwise.</returns>
    public bool leftReleased()
    {
        return oldMouse[(int)Mouse.Button.Left] && !currentMouse[(int)Mouse.Button.Left];
    }



    /// <summary>
    /// Checks if the right mouse button was clicked this tick (pressed right now and not pressed last tick).
    /// </summary>
    /// <returns>True if the right mouse button is clicked, false otherwise.</returns>
    public bool rightClicked()
    {
        return !oldMouse[(int)Mouse.Button.Right] && currentMouse[(int)Mouse.Button.Right];
    }

    /// <summary>
    /// Checks if the right mouse button is pressed this tick (pressed right now).
    /// </summary>
    /// <returns>True if the right mouse button is pressed, false otherwise.</returns>
    public bool rightPressed()
    {
        return currentMouse[(int)Mouse.Button.Right];
    }

    /// <summary>
    /// Checks if the right mouse button was released this tick (not pressed right now and pressed last tick).
    /// </summary>
    /// <returns>True if the right mouse button is released, false otherwise.</returns>
    public bool rightReleased()
    {
        return oldMouse[(int)Mouse.Button.Right] && !currentMouse[(int)Mouse.Button.Right];
    }

    /// <summary>
    /// Checks if the middle mouse button was clicked this tick (pressed right now and not pressed last tick).
    /// </summary>
    /// <returns>True if the middle mouse button is clicked, false otherwise.</returns>
    public bool midClicked()
    {
        return !oldMouse[(int)Mouse.Button.Middle] && currentMouse[(int)Mouse.Button.Middle];
    }

    /// <summary>
    /// Checks if the middle mouse button was was pressed this tick (pressed right now).
    /// </summary>
    /// <returns>True if the middle mouse button is pressed, false otherwise.</returns>
    public bool midPressed()
    {
        return currentMouse[(int)Mouse.Button.Middle];
    }

    /// <summary>
    /// Checks if the middle mouse button was released this tick (not pressed right now and pressed last tick).
    /// </summary>
    /// <returns>True if the middle mouse button was released this tick, false otherwise.</returns>
    public bool midReleased()
    {
        return oldMouse[(int)Mouse.Button.Middle] && !currentMouse[(int)Mouse.Button.Middle];
    }

    /// <summary>
    /// Checks if the mouse wheel is scrolled up.
    /// </summary>
    /// <returns>True if the mouse wheel was scrolled up this tick.</returns>
    public bool mouseWheelUp()
    {
        return Template.AbstractGame.wheelDelta == 1;
    }

    /// <summary>
    /// Checks if the mouse wheel was scrolled down.
    /// </summary>
    /// <returns>True if the mouse wheel was scrolled down this tick.</returns>
    public bool mouseWheelDown()
    {
        return Template.AbstractGame.wheelDelta == -1;
    }
}

