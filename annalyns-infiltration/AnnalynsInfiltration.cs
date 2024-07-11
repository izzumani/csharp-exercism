using System;

static class QuestLogic
{
    
    public static bool CanFastAttack(bool knightIsAwake)
    {
        return !knightIsAwake;
    }

    public static bool CanSpy(bool knightIsAwake, bool archerIsAwake, bool prisonerIsAwake)
    {
        return knightIsAwake || archerIsAwake || prisonerIsAwake;
    }

    public static bool CanSignalPrisoner(bool archerIsAwake, bool prisonerIsAwake)
    {
        return !archerIsAwake && prisonerIsAwake;
    }

    public static bool CanFreePrisoner(bool knightIsAwake, bool archerIsAwake, bool prisonerIsAwake, bool petDogIsPresent)
    {
        if (archerIsAwake  && petDogIsPresent) 
            return false;
        else if( (!knightIsAwake || !archerIsAwake || !prisonerIsAwake) && petDogIsPresent)
            return true;
        else if (!knightIsAwake && !archerIsAwake && prisonerIsAwake && !petDogIsPresent)
            return true;
        else 
            return false;
    }
}
