/*
    You're an avid bird watcher that keeps track of how many birds have visited your garden in the last seven days.

    You have six tasks, all dealing with the numbers of birds that visited your garden.
*/
class BirdCount
{
    private int[] birdsPerDay;

    public BirdCount(int[] birdsPerDay)
    {
        this.birdsPerDay = birdsPerDay;
    }

    /*
        For comparison purposes, you always keep a copy of last week's counts nearby, which were: 0, 2, 5, 3, 7, 8 and 4. Implement the (static) BirdCount.LastWeek() method that returns last week's counts:
    */
    public static int[] LastWeek()
    {
        int[] lastWeeksCounts = {0,2,5,3,7,8,4};
        return lastWeeksCounts;
    }

    /*
        Implement the BirdCount.Today() method to return how many birds visited your garden today. The bird counts are ordered by day, with the first element being the count of the oldest day, and the last element being today's count.
    */
    public int Today()
    {
        return birdsPerDay[birdsPerDay.Length - 1];
    }

    /*
        Implement the BirdCount.IncrementTodaysCount() method to increment today's count:
    */
    public void IncrementTodaysCount()
    {
        birdsPerDay[birdsPerDay.Length - 1] ++;
    }

    /*
        Implement the BirdCount.HasDayWithoutBirds() method that returns true if there was a day at which zero birds visited the garden; otherwise, return false:
    */
    public bool HasDayWithoutBirds()
    {
        for (int i = 0; i < birdsPerDay.Length; i++)
            if (birdsPerDay[i] == 0) return true;

        return false;
    }

    /*
        Implement the BirdCount.CountForFirstDays() method that returns the number of birds that have visited your garden from the start of the week, but limit the count to the specified number of days from the start of the week.
    */
    public int CountForFirstDays(int numberOfDays)
    {
        int totalBirds = 0;

        for (int i = 0; i < numberOfDays ; i++)
            totalBirds += birdsPerDay[i];

        return totalBirds;
    }

    /*
        Some days are busier that others. A busy day is one where five or more birds have visited your garden. Implement the BirdCount.BusyDays() method to return the number of busy days:
    */
    public int BusyDays()
    {
        int numberOfBusyDays = 0;

        for (int i = 0; i < birdsPerDay.Length; i++)
            if (birdsPerDay[i] >= 5) numberOfBusyDays++;

        return numberOfBusyDays;
    }
}