using System;
using System.ComponentModel.Design;

public static class PhoneNumber
{
    public static (bool IsNewYork, bool IsFake, string LocalNumber) Analyze(string phoneNumber)
    {
        string[] phoneCodes = phoneNumber.Split("-");
        if(phoneCodes.Length ==3)
           return (phoneCodes[0]== "212", phoneCodes[1] == "555", phoneCodes[2]);
        else
            return (false, false, string.Empty);
    }

    public static bool IsFake((bool IsNewYork, bool IsFake, string LocalNumber) phoneNumberInfo)
    {
        return phoneNumberInfo.IsFake;

        
    }
}
