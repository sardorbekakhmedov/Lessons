using System.Diagnostics;

namespace Lesson96.MsTests;

public class InitializeAndCleanUpAttributes
{
  
    [AssemblyInitialize]   // Assambleyadagi barcha testlardan oldin bir marta ishlaydi
    public static void AssemblyInitialize(TestContext context)
    {
        Debug.WriteLine("AssemblyInitialize...");
        // Butun assembly uchun initsalizatsiya ishlarini bajarish
        // Masalan, test ma'lumotlar bazasini o'rnatish, serverni ishga tushirish va h.k.
    }

 
    [ClassInitialize]    // Ushbu Classdagi barcha testlardan oldin bir marta ishlaydi
    public static void ClassInitialize(TestContext context)
    {
        Debug.WriteLine("ClassInitialize...");
        // Faqat shu class uchun initsalizatsiya ishlarini bajarish
        // Masalan, umumiy ob'ektlarni olish, konfiguratsiyalarni o'rnatish va h.k.
    }

   
    [TestInitialize]  // Ushbu classdagi har bir testdan oldin bir marta ishlaydi
    public void TestInitialize()
    {
        Debug.WriteLine("TestInitialize...");
        // Shu classdagi har bir test uchun initsalizatsiya ishlarini bajarish
        // Masalan, ma'lumotlarni qayta tiklash, soxta ob'ektlarni o'rnatish va h.k.
    }

    [TestMethod] 
    public void ExampleTestMethod()
    {
        // Arrange: Test ma'lumotlarini tayyorlash

        // Act: Testni bajarish

        // Assert: Kutilgan natijalarni tasdiqlash

        Debug.WriteLine("ExampleTestMethod...");
    }

    [TestCleanup]     // Ushbu classdagi har bir testdan keyin bir marta ishlaydi

    public void TestCleanup()
    {
        Debug.WriteLine("TestCleanup...");
        // Har bir test uchun ochilgan ishiklarni yopish
        // Masalan, resurslarni tozalash, statelarni o'z holiga qaytarish va h.k.
    }

   
    [ClassCleanup]   // Ushbu Classdagi barcha testlardan keyin bir marta ishlaydi
    public static void ClassCleanup()
    {
        Debug.WriteLine("ClassCleanup...");
        // Shu classga tegishli tozalash ishlarini bajarish
        // Masalan, umumiy ob'ektlarni o'chirish va h.k.
    }

  
    [AssemblyCleanup]   // Assambleyadagi barcha testlardan keyin bir marta ishlaydi
    public static void AssemblyCleanup()
    {
        Debug.WriteLine("AssemblyCleanup");
        // Ushbu assebly uchun tozalash ishlarini bajarish
        // Masalan, serverni o'chirish, vaqtinchalik fayllarni o'chirish va hokazo.
    }
}