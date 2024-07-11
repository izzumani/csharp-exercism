using System;

class RemoteControlCar
{
    
    private static int Meter{get;set;}
    private static int Battery{get;set;}

    public RemoteControlCar()
    {
         Meter = 0;
        Battery = 100;
    }
  
    public static RemoteControlCar Buy()
    {
       
        return new RemoteControlCar();
    }

    public string DistanceDisplay()
    {
        return $"Driven {Meter} meters";
    }

    public string BatteryDisplay()
    {
        if(Battery <=0)
        {
            return "Battery empty";
        }
        return $"Battery at {Battery}%";
    }

    public void Drive()
    {
        if(Battery > 0)
        {
             Meter +=20;
            Battery -= 1;   
        }
         
   
    }
}
