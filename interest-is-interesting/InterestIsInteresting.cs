using System;

static class SavingsAccount
{
    public static float InterestRate(decimal balance)
    {
        if (balance <0)
            return 3.213f;
        else if (balance < 1000) 
            return 0.5f;
        else if (balance >=1000 && balance <5000)
            return 1.621f;
        else
            return 2.475f;
        
    
    }

    public static decimal Interest(decimal balance)
    {
        decimal _interest = (decimal) InterestRate(balance)/100;
        return (_interest*balance);
    }

    public static decimal AnnualBalanceUpdate(decimal balance)
    {
         return Interest(balance) + balance;
    }

    public static int YearsBeforeDesiredBalance(decimal balance, decimal targetBalance)
    {
        int years = 0;
        decimal movingBalance = balance;
            
        do
        {
            years +=1;
            decimal   newInterest = Interest(movingBalance);
            movingBalance+=newInterest;
        }while(targetBalance > movingBalance);
        return years;
    }
}
