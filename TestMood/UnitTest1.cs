using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mood_Analyser;

namespace TestMood
{
        [TestClass]
        public class UnitTest1
        {
           
        MoodAnalyser setmood;
        MoodAnalyser setmoodAny;
        MoodAnalyser setNull;
        MoodAnalyser setEmpty;
        MoodAnalyserFactory moodAnalyserFactory;


        [TestInitialize]
            public void SetUp()
            {
            string[] sadmessage = { "i", "am", "in", "sad", "mood" };
            setmood = new MoodAnalyser(sadmessage);
            string[] happymessage = { "i", "am", "in", "any", "mood" };
            setmoodAny = new MoodAnalyser(happymessage);
            string[] message2 = null;
            setNull = new MoodAnalyser(message2);
            string[] message3 = { "" };
            setEmpty = new MoodAnalyser(message3);
            moodAnalyserFactory = new MoodAnalyserFactory();
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
        [TestCategory("Happy")]
        public void Given_AnyMood_return_Happy()
        {
            string actual = setmoodAny.ReturnMessage();
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

        [TestMethod]
        [TestCategory("Using Reflection")]
        public void Given_MoodAnalyser_using_Reflection_Return_defaultParameter()
        {
            MoodAnalyser expexted = new MoodAnalyser();
            object constructor;

            constructor = moodAnalyserFactory.CreatingObjectWithMethod("Mood_Analyser.MoodAnalyser", "MoodAnalyser");
            expexted.Equals(expexted);
        }

        [TestMethod]
        [TestCategory("Using Reflection")]
        public void Given_InvalidConstructor_using_Reflection_Return_CustomisedException()
        {
            string expected = "Class does not have such Constructor";
            object constructor;
            try
            {
                constructor = moodAnalyserFactory.CreatingObjectWithMethod("Mood_Analyser.MoodAnalyser", "MoodAnaly");
            }
            catch (CustomizeException actual)
            {
                Assert.AreEqual(expected, actual.Message);
            }
        }
        [TestMethod]
        [TestCategory("Using Reflection")]
        public void Given_InvalidClass_using_Reflection_Return_CustomisedException()
        {
            string expected = "Class does not exist";
            object constructor;
            try
            {
                constructor = moodAnalyserFactory.CreatingObjectWithMethod("Mood_Analyser.MoodAnaly", "MoodAnaly");
            }
            catch (CustomizeException actual)
            {
                Assert.AreEqual(expected, actual.Message);
            }
        }

        [TestMethod]
        [TestCategory("Using Parameterised Reflection")]
        public void Given_MoodAnalyserAny_using_Reflection_Return_Parameterisedobject()
        {
            string[] happymessage = { "i", "am", "in", "any", "mood" };
            MoodAnalyser expected = setmoodAny;
            object constructor;
            try
            {
                constructor = moodAnalyserFactory.CreatingParameterisedObjectWithMethod("Mood_Analyser.MoodAnalyser", "MoodAnalyser", happymessage);
                expected.Equals(constructor);
            }
            catch (CustomizeException actual)
            {
                Assert.AreEqual(expected, actual.Message);
            }
        }
        /// <summary>
        /// TC 5.2
        /// </summary>
        [TestMethod]
        [TestCategory("Using Parameterised Reflection")]
        public void Given_InvalidconstructorMoodAnalyser_using_Reflection_Return_Parameterisedobject()
        {
            string[] happymessage = { "i", "am", "in", "any", "mood" };
            string expected = "Class does not exist";
            object constructor;
            try
            {
                constructor = moodAnalyserFactory.CreatingParameterisedObjectWithMethod("Mood_Analyser.MoodAnalyser", "MoodAnalye", happymessage);
                expected.Equals(constructor);
            }
            catch (CustomizeException actual)
            {
                Assert.AreEqual(expected, actual.Message);
            }
        }
        /// <summary>
        /// TC 5.3
        /// </summary>
        [TestMethod]
        [TestCategory("Using Parameterised Reflection")]
        public void Given_InvalidClass_MoodAnalyser_using_Reflection_Return_Parameterisedobject()
        {
            string[] happymessage = { "i", "am", "in", "any", "mood" };
            string expected = "Class does not have such Constructor";
            object constructor;
            try
            {
                constructor = moodAnalyserFactory.CreatingParameterisedObjectWithMethod("Mood_Analyser.MoodAna", "MoodAnalyser", happymessage);
                expected.Equals(constructor);
            }
            catch (CustomizeException actual)
            {
                Assert.AreEqual(expected, actual.Message);
            }
        }

    }
}
