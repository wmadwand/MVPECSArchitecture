using UnityEngine;

public class UIView : IUserInterfaceView
{
    private readonly Screens _screens;

    public UIView(Screens screens)
    {
        _screens = screens;
    }

    //TODO: apply Demeter Law
    public Vector2 TouchPosition => _screens.HUD.TouchScreen.TouchPosition;

    void IUserInterfaceView.Update(int score, float distance)
    {
        _screens.HUD.ScorePanel.UpdateView(score, distance);
    }
}
