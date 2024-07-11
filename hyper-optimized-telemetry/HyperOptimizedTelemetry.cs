using Newtonsoft.Json.Linq;
using System;
using System.Text;

public static class TelemetryBuffer
{
    public static byte[] ToBuffer(long reading)
    {

        
        byte[] _resultBytes = new byte[9];

        if (reading >= 4_294_967_296  && reading <= 9_223_372_036_854_775_807)
        {
            _resultBytes[0] = 8;
            BitConverter.GetBytes((ulong)reading).CopyTo(_resultBytes, 1);
        }
        else if (reading >= 2_147_483_648  && reading  <= 4_294_967_295)
        {
            _resultBytes[0] = 4;
            BitConverter.GetBytes((uint)reading).CopyTo(_resultBytes, 1);
        }
        else if(reading >= 65_536 && reading<= 2_147_483_647)
        {
            _resultBytes[0] = 256-4;
            BitConverter.GetBytes((int)reading).CopyTo(_resultBytes, 1);
        }
        else if (reading >= -32_768 && reading <= -1)
        {
            _resultBytes[0] = 256 - 2;
            BitConverter.GetBytes((short)reading).CopyTo(_resultBytes, 1);
        }
        else if (reading >= -2_147_483_648 && reading <= -32_769)
        {
            _resultBytes[0] = 256 - 4;
            BitConverter.GetBytes((int)reading).CopyTo(_resultBytes, 1);
        }
        if (reading >= -9_223_372_036_854_775_808 && reading <= -2_147_483_649)
        {
            _resultBytes[0] = 256-8;
            BitConverter.GetBytes((long)reading).CopyTo(_resultBytes, 1);
        }




        return _resultBytes;
    }

    public static long FromBuffer(byte[] buffer)
    {
        throw new NotImplementedException("Please implement the static TelemetryBuffer.FromBuffer() method");
    }
}
