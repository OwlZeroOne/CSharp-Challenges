using System;

/*
    In this exercise you'll be writing code to analyze the production of an assembly line in a car factory. The assembly line's speed can range from 0 (off) to 10 (maximum).
    At its lowest speed (1), 221 cars are produced each hour. The production increases linearly with the speed. So with the speed set to 4, it should produce 4 * 221 = 884 cars per hour. However, higher speeds increase the likelihood that faulty cars are produced, which then have to be discarded.
    You have three tasks:
*/
static class AssemblyLine
{
    /*
        Implement the (static) AssemblyLine.SuccessRate() method to calculate the ratio of an item being created without error for a given speed. The following table shows how speed influences the success rate:

        -   0: 0% success rate.
        -   1 to 4: 100% success rate.
        -   5 to 8: 90% success rate.
        -   9: 80% success rate.
        -   10: 77% success rate.
    */
    public static double SuccessRate(int speed)
    {
        if (speed >= 1 && speed <= 4) return 1.0;
        else if (speed >= 5 && speed <= 8) return 0.9;
        else if (speed == 9) return 0.8;
        else if (speed == 10) return 0.77;
        else return 0;
    }
    
    /*
        Implement the (static) AssemblyLine.ProductionRatePerHour() method to calculate the assembly line's production rate per hour, taking into account its success rate:
    */
    public static double ProductionRatePerHour(int speed)
    {
        int carsPerhour = 221;
        return carsPerhour * speed * SuccessRate(speed);
    }

    /*
        Implement the (static) AssemblyLine.WorkingItemsPerMinute() method to calculate how many working cars are produced per minute:
    */
    public static int WorkingItemsPerMinute(int speed)
    {
        return (int) ProductionRatePerHour(speed) / 60;
    }
}
