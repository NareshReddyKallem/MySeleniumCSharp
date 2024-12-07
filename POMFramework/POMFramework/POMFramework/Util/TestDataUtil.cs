using System;
using System.Collections.Generic;

namespace POMFramework.Util
{
    public class TestDataUtil
    {
        public static string FirstName()
        {
            return Faker.Name.FirstName();
        }

        public static string LastName()
        {
            return Faker.Name.LastName();
        }

        public static string UserName()
        {
            return Faker.User.Username();
        }

        public static string Password()
        {
            return Faker.User.Password();
        }

        public static string PhoneNumber()
        {
            //Understand this logic later
            return "9" + DateTime.UtcNow.Ticks.ToString().Substring(9);
        }

        public static string Address()
        {
            return Faker.Address.Country();
        }

        public static string Symptom()
        {
            var list = new List<string> { "AIDS", "Heart Pain", "Heart Pain", "Ear Infections", "Cardiovascular disease", "Hiatal hernia", "Hair Fall", "Head Lice", "Arm ache or pain", "Weight loss", "Confusion" };
            int index = new Random().Next(list.Count);
            return list[index];
        }
    }
}