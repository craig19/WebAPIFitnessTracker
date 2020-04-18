using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WebAPIFitnessTracker;
using WebAPIFitnessTracker.Models;

namespace WebAPIFitnessTracker.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestBMR()
        {
            double testBMR = 1637.75;
            UserData user1 = new UserData() { FirstName = "Craig",  SecondName = "Whelan", Age = 29, HeightCM = 175, WeightKG = 85};
            Assert.AreEqual(user1.BMR, testBMR);
        }

        [TestMethod]
        public void TestBMI()
        {
            double testBMI = 27.75510204081633;
            UserData user1 = new UserData() { FirstName = "Craig", SecondName = "Whelan", Age = 29, HeightCM = 175, WeightKG = 85 };
            Assert.AreEqual(user1.BMIValue, testBMI);
        }

        [TestMethod]
        public void TestBMRcategory()
        {
            string testBMIcat = "Overweight";
            UserData user1 = new UserData() { FirstName = "Craig", SecondName = "Whelan", Age = 29, HeightCM = 175, WeightKG = 85 };
            Assert.AreEqual(user1.BMICategory, testBMIcat);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestFirstNameLength()
        {
            UserData user1 = new UserData() { FirstName = "CraigCraigCraigCraigCraigsssssss", SecondName = "Whelan", Age = 29, HeightCM = 175, WeightKG = 85 };
            if(user1.FirstName.Length > 20)
            {
                throw new Exception("Name is too long");
            }

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestSecondNameLength()
        {
            UserData user1 = new UserData() { FirstName = "Craig", SecondName = "WhelanWhelanWhelanWhelanWhelan", Age = 29, HeightCM = 175, WeightKG = 85 };
            if (user1.SecondName.Length > 20)
            {
                throw new Exception("Name is too long");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestAgeRange()
        {
            UserData user1 = new UserData() { FirstName = "Craig", SecondName = "Whelan", Age = 1, HeightCM = 175, WeightKG = 85 };
            if (user1.Age < 5 || user1.Age > 110)
            {
                throw new Exception("Invalid Age");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestHeightRange()
        {
            UserData user1 = new UserData() { FirstName = "Craig", SecondName = "Whelan", Age = 29, HeightCM = 400, WeightKG = 85 };
            if (user1.HeightCM < 5 || user1.HeightCM > 220)
            {
                throw new Exception("Invalid Height");
            }
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestWeightRange()
        {
            UserData user1 = new UserData() { FirstName = "Craig", SecondName = "Whelan", Age = 29, HeightCM = 175, WeightKG = 160 };
            if (user1.WeightKG < 5 || user1.WeightKG > 150)
            {
                throw new Exception("Invalid Weight");
            }
        }
    }
}
