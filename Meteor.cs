using System;
using SplashKitSDK;
public class Meteor
{
    private Bitmap _MeteorBitmap =  new Bitmap("Meteor", "New_Piskel.gif");
    public double X{get; private set;}
    public double Y{get; private set;}
    public double Radius{get; set;} = 20;
    public Color MainColor{get; private set;}
    public Circle c;
    //Add private width and height readonly property
    private int Width
    {
        get{return 50;}
    }
    private int Height
    {
        get{return 50;}
    }
    private Vector2D Velocity {get; set;}
    
    public Circle CollisionCircle
    {
        get
        {
            return SplashKit.CircleAt(X, Y, Radius);;
        }
        
    }
    
    public Meteor(Window gameWindow, Player player)
    {
        X = 0;
        Y = 0;

        //Console.WriteLine("message");
        const int SPEED = 16;
        MainColor = Color.RandomRGB(200);

        //get a point for Meteor
    
        Point2D fromPt = new Point2D()
        {
            X = X, Y =Y
        };
        //get a point for player
        Point2D toPt = new Point2D()
        {
            X = player.X, Y = player.Y
        };
        //Calculate direction for head
        Vector2D dir;
        dir = SplashKit.UnitVector(SplashKit.VectorPointToPoint(fromPt, toPt));
        //Set the speed and assign to velocity
        Velocity = SplashKit.VectorMultiply(dir, SPEED);

        if(SplashKit.Rnd() < 0.5) //pick top bottom left or right randomly
        {
            //Y = SplashKit.Rnd(gameWindow.Height); //picked top /bottom
            X = SplashKit.Rnd(gameWindow.Width); //pick a random position from left to right
            if (SplashKit.Rnd() < 0.5)//check if we are top or bottom
                Y = -Height; //TOP
            else
                Y = gameWindow.Height; //BOTTOM
        }
        else
        {
            Y = SplashKit.Rnd(gameWindow.Height);
            if( SplashKit.Rnd() < 0.5)
                X = -Width;
            else
                X = gameWindow.Width;
        }   
    }

    public void Draw()
    { 
        SplashKit.DrawBitmap(_MeteorBitmap, X, Y);
    }
    public void update()
    {
        X = X + Velocity.X;
        Y = Y +Velocity.Y;
    }

    public bool IsOffscreen(Window screen)
    {
       if( X< -Width || X>screen.Width || Y < -Height || Y>screen.Height)
       {
           return true;
       } 
       else{
           return false;
       }
    }
}