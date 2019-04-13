using System;
using SplashKitSDK;
public class Player
{
    private Bitmap _PlayerBitmap =  new Bitmap("Player1", "ship2.png");
    public double X{get; private set;}
    public double Y{get; private set;}
    public bool Quit{get; private set;}

    private Window _gameWindow; 
    public int Width
    {
        get
        {
            return _PlayerBitmap.Width;
        }
    }

    public int Height
    {
        get
        {
            return _PlayerBitmap.Height;
        }
    }
    public Player(Window gameWindow)
    {
       Quit = false;
        _gameWindow = gameWindow;
        X = (_gameWindow.Width - Width)/2;
        Y = (_gameWindow.Height - Height)/2;
        
    }


    public void Draw()
    {
        _gameWindow.DrawBitmap(_PlayerBitmap, X, Y);
    }
    public void HandleInput()
    {
        int SPEED = 5;
        if(SplashKit.KeyDown(KeyCode.WKey))
        {
            Y=Y-SPEED;
        }
        if(SplashKit.KeyDown(KeyCode.SKey))
        {
            Y=Y+SPEED;
        }
        if(SplashKit.KeyDown(KeyCode.DKey))
        {
            X=X+SPEED;
        }
        if(SplashKit.KeyDown(KeyCode.AKey))
        {
            X=X-SPEED;
        }
        if(SplashKit.KeyDown(KeyCode.EscapeKey))
        {
            Quit = true;
        }
    }
    public void StayOnWindow(Window _gameWindow)
    {
        const int GAP = 10;

        if(X < GAP)
        {
            X = GAP;
        }
        if(X > (_gameWindow.Width-GAP -90))
        {
            X = _gameWindow.Width - GAP -90;
        }
        if(Y < GAP)
        {
            Y = GAP;
        }
        if(Y > (_gameWindow.Height - GAP - 90))
        {
            Y = (_gameWindow.Height - GAP - 90);
        }

    }
    
    public bool CollidedWith(Meteor _Meteor)
    {
        if((_PlayerBitmap.CircleCollision(X, Y , _Meteor.CollisionCircle)) == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    
    }


}