namespace Challenges.Exercism;

/// <summary>
/// Work continues on the remote control car project. Bandwidth in the telemetry system is at a premium 
/// and you have been asked to implement a message protocol for communicating telemetry data.
/// Data is transmitted in a buffer (byte array). When integers are sent, the size of the buffer is 
/// reduced by employing the protocol described below.
/// Each value should be represented in the smallest possible integral type (types of byte and sbyte are 
/// not included as the saving would be trivial):
/// 
/// FROM	                    TO	                        TYPE
/// 4_294_967_296	            9_223_372_036_854_775_807	long
/// 2_147_483_648	            4_294_967_295	            uint
/// 65_536	                    2_147_483_647	            int
/// 0	                        65_535	                    ushort
/// -32_768	                    -1	                        short
/// -2_147_483_648	            -32_769	                    int
/// -9_223_372_036_854_775_808	-2_147_483_649	            long
/// 
/// The value should be converted to the appropriate number of bytes for its assigned type. The complete 
/// buffer comprises a byte indicating the number of additional bytes in the buffer (prefix byte) 
/// followed by the bytes holding the integer (payload bytes). 
/// Some of the types use an identical number of bytes (e.g. the uint and int types). Normally, they 
/// would have the same prefix byte, but that would make decoding problematic. To counter this, the 
/// protocol introduces a little trick: for signed types, their prefix byte value is 256 minus the number 
/// of additional bytes in the buffer. Only the prefix byte and the number of following bytes indicated 
/// by the prefix will be sent in the communication. Internally a 9 byte buffer is used (with trailing 
/// zeroes, as necessary) both by sending and receiving routines.
/// </summary>
public static class TelemetryBuffer
{
    private static Dictionary<string, int> _types = new Dictionary<string, int>
    {
        ["short"] = 2,
        ["int"] = 4,
        ["long"] = 8
    };

    /*
    Please implement the static method TelemetryBuffer.ToBuffer() to encode a buffer taking the parameter passed to the method.
*/
    public static byte[] ToBuffer(long reading)
    {
        var type = EvaluateType(reading);
        byte[] bytes = GetBytes(reading, type);
        return bytes;
    }

    private static byte[] ShiftRight(this Byte[] bytes)
    {
        // Assign a size 1 array with index 0 reserved for the prefix byte
        byte[] newBytes = new byte[1];

        foreach (var b in bytes)
            newBytes = newBytes.ExtendArray(b);

        return newBytes;
    }

    private static byte[] ExtendArray(this byte[] oldArray, byte lastElem)
    {
        int oldArrayLength = oldArray.Length;
        byte[] newArray = new byte[oldArrayLength + 1];

        for (int i = 0; i < oldArrayLength; i++)
            newArray[i] = oldArray[i];

        newArray[newArray.Length - 1] = lastElem;

        return newArray;
    }

    private static byte[] GetBytes(long reading, (bool signed, string type, int numberOfBytes) type)
    {
        byte[] rawBytes = BitConverter.GetBytes(reading);
        byte[] prefixedBytes = rawBytes.ShiftRight();

        byte prefix = (byte)(type.signed ? 256 - type.numberOfBytes : type.numberOfBytes);
        if (prefix < 2) prefix = 2;

        prefixedBytes[0] = prefix;

        byte[] newBytes = new byte[9];

        for (int i = 0; i < newBytes.Length; i++)
            newBytes[i] = i <= type.numberOfBytes ? prefixedBytes[i] : (byte) 0;

        return newBytes;
    }

    /// FROM	                    TO	                        TYPE
    /// 4_294_967_296	            9_223_372_036_854_775_807	long
    /// 2_147_483_648	            4_294_967_295	            uint
    /// 65_536	                    2_147_483_647	            int
    /// 0	                        65_535	                    ushort
    /// -32_768	                    -1	                        short
    /// -2_147_483_648	            -32_769	                    int
    /// -9_223_372_036_854_775_808	-2_147_483_649	            long
    private static (bool signed, string type, int numberOfBytes) EvaluateType(long reading)
    {
        var type = "long";
        var numberOfBytes = 0;

        // Determine the optimal data type
        Console.WriteLine($"reading:{reading}");
        if (reading is >= 2_147_483_648 and <= 4_294_967_295) type = "uint";
        else if (reading is >= 65_536 and <= 2_147_483_647) type = "int";
        else if (reading is >= 0 and <= 65_535) type = "ushort";
        else if (reading is >= -32_768 and <= -1) type = "short";
        else if (reading is >= -2_147_483_648 and <= -32_769) type = "int";

        // Check if the data type is signed and calculate
        string tempType = type;
        bool signed = type[0] != 'u';
        if (!signed)
            tempType = type.Substring(1,type.Length - 1);

        numberOfBytes = _types[tempType];

        Console.WriteLine(signed);
        Console.WriteLine(type);
        Console.WriteLine(numberOfBytes);
        return (signed, type, numberOfBytes);
    }

    /*
     * Please implement the static method TelemetryBuffer.FromBuffer() to decode the buffer received and return the value in the form of a long.
     */
    public static long FromBuffer(byte[] buffer)
    {
        short prefixByte = buffer[0];
        int prefix = prefixByte > (byte.MaxValue / 2) ? prefixByte - 256 : prefixByte;

        Console.WriteLine($"Prefix: {prefix}\n");
        
        switch (prefix)
        {
            case -8:
                return BitConverter.ToInt64(buffer, 1);
            
            case -4:
                return BitConverter.ToInt32(buffer, 1);

            case -2:
                return BitConverter.ToInt16(buffer, 1);
            
            case 2:
                return BitConverter.ToUInt16(buffer, 1);
            
            case 4:
                return BitConverter.ToUInt32(buffer, 1);
        }
        return 0;
    }
}