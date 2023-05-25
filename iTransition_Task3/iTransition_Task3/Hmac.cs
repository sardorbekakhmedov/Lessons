using System.Security.Cryptography;
using System.Text;

namespace iTransition_Task3;

public class Hmac
{
    public static string GetRandomMove(string[] moves)
    {
        var random = new Random();
        int index = random.Next(0, moves.Length);
        return moves[index];
    }

    public static string GenerateKey()
    {
        using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
        {
            byte[] keyBytes = new byte[32]; // 256 bits
            rng.GetBytes(keyBytes);
            return BitConverter.ToString(keyBytes).Replace("-", "");
        }
    }

    public static string CalculateHMAC(string message, string key)
    {
        byte[] keyBytes = Encoding.UTF8.GetBytes(key);
        byte[] messageBytes = Encoding.UTF8.GetBytes(message);

        using (HMACSHA256 hmac = new HMACSHA256(keyBytes))
        {
            byte[] hashBytes = hmac.ComputeHash(messageBytes);
            return BitConverter.ToString(hashBytes).Replace("-", "");
        }
    }
}