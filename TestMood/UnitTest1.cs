using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mood_Analyser;

namespace TestMood
{
        [TestClass]
        public class UnitTest1
        {
           
        MoodAnalyser setmood;
        MoodAnalyser setmood1;
        MoodAnalyser setNull;

        [TestInitialize]
            public void SetUp()
            {
            string[] message = { "i", "am", "in", "sad", "mood" };
            setmood = new MoodAnalyser(message);
            string[] message1 = { "i", "am", "in", "any", "mood" };
            setmood1 = new MoodAnalyser(message1);
            string[] message2 = null;
            setNull = new MoodAnalyser(message2);
            }

        //To check if user is sad
        [TestMethod]
            public void SadTestMethod()
            {
                string actual = setmood.ReturnMessage();
                string expected = "Sad";
                Assert.AreEqual(expected, actual);
            }
        //To check if user is happy
        [TestMethod]
            public void HappyTestMethod()
            {
                string actual = setmood1.ReturnMessage();
                string expected = "Happy";
                Assert.AreEqual(expected, actual);
            }

        //Null reference Exception
        [TestMethod]
        [TestCategory("NullReferenceException")]
        public void NullReferenceTestMethod()
        {
            string actual = setNull.ReturnMessage();
            string expected = "Happy";
            Assert.AreEqual(expected, actual);
        }
    }
}
