using UnityEngine;

/// <summary>
/// Holds information about the controller.
/// </summary>
public class Controller
{
    private static string leftStickX = "";
    public static string LeftStickX{get{return leftStickX;}}

    private static string leftStickY = "";
    public static string LeftStickY{get{return leftStickY;}}

    private static string rightStickX = "";
    public static string RightStickX{get{return rightStickX;}}

    private static string rightStickY = "";
    public static string RightStickY{get{return rightStickY;}}

    private static string target = "";
    public static string Target{get{return target;}}

    private static string attack = "";
    public static string Attack{get{return attack;}}

    private static string run = "";
    public static string Run{get{return run;}}

    private static string submit = "";
    public static string Submit{get{return submit;}}

    private static string cancel = "";
    public static string Cancel{get{return cancel;}}

    public static void setController(ControllerType controller, OperationSystem os)
    {
        if (os == OperationSystem.mac)
        {
            if (controller == ControllerType.playstation)
            {
                leftStickX = "psLeftStickXMac";
                leftStickY = "psLeftStickYMac";
                rightStickX = "psRightStickXMac";
                rightStickY = "psRightStickYMac";
                target = "psTargetMac";
                attack = "psAttackMac";
                run = "psRunMac";
                submit = "psSubmitMac";
                cancel = "psCancelMac";
                return;
            }

            if (controller == ControllerType.xbox)
            {
                leftStickX = "xboxLeftStickXMac";
                leftStickY = "xboxLeftStickYMac";
                rightStickX = "xboxRightStickXMac";
                rightStickY = "xboxRightStickYMac";
                target = "xboxTargetMac";
                attack = "xboxAttackMac";
                run = "xboxRunMac";
                submit = "xboxSubmitMac";
                cancel = "xboxCancelMac";
                return;
            }

            if (controller == ControllerType.none)
            {
                leftStickX = "keyboardLeftStickX";
                leftStickY = "keyboardLeftStickY";
                rightStickX = "keyboardRightStickX";
                rightStickY = "keyboardRightStickY";
                target = "keyboardTarget";
                attack = "keyboardAttack";
                run = "keyboardRun";
                submit = "keyboardSubmit";
                cancel = "keyboardCancel";
                return;
            }
        }

        if (os == OperationSystem.windows)
        {
            if (controller == ControllerType.playstation)
            {
                leftStickX = "psLeftStickXWin";
                leftStickY = "psLeftStickYWin";
                rightStickX = "psRightStickXWin";
                rightStickY = "psRightStickYWin";
                target = "psTargetWin";
                attack = "psAttackWin";
                run = "psRunWin";
                submit = "psSubmitWin";
                cancel = "psCancelWin";
                return;
            }

            if (controller == ControllerType.xbox)
            {
                leftStickX = "xboxLeftStickXWin";
                leftStickY = "xboxLeftStickYWin";
                rightStickX = "xboxRightStickXWin";
                rightStickY = "xboxRightStickYWin";
                target = "xboxTargetWin";
                attack = "xboxAttackWin";
                run = "xboxRunWin";
                submit = "xboxSubmitWin";
                cancel = "xboxCancelWin";
                return;
            }

            if (controller == ControllerType.none)
            {
                leftStickX = "keyboardLeftStickX";
                leftStickY = "keyboardLeftStickY";
                rightStickX = "keyboardRightStickX";
                rightStickY = "keyboardRightStickY";
                target = "keyboardTarget";
                attack = "keyboardAttack";
                run = "keyboardRun";
                submit = "keyboardSubmit";
                cancel = "keyboardCancel";
                return;
            }
        }
    }
}