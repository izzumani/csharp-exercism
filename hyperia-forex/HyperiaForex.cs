using System;
using System.Diagnostics.CodeAnalysis;

public struct CurrencyAmount
{
    private decimal amount;
    private string currency;

    public CurrencyAmount(decimal amount, string currency)
    {
        this.amount = amount;
        this.currency = currency;
    }


    public static bool operator == (CurrencyAmount currencyAmount, CurrencyAmount other) => string.Equals(currencyAmount.currency, other.currency, StringComparison.InvariantCultureIgnoreCase) ? true : throw new ArgumentException();

    public static bool operator !=(CurrencyAmount currencyAmount, CurrencyAmount other)
    {
        if (!string.Equals(currencyAmount.currency, other.currency, StringComparison.InvariantCultureIgnoreCase))
            throw new ArgumentException();
        else if (string.Equals(currencyAmount.currency, other.currency, StringComparison.InvariantCultureIgnoreCase) && currencyAmount.amount != other.amount)
            return true;
        else
            return false;
            
    }
    
    public static bool operator >(CurrencyAmount currencyAmount, CurrencyAmount other)=>(currencyAmount == other && currencyAmount.amount > other.amount) ? true : false;
    
    public static bool operator <(CurrencyAmount currencyAmount, CurrencyAmount other)=> (currencyAmount == other && currencyAmount.amount < other.amount) ? true : false;    
        
    
    public static CurrencyAmount operator+ (CurrencyAmount currencyAmount, CurrencyAmount other)
    {
       CurrencyAmount _currencyAmount = new CurrencyAmount();
        if(currencyAmount== other)
        {
            _currencyAmount.amount = currencyAmount.amount + other.amount;
            _currencyAmount.currency = currencyAmount.currency;
        }
        return _currencyAmount;
    }

    public static CurrencyAmount operator - (CurrencyAmount currencyAmount, CurrencyAmount other)
    {
        CurrencyAmount _currencyAmount = new CurrencyAmount();
        if (currencyAmount == other)
        {
            _currencyAmount.amount = currencyAmount.amount - other.amount;
            _currencyAmount.currency = currencyAmount.currency;
        }
        return _currencyAmount;
    }


    public static CurrencyAmount operator *(CurrencyAmount currencyAmount, CurrencyAmount other)
    {
        CurrencyAmount _currencyAmount = new CurrencyAmount();

        if(other is CurrencyAmount _currencyAmountOther)
        {
            if (currencyAmount == _currencyAmountOther)
            {
                _currencyAmount.amount = currencyAmount.amount * _currencyAmountOther.amount;
                _currencyAmount.currency = currencyAmount.currency;
            }
        }

        return _currencyAmount;
    }

    public static CurrencyAmount operator / (CurrencyAmount currencyAmount, CurrencyAmount other)
    {
        CurrencyAmount _currencyAmount = new CurrencyAmount();
        if (currencyAmount == other)
        {
            _currencyAmount.amount = currencyAmount.amount / other.amount;
            _currencyAmount.currency = currencyAmount.currency;
        }
        return _currencyAmount;
    }

    public static implicit operator decimal(CurrencyAmount currencyAmount)
    {
        return currencyAmount.amount;
    }

    public static explicit operator double(CurrencyAmount currencyAmount)
    {
        return (double)currencyAmount.amount;
    }







    // TODO: implement type conversion operators
}
