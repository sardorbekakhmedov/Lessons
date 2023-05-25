using System.Text;
using Org.BouncyCastle.Crypto.Digests;

string folderPath = @"C:\Users\sardo\OneDrive\Desktop\Publish2";

List<string> fileHashes = CalculateMainHash(folderPath);
;
// Сортировка хешей по возрастанию
fileHashes.Sort();

// Склеивание хешей без сепаратора
string concatenatedHashes = string.Join("", fileHashes);

// Добавление e-mail
string email = "sardorbe2015@gmail.com";
string finalString = concatenatedHashes + email;

Console.WriteLine(finalString);
Console.WriteLine("\n===============================\n");

// Вычисление SHA3-256 хеша

var byteDate = Encoding.UTF8.GetBytes(finalString);

// string resultHash = SHA3_256_Helper.CalculateHash3(byteDate);
string resultHash = CalculateHash3(byteDate);

Console.WriteLine(resultHash);


static List<string> CalculateMainHash(string filePath)
{
    var listHash = new List<string>();

    string[] files = Directory.GetFiles(filePath);

    foreach (var file in files)
    {
        byte[] fileContent = File.ReadAllBytes(file);

        string hash = CalculateHash3(fileContent); // fileContent

        listHash.Add(hash);
    }

    return listHash;
}

static string CalculateHash3(byte[] fileData)
{
    var sha3 = new Sha3Digest(256);

    byte[] hashBytes = new byte[sha3.GetDigestSize()];

    sha3.BlockUpdate(fileData, 0, fileData.Length);

    sha3.DoFinal(hashBytes, 0);

    StringBuilder hashBuilder = new StringBuilder(hashBytes.Length * 2);

    foreach (byte b in hashBytes)
    {
        hashBuilder.Append(b.ToString("x2"));
    }

    return hashBuilder.ToString();
}