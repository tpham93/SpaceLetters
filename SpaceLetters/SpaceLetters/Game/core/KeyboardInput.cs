using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Represents keyboard. Just call update() every tick once (at the beginning).
/// </summary>
public class KeyboardInput
{
    List<Keyboard.Key> usedKeys;

    bool[] oldKeys;
    bool[] currentKeys;


    /// <summary>
    /// Sets up the input. Note: this class DOES NOT check every key, only the keys, that are given here.
    /// </summary>
    /// <param name="keys">Which keys should be used (and updated correctly).</param>
    public KeyboardInput(List<Keyboard.Key> keys)
    {
        this.usedKeys = keys;

        oldKeys = new bool[(int)Keyboard.Key.KeyCount];
        currentKeys = new bool[(int)Keyboard.Key.KeyCount];
    }

    /// <summary>
    /// Checks every mouseButton and every used key (that were given within the constructor) if pressed.
    /// </summary>
    public void update()
    {
        foreach(Keyboard.Key key in usedKeys)
            oldKeys[(int)key] = currentKeys[(int)key];

        //update every Key that is needed:
        foreach (Keyboard.Key key in usedKeys)
            currentKeys[(int)key] = Keyboard.IsKeyPressed(key);
    }

    /// <summary>
    /// If the given key is clicked (pressed right NOW and NOT pressed last tick).
    /// </summary>
    /// <param name="key">Which key to be checked.</param>
    /// <returns>True if key is clicked, false otherwise.</returns>
    public bool isClicked(Keyboard.Key key)
    {
        return currentKeys[(int)key] && !oldKeys[(int)key];
    }
    
    /// <summary>
    /// If the given key is pressed right NOW.
    /// </summary>
    /// <param name="key">Which key to be checked.</param>
    /// <returns>True if the given key is pressed, false otherwise.</returns>
    public bool isPressed(Keyboard.Key key)
    {
        return Keyboard.IsKeyPressed(key);
    }

    /// <summary>
    /// Checks if the given key is released. (Not pressed right now and pressed last tick).
    /// </summary>
    /// <param name="key">Which key to be checked.</param>
    /// <returns></returns>
    public bool isReleased(Keyboard.Key key)
    {
        return oldKeys[(int)key] && !Keyboard.IsKeyPressed(key);
    }
}

