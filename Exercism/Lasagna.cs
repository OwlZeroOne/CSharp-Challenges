/*
    Lucian's girlfriend is on her way home and he hasn't cooked their anniversary dinner!
    In this exercise, you're going to write some code to help Lucian cook an exquisite lasagna from his favorite cook book.
*/
class Lasagna
{
    /*
        Define the Lasagna.ExpectedMinutesInOven() method that does not take any parameters and returns how many minutes the lasagna should be in the oven. According to the cooking book, the expected oven time in minutes is 40:
    */
    // TODO: define the 'ExpectedMinutesInOven()' method
    public int ExpectedMinutesInOven()
    {
        return 40;    
    }

    /*
        Define the Lasagna.RemainingMinutesInOven() method that takes the actual minutes the lasagna has been in the oven as a parameter and returns how many minutes the lasagna still has to remain in the oven, based on the expected oven time in minutes from the previous task.
    */
    // TODO: define the 'RemainingMinutesInOven()' method
    public int RemainingMinutesInOven(int minutesInOven)
    {
        return ExpectedMinutesInOven() - minutesInOven;
    }

    /*
        Define the Lasagna.PreparationTimeInMinutes() method that takes the number of layers you added to the lasagna as a parameter and returns how many minutes you spent preparing the lasagna, assuming each layer takes you 2 minutes to prepare.
    */
    // TODO: define the 'PreparationTimeInMinutes()' method
    public int PreparationTimeInMinutes(int numberOfLayers)
    {
        int timeToPrepareOneLayer = 2;
        return numberOfLayers * timeToPrepareOneLayer;
    }

    /*
        Define the Lasagna.ElapsedTimeInMinutes() method that takes two parameters: the first parameter is the number of layers you added to the lasagna, and the second parameter is the number of minutes the lasagna has been in the oven. The function should return how many minutes you've worked on cooking the lasagna, which is the sum of the preparation time in minutes, and the time in minutes the lasagna has spent in the oven at the moment.
    */
    // TODO: define the 'ElapsedTimeInMinutes()' method
    public int ElapsedTimeInMinutes(int numberOfLayers, int minutesInOven)
    {
        int preparationTime = PreparationTimeInMinutes(numberOfLayers);
        return preparationTime + minutesInOven;
    }
}
