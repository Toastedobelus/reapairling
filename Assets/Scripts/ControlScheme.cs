using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ControlScheme
{
    bool checkUp();
    bool checkDown();
    bool checkLeft();
    bool checkRight();
    bool checkJump();
    bool checkInteraction();
}

public class WASDControlScheme : ControlScheme
{
    public bool checkUp()
    {
        if (Input.GetKey(KeyCode.W))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool checkDown()
    {
        if (Input.GetKey(KeyCode.S))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool checkLeft()
    {
        if (Input.GetKey(KeyCode.A))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool checkRight()
    {
        if (Input.GetKey(KeyCode.D))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool checkJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool checkInteraction()
    {
        if (Input.GetKeyDown(KeyCode.CapsLock))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

public class ArrowKeysControlScheme : ControlScheme
{
    public bool checkUp()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool checkDown()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool checkLeft()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool checkRight()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool checkJump()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool checkInteraction()
    {
        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

public class IJKLControlScheme : ControlScheme
{
    public bool checkUp()
    {
        if (Input.GetKey(KeyCode.I))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool checkDown()
    {
        if (Input.GetKey(KeyCode.K))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool checkLeft()
    {
        if (Input.GetKey(KeyCode.J))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool checkRight()
    {
        if (Input.GetKey(KeyCode.L))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool checkJump()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool checkInteraction()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
public class NumpadControlScheme : ControlScheme
{
    public bool checkUp()
    {
        if (Input.GetKey(KeyCode.Keypad5))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool checkDown()
    {
        if (Input.GetKey(KeyCode.Keypad6))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool checkLeft()
    {
        if (Input.GetKey(KeyCode.Keypad3))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool checkRight()
    {
        if (Input.GetKey(KeyCode.Keypad9))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool checkJump()
    {
        if (Input.GetKeyDown(KeyCode.KeypadPeriod))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool checkInteraction()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
