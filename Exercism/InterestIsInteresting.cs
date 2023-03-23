/*
    In this exercise you'll be working with savings accounts. Each year, the balance of your savings account is updated based on its interest rate. The interest rate your bank gives you depends on the amount of money in your account (its balance):

    -   3.213% for a negative balance (balance gets more negative).
    -   0.5% for a positive balance less than 1000 dollars.
    -   1.621% for a positive balance greater than or equal to 1000 dollars and less than 5000 dollars.
    -   2.475% for a positive balance greater than or equal to 5000 dollars.
    You have four tasks, each of which will deal your balance and its interest rate.
*/
static class SavingsAccount
{
    /*
        Implement the (static) SavingsAccount.InterestRate() method to calculate the interest rate based on the specified balance:
    */
    public static float InterestRate(decimal balance)
    {
        if (balance < 0) return 3.213f;
        else if (balance < 1000) return 0.5f;
        else if (balance < 5000) return 1.621f;
        else return 2.475f;
    }

    /*
        Implement the (static) SavingsAccount.Interest() method to calculate the interest based on the specified balance:
    */
    public static decimal Interest(decimal balance)
    {
        return balance * (decimal) InterestRate(balance) / 100;
    }

    /*
        Implement the (static) SavingsAccount.AnnualBalanceUpdate() method to calculate the annual balance update, taking into account the interest rate:
    */
    public static decimal AnnualBalanceUpdate(decimal balance)
    {
        return balance + Interest(balance);
    }

    /*
        Implement the (static) SavingsAccount.YearsBeforeDesiredBalance() method to calculate the minimum number of years required to reach the desired balance given annually compounding interest:
    */
    public static int YearsBeforeDesiredBalance(decimal balance, decimal targetBalance)
    {
        int years = 0;
        while (balance < targetBalance)
        {
            balance = AnnualBalanceUpdate(balance);
            years++;
        }
        return years;
    }
}