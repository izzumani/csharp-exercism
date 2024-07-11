using System;

class RemoteControlCar
{
    private int BatteryPercentage {get;set;} =100;
    private int Meters {get;set;} =0;
    private int _speed {get;set;}
    private int _batteryDrain {get;set;}

    public RemoteControlCar(int speed, int batteryDrain)
    {
        _speed = speed;
        _batteryDrain = batteryDrain;
    }

    public bool BatteryDrained()
    {
    
        return (BatteryPercentage >0 && BatteryPercentage >=_batteryDrain  )? false:true;
    }

    public int DistanceDriven()
    {
        return Meters;
    }

    public void Drive()
    {
            if(BatteryDrained() ==false)
            {
                Meters += _speed;
                BatteryPercentage -=_batteryDrain;       
                
            }
    }

    public static RemoteControlCar Nitro()
    {
        return new RemoteControlCar(50,4);
    }
}

class RaceTrack
{
    private int _distance  {get;set;}
    public RaceTrack(int distance)
    {
        _distance = distance;
    }

    public bool TryFinishTrack(RemoteControlCar car)
    {
        int remainingDistance =_distance;
        bool finished = true;
        while(remainingDistance > 0)
        {
            car.Drive();
            int distanceCovered = car.DistanceDriven();
            remainingDistance =_distance-distanceCovered;
            
            if(car.BatteryDrained()==true && remainingDistance > 0)
            {
                finished= false;
                break;
            }
          
        }
        return finished;
    }
}

