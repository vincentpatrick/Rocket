using System;
using SplashKitSDK;
//using System.Collections.Generic;

public class MeteorDodge
{
    private Player _player;
    private Window _gameWindow;
    private Meteor _TestMeteor;
    public int Timer = 0;
    public bool Quit
    {
        //ASK PLAYER IF THEY'VE QUIT, RETURNING ANSWER IT GETS FROM PLAYER
        get
        {
            return _player.Quit;
        }
    }
    public MeteorDodge(Window Window, Player Player)
    {
        _gameWindow = Window;
        _player = Player;
        _TestMeteor = RandomMeteor(_player);
    }

    public void HandleInput()
    {
        _player.HandleInput();
        //stay on window
        _player.StayOnWindow(_gameWindow);
    }
    public void Draw()
    {
        _gameWindow.Clear(Color.LightBlue);
        
        _TestMeteor.Draw();
        _player.Draw();
        _gameWindow.DrawText(string.Format("Health: {0}", _player.Health),  Color.Black, "Bold", 5000, 0, 0);
        
        _gameWindow.Refresh(60);

    }
    public void Update()
    {
        // Used to update the game
        if (_player.CollidedWith(_TestMeteor) == true)
        {
            _TestMeteor = RandomMeteor(_player);
            _player.HealthReduce();
        }
 
        if (_TestMeteor.IsOffscreen(_gameWindow) == true)
        {
            _TestMeteor = RandomMeteor(_player);
            Meteor Meteor1 = new Meteor(_gameWindow, _player);
        }
         _TestMeteor.update();
         

        CheckHealth();
        
    }

    public Meteor RandomMeteor(Player _player)
    {
        Meteor Meteor1 = new Meteor(_gameWindow, _player);
        return Meteor1;
    }

    public void CheckHealth()
    {
        if(_player.Health == 0)
        {
            uint _score;
            _gameWindow.DrawText("YOU ARE DEAD",  Color.Red, "Bold", 10000000, 400, 300);
            _score=SplashKit.CurrentTicks();
             _gameWindow.DrawText(string.Format("Score: {0}", _score),  Color.Black, "Bold", 5000, 400, 200);
            _gameWindow.Refresh(60);
            SplashKit.Delay(3000);
            _gameWindow.Close();
        }
    }
}
    