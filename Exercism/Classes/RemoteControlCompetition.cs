namespace Challenges.Exercism.Classes;

public interface IRemoteControlCar
{
    int DistanceTravelled { get; set; }
    void Drive();
}

public class ProductionRemoteControlCar : IRemoteControlCar, IComparable<IRemoteControlCar>
{
    public int DistanceTravelled { get; set; }
    public int NumberOfVictories { get; set; }

    public void Drive()
    {
        DistanceTravelled += 10;
    }

    /*
     * return < 0 : this object is smaller than the other object.
     * return > 0 : this object is greater than the other objects.
     * return 0 : objects are equal
     */
    public int CompareTo(IRemoteControlCar? other)
    {
        if (other == null) throw new NullReferenceException("Other object is found null!");
        
        return DistanceTravelled - other.DistanceTravelled;
    }
}

public class ExperimentalRemoteControlCar : IRemoteControlCar
{
    public int DistanceTravelled { get; set; }

    public void Drive()
    {
        DistanceTravelled += 20;
    }
}

public static class TestTrack
{
    public static void Race(IRemoteControlCar car)
    {
        car.Drive();
    }

    public static List<ProductionRemoteControlCar> GetRankedCars(ProductionRemoteControlCar prc1,
        ProductionRemoteControlCar prc2)
    {
        if (prc1 == null || prc2 == null)
            throw new NullReferenceException("At least one of the arguments are null!");
        
        if (!(prc1 is ProductionRemoteControlCar && prc2 is ProductionRemoteControlCar))
            throw new ArgumentException("At least one of the arguments are of illegal type!");
        
        ProductionRemoteControlCar first = prc1.NumberOfVictories < prc2.NumberOfVictories ? prc1 : prc2;
        ProductionRemoteControlCar second = first == prc1 ? prc2 : prc1;

        return new List<ProductionRemoteControlCar> { first, second };
    }
}