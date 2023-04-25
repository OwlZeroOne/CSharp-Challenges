using System;

/*
    In this exercise you'll be organizing races between various types of remote controlled cars. Each car has its own speed and battery drain characteristics.

    Cars start with full (100%) batteries. Each time you drive the car using the remote control, it covers the car's speed in meters and decreases the remaining battery percentage by its battery drain.

    If a car's battery is below its battery drain percentage, you can't drive the car anymore.

    Each race track has its own distance. Cars are tested by checking if they can finish the track without running out of battery.

    You have six tasks, each of which will work with remote controller car instances.
*/
class RemoteControlCar2
{
    private int speed, batteryDrain, meters, battery;
    /*
        Allow creating a remote controller car by defining a constructor for the RemoteControlCar class that takes the speed of the car in meters and the battery drain percentage as its two parameters (both of type int):
    */
    public RemoteControlCar2(int speed, int batteryDrain)
    {
        this.speed = speed;
        this.batteryDrain = batteryDrain;
        meters = 0;
        battery = 100;
    }

    public bool BatteryDrained()
    {
        return battery < batteryDrain;
    }

    public int DistanceDriven()
    {
        return meters;
    }

    /*
        Implement the RemoteControlCar.Drive() method that updates the number of meters driven based on the car's speed. Also implement the RemoteControlCar.DistanceDriven() method to return the number of meters driven by the car:

        Update the RemoteControlCar.Drive() method to drain the battery based on the car's battery drain. Also implement the RemoteControlCar.BatteryDrained() method that indicates if the battery is drained:
    */
    public void Drive()
    {
        if (!BatteryDrained())
        {
            meters += speed;
            battery -= batteryDrain;
            Console.WriteLine($"VROOM: {speed} mpd; {meters} meters driven; {battery}% battery left; {battery*speed} meters left");
        }
    }

    /*
        The best-selling remote control car is the Nitro, which has a stunning top speed of 50 meters with a battery drain of 4%. Implement the (static) RemoteControlCar.Nitro() method to return this type of car:
    */
    public static RemoteControlCar2 Nitro()
    {
        return new RemoteControlCar2(50, 4);
    }
}

class RaceTrack
{
    private int distance;
    /*
        Allow creating a race track by defining a constructor for the RaceTrack class that takes the track's distance in meters as its sole parameter (which is of type int):
    */
    public RaceTrack(int distance)
    {
        this.distance = distance;
    }

    /*
        To finish a race track, a car has to be able to drive the track's distance. This means not draining its battery before having crossed the finish line. Implement the RaceTrack.TryFinishTrack() method that takes a RemoteControlCar instance as its parameter and returns true if the car can finish the race track; otherwise, return false:
    */
    public bool TryFinishTrack(RemoteControlCar2 car)
    {
        int remainingDistance = distance;
        while (remainingDistance > 0)
        {
            if (car.BatteryDrained()) return false;
            car.Drive();
            remainingDistance = distance - car.DistanceDriven();
            
        }
        return true;
    }
}