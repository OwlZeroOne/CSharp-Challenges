/*
    In this exercise you'll be playing around with a remote controlled car, which you've finally saved enough money for to buy.

    Cars start with full (100%) batteries. Each time you drive the car using the remote control, it covers 20 meters and drains one percent of the battery.

    The remote controlled car has a fancy LED display that shows two bits of information:

    The total distance it has driven, displayed as: "Driven <METERS> meters".
    The remaining battery charge, displayed as: "Battery at <PERCENTAGE>%".
    If the battery is at 0%, you can't drive the car anymore and the battery display will show "Battery empty".

    You have six tasks, each of which will work with remote controlled car instances.
*/
class RemoteControlCar
{
    private static int meters = 0;
    private static int batteryPercentage = 100;

    /*
        Implement the (static) RemoteControlCar.Buy() method to return a brand-new remote controlled car instance:
    */
    public static RemoteControlCar Buy()
    {
        return new RemoteControlCar();
    }

    /*
        Implement the RemoteControlCar.DistanceDisplay() method to return the distance as displayed on the LED display:
    */
    public string DistanceDisplay()
    {
        return $"Driven {meters} meters";
    }

    /*
        Implement the RemoteControlCar.BatteryDisplay() method to return the battery percentage as displayed on the LED display:
    */
    public string BatteryDisplay()
    {
        if (batteryPercentage > 0) return $"Battery at {batteryPercentage}%";
        else return "Battery empty";
    }

    /*
        Implement the RemoteControlCar.Drive() method that updates the number of meters driven:
        Update the RemoteControlCar.Drive() method to update the battery percentage:
    */
    public void Drive()
    {
        if (batteryPercentage > 0)
        {
            meters += 20;
            batteryPercentage -= 1;
        }
        else BatteryDisplay();
    }
    
}