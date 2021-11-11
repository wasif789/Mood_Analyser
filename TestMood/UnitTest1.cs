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
        MoodAnalyser setEmpty;


        [TestInitialize]
            public void SetUp()
            {
            string[] message = { "i", "am", "in", "sad", "mood" };
            setmood = new MoodAnalyser(message);
            string[] message1 = { "i", "am", "in", "any", "mood" };
            setmood1 = new MoodAnalyser(message1);
            string[] message2 = null;
            setNull = new MoodAnalyser(message2);
            string[] message3 = { "" };
            setEmpty = new MoodAnalyser(message3);
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

        
        [TestMethod]
        [TestCategory("CustomizedException")]
        public void Given_NullMessage_using_CustomizeException_Return_NullException()
        {
            try
            {
                setNull.ReturnMessage();

            }
            catch (CustomizeException ex)
            {
                string expected = "Mood should not be Null";
                Assert.AreEqual(expected, ex.Message);
            }
        }
       

        [TestMethod]
        [TestCategory("CustomizedException")]
        public void Given_EmptyMood_using_CustomizeException_Return_Empty()
        {
            try
            {
                setEmpty.ReturnMessage();

            }
            catch (CustomizeException ex)
            {
                string expected = "Mood should not be Empty";
                Assert.AreEqual(expected, ex.Message);
            }
        }
    }
}
