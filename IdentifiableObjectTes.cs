/*
 * File: NunitTemplate.cs
 * Unit: COS20007 Object Oriented Programming
 * Institution: Swinburne University of Technology
 */

using System;
using System.Collections.Generic;
using NUnit.Framework; //Don't forget this
using SwinAdventure; //Rename this to the namespace of your project (project name).

namespace SwinAdventureTests //This should match your NUnit test project name.
{
    [TestFixture]
    public class NUnitTemplate //Rename this appropriately.
    {
        /// <summary>
        /// FIELDS
        /// Declare the fields you are going to use to access the objects you are testing here.
        /// </summary>
        //For Example:
        private IdentifiableObject _testableObject;
        private string _testableString;

        /// <summary>
        /// SETUP
        /// Use this method to setup the objects you are going to use for each test.
        /// This method will be executed before each test is run, "resetting" your objects/data.
        /// </summary>
        //For Example:
        [SetUp]
        public void SetUp()
        {
            _testableObject = new IdentifiableObject(new string[] { "fred", "bob" });
            _testableString = "string";
        }


        /*
                                                               Tests the AreYou method, checks if it returns false if the entry is not found
        */

        //pass in 2 strings to ensure that the test works for more than one string
        [TestCase("fred")]
        [TestCase("bob")]
        public void TestAreYouTrue(string toTest)
        {
            //create a new instance of the object to ensure that the object contains the correct values for this test
            _testableObject = new IdentifiableObject(new string[] { "fred", "bob" });

            //Using the AreYou method, search the object for the values passed into the test
            bool result = _testableObject.AreYou(toTest);

            //since the same values are passed into the object and the test, this should return true
            Assert.IsTrue(result);
        }

        /*
                                                               Tests the AreYou method, checks if it returns false if the entry is not found
        */

        //use 2 test cases to ensure that the test works for more than one string
        [TestCase("wilmer")]
        [TestCase("boby")]
        public void TestAreYouFalse(string toTest)
        {
            //create a new instance of the object to ensure that the object contains the correct values for this test
            _testableObject = new IdentifiableObject(new string[] { "fred", "bob" });

            //using the AreYou method, search for the string passed in
            bool result = _testableObject.AreYou(toTest);

            //since the string passed should not exist in the object, this should return false
            Assert.IsFalse(result);
        }

        /*
                                                                Tests that new ID's created are not case sensitive
*/
        [Test]
        public void TestCaseSensitive()
        {
            //define 2 strings, one with a consistent case and one without
            string TestCase = "FReD";
            string TestCaseLower = "fred";

            //create a new instance of the object - ensure it's empty
            _testableObject = new IdentifiableObject(new string[] { });

            //using the AddIdentifier method - pass in the test case with an inconsistent case
            _testableObject.AddIdentifier(TestCase);

            //using the AreYou method, search for the test case with a consistent case - if this returns true then AddIdentifier is not case sensitive
            bool result = _testableObject.AreYou(TestCaseLower);
            Assert.IsTrue(result);
        }
        /*
                                                                Tests that the firstID method works appropriately
        */

        //use 2 test cases to ensure the test works for more than one argument
        [TestCase("Bob")]
        [TestCase("Fred")]
        public void TestFirstID(string ToTest)
        {
            //recreate the identifiable object to ensure there are no errors
            _testableObject = new IdentifiableObject(new string[] { ToTest });

            //set the testable string to the first ID in the list of testable objects
            _testableString = _testableObject.FirstID;

            //if this first id is equal to the first ID passed into the new object, then the firstID method works appropriately
            Assert.That(ToTest, Is.EqualTo(_testableString));
        }

        /*
                                                               Tests that the No ID's method works appropriately
        */
        [Test]
        public void TestFirstIDWithNoIDs()
        {
            //Create a new instance of the object, however pass in no variables to ensure it's empty
            _testableObject = new IdentifiableObject(new string[] { });

            //Make sure the FirstID method returns an empty string when the object is empty
            Assert.IsEmpty(_testableObject.FirstID);
        }

        /*
                                                               Tests that the Add ID's method works appropriately
        */

        //pass in 2 test values to ensure the method works for more than 1 test
        [TestCase("John")]
        [TestCase("JaMEs")]
        public void TestAddID(string toTest)
        {
            //create a new instance of the object to avoid potential errors or conflicts - ensures the object is empty
            _testableObject = new IdentifiableObject(new string[] {});

            //Add a new identifier using the AddIdentifier method
            _testableObject.AddIdentifier(toTest);

            //Use the areYou method to search for an instance of the object with the identifier as the test case - if this is true than a new object has been created
            bool result = _testableObject.AreYou(toTest);
            Assert.IsTrue(result);
        }

    }
}