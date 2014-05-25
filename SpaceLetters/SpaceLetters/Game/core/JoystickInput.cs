using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceLetters
{

    public enum JoystickButton { A, B, X, Y, LB, RB, Select, Start, BUTTONNUM, LT,RT };

    class JoystickInput
    {
    
        bool connected;
        List<int> usedKeys;

        Vec2f leftStick;
        Vec2f rightStick;
        float LTRT;

        bool[] oldButton;
        bool[] currentButton;


        public JoystickInput()
        {

            oldButton = new bool[(int)JoystickButton.BUTTONNUM];
            currentButton = new bool[(int)JoystickButton.BUTTONNUM];

            leftStick = new Vec2f();
            
        }

        public void update()
        {
            Joystick.Update();
            for (int i = 0; i < (int)JoystickButton.BUTTONNUM; i++)
                oldButton[i] = currentButton[i];


            for (int i = 0; i < (int)JoystickButton.BUTTONNUM; i++)
                currentButton[i] = Joystick.IsButtonPressed((uint)1, (uint)i);


            rightStick = new Vec2f(Joystick.GetAxisPosition(1,Joystick.Axis.U), -Joystick.GetAxisPosition(1, Joystick.Axis.R));
            leftStick = new Vec2f(Joystick.GetAxisPosition(1, Joystick.Axis.X), -Joystick.GetAxisPosition(1, Joystick.Axis.Y));
            LTRT = Joystick.GetAxisPosition(1, Joystick.Axis.Z);

        }
        public Vec2f getLeftStick()
        {
            return leftStick;
        }
        public Vec2f getRightStick()
        {
            return rightStick;
        }
        public bool isClicked(JoystickButton button)
        {
            return currentButton[(int)button] && !oldButton[(int)button];
        }

        public bool isPressed(JoystickButton button)
        {
            if (button == JoystickButton.LT)
                return LTRT > 50;
            if (button == JoystickButton.RT)
                return LTRT < -50;

            return Joystick.IsButtonPressed((uint)1, (uint)button);
        }
        public bool isReleased(JoystickButton button)
        {
            return oldButton[(int)button] && !Joystick.IsButtonPressed((uint)1, (uint)button);
        }
    }
}
