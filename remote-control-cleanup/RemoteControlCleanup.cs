public class RemoteControlCar
{

    private enum SpeedUnits
    {
        MetersPerSecond,
        CentimetersPerSecond
    }

    public string CurrentSponsor { get; private set; }

    private Speed currentSpeed;

    public IInnerTelemetry Telemetry  = null;

    public RemoteControlCar()
    {
        Telemetry = new InnerTelemetry(this);
    }
    public interface IInnerTelemetry
    {
        void Calibrate();
        bool SelfTest();
        void ShowSponsor(string sponsorName);
        void SetSpeed(decimal amount, string unitsString);
    }
    private class InnerTelemetry: IInnerTelemetry
    {
        private RemoteControlCar _remoteControlCar;
        public InnerTelemetry(RemoteControlCar remoteControlCar)
        {
            _remoteControlCar = remoteControlCar;
        }

        public void Calibrate()
        {

        }

        public bool SelfTest()
        {
            return true;
        }

        public void ShowSponsor(string sponsorName)
        {
            _remoteControlCar.SetSponsor(sponsorName);
        }

        public void SetSpeed(decimal amount, string unitsString)
        {
            SpeedUnits speedUnits = SpeedUnits.MetersPerSecond;
            if (unitsString == "cps")
            {
                speedUnits = SpeedUnits.CentimetersPerSecond;
            }

            _remoteControlCar.SetSpeed(new Speed(amount, speedUnits));
        }
    }

    private struct Speed
    {
        public decimal Amount { get; }
        public SpeedUnits SpeedUnits { get; }

        public Speed(decimal amount, SpeedUnits speedUnits)
        {
            Amount = amount;
            SpeedUnits = speedUnits;
        }

        public override string ToString()
        {
            string unitsString = "meters per second";
            if (SpeedUnits == SpeedUnits.CentimetersPerSecond)
            {
                unitsString = "centimeters per second";
            }

            return Amount + " " + unitsString;
        }
    }

    public string GetSpeed()
    {
        return currentSpeed.ToString();
    }


    private void SetSponsor(string sponsorName)
    {
        CurrentSponsor = sponsorName;

    }
    private void SetSpeed(Speed speed)
    {
        currentSpeed = speed;
    }
}




