using System;
using SplashKitSDK;

public class Program
{
    public static void Main()
    {
        Window gameWindow = new Window("Game Window",800, 600);
        Player Player1 = new Player(gameWindow);
        MeteorDodge Dodge1 =new MeteorDodge(gameWindow, Player1);
        while(!gameWindow.CloseRequested)
        {
            SplashKit.ProcessEvents();

            
            Dodge1.HandleInput();
            Dodge1.Update();
            Dodge1.Draw();

            
        } 
        gameWindow.Close();
    }

}
