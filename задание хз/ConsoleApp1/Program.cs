using System;
using System.Globalization;

public class Example
{
    public static void Main()
    {
      

        for(int i = 0; ;  i++) 
        {
            DateTime localDate = DateTime.Now;
            DateTime utcDate = DateTime.UtcNow;
            String[] cultureNames = { "ru-RU" };

            foreach (var cultureName in cultureNames)
            {
                var culture = new CultureInfo(cultureName);
                Console.WriteLine("   Текущее время: {0}",
                                  localDate.ToString(culture), localDate.Kind);
               
            }
        }
        
    }
}