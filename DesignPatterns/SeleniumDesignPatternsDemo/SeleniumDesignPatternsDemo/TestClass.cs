using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.IE;
using SeleniumDesignPatterns.Models;
using SeleniumDesignPatterns.Pages.HomePage;
using SeleniumDesignPatterns.Pages.RegistrationPage;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Diagnostics;
using System;
using OpenQA.Selenium.Interactions;

namespace SeleniumWebDriverFirstTests
{
    [TestFixture]
    public class RegisterInDemoQA
    {
        public IWebDriver driver;

        [SetUp]
        public void Init()
        {
            
            this.driver = new ChromeDriver();
        }

        [TearDown]
        public void CleanUp()
        {
            this.driver.Quit();

        }

        [Test, Property("Priority", 1)]
        
        public void NavigateToRegistrationPage()
        {
            var homePage = new HomePage(driver);
            var registrationPage = new RegistrationPage(driver);
            PageFactory.InitElements(this.driver, homePage);

            homePage.NavigateTo();
            homePage.RegirstratonButton.Click();

            registrationPage.AssertRegistrationPageIsOpen("Registration");
        }


        [Test, Property("Priority", 2)]
        [Author("Georgi Kostadinov")]
        public void RegistrateWithOutBothNames()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("",
                                                         "",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { true, true, true }),
                                                         "Bulgaria",
                                                         "5",
                                                         "2",
                                                         "1973",
                                                         "7777777777",
                                                         "Golemiq",
                                                         "parcheto@abv.bg",
                                                         @"C:\Users\Djordjiiiiii\Desktop\Testvam\Si\PoPraznicite.jpg",
                                                         "Few more TESTS left!!!",
                                                         "12345678",
                                                         "12345678");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertNamesErrorMessage("This field is required");
        }

        [Test, Property("Priority", 1)]
        [Author("Georgi Kostadinov")]
        public void RegistrateWithOutLastName()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Mincho",
                                                         "",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { true, true, true }),
                                                         "Bulgaria",
                                                         "5",
                                                         "2",
                                                         "1973",
                                                         "7777777777",
                                                         "Golemiq",
                                                         "parcheto@abv.bg",
                                                         @"C:\Users\Djordjiiiiii\Desktop\Testvam\Si\PoPraznicite.jpg",
                                                         "Few more TESTS left!!!",
                                                         "12345678",
                                                         "12345678");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertNamesErrorMessage("This field is required");
        }

        [Test, Property("Priority", 2)]
        [Author("Georgi Kostadinov")]
        public void RegistrateWithOutPhoneNumber()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Mincho",
                                                         "Praznikov",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { true, true, true }),
                                                         "Bulgaria",
                                                         "5",
                                                         "2",
                                                         "1973",
                                                         "",
                                                         "Golemiq",
                                                         "parcheto@abv.bg",
                                                         @"C:\Users\Djordjiiiiii\Desktop\Testvam\Si\PoPraznicite.jpg",
                                                         "Few more TESTS left!!!",
                                                         "87654321",
                                                         "87654321");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertPhoneErrorMessage("This field is required");
        }

        [Test, Property("Priority", 2)]
        [Author("Georgi Kostadinov")]
        public void RegistrateWithOutHobby()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Mincho",
                                                         "Praznikov",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { }),
                                                         "Bulgaria",
                                                         "5",
                                                         "2",
                                                         "1973",
                                                         "7777777777",
                                                         "Golemiq",
                                                         "parcheto@abv.bg",
                                                         @"C:\Users\Djordjiiiiii\Desktop\Testvam\Si\PoPraznicite.jpg",
                                                         "Few more TESTS left!!!",
                                                         "87654321",
                                                         "87654321");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertHobbysErrorMessage("This field is required");
        }

        [Test, Property("Priority", 2)]
        [Author("Georgi Kostadinov")]
        public void RegistrateWithInvalidPhoneNumber()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Mincho",
                                                         "Praznikov",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { true, true, false }),
                                                         "Bulgaria",
                                                         "5",
                                                         "2",
                                                         "1973",
                                                         "dddd",
                                                         "Golemiq",
                                                         "parcheto@abv.bg",
                                                         @"C:\Users\Djordjiiiiii\Desktop\Testvam\Si\PoPraznicite.jpg",
                                                         "Few more TESTS left!!!",
                                                         "87654321",
                                                         "87654321");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertInvalidPhoneErrorMessage("* Minimum 10 Digits starting with Country Code");
        }

        [Test, Property("Priority", 2)]
        [Author("Georgi Kostadinov")]
        public void RegistrateWithoutUserName()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Mincho",
                                                         "Praznikov",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { true, true, false }),
                                                         "Bulgaria",
                                                         "5",
                                                         "2",
                                                         "1973",
                                                         "7777777777",
                                                         "",
                                                         "parcheto@abv.bg",
                                                         @"C:\Users\Djordjiiiiii\Desktop\Testvam\Si\PoPraznicite.jpg",
                                                         "Few more TESTS left!!!",
                                                         "87654321",
                                                         "87654321");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertUserNameErrorMessage("* This field is required");
        }

        [Test, Property("Priority", 2)]
        [Author("Georgi Kostadinov")]
        public void RegistrateWithoutMail()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Mincho",
                                                         "Praznikov",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { true, true, false }),
                                                         "Bulgaria",
                                                         "5",
                                                         "2",
                                                         "1973",
                                                         "7777777777",
                                                         "Golemiq",
                                                         "",
                                                         @"C:\Users\Djordjiiiiii\Desktop\Testvam\Si\PoPraznicite.jpg",
                                                         "Few more TESTS left!!!",
                                                         "87654321",
                                                         "87654321");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertMailErrorMessage("* This field is required");
        }

        [Test, Property("Priority", 2)]
        [Author("Georgi Kostadinov")]
        public void RegistrateWithInvalidMail()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Mincho",
                                                         "Praznikov",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { true, true, false }),
                                                         "Bulgaria",
                                                         "5",
                                                         "2",
                                                         "1973",
                                                         "7777777777",
                                                         "Golemiq",
                                                         "1111111",
                                                         @"C:\Users\Djordjiiiiii\Desktop\Testvam\Si\PoPraznicite.jpg",
                                                         "Few more TESTS left!!!",
                                                         "87654321",
                                                         "87654321");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertInvalidMailErrorMessage("* Invalid email address");
        }

        [Test, Property("Priority", 2)]
        [Author("Georgi Kostadinov")]
        public void RegistrateWithInvalidUploadFileFormat()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Mincho",
                                                         "Praznikov",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { true, true, false }),
                                                         "Bulgaria",
                                                         "5",
                                                         "2",
                                                         "1973",
                                                         "7777777777",
                                                         "Golemiq",
                                                         "parcheto@abv.bg",
                                                         @"C:\Users\Djordjiiiiii\Desktop\Testvam\Si\30 03 17.rar",
                                                         "Few more TESTS left!!!",
                                                         "87654321",
                                                         "87654321");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertInvalidUploadFile("* Invalid File");
        }


        [Test, Property("Priority", 2)]
        [Author("Georgi Kostadinov")]
        public void RegistrateWithOutPassword()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Mincho",
                                                         "Praznikov",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { true, true, false }),
                                                         "Bulgaria",
                                                         "5",
                                                         "2",
                                                         "1973",
                                                         "7777777777",
                                                         "Golemiq",
                                                         "parcheto@abv.bg",
                                                         @"C:\Users\Djordjiiiiii\Desktop\Testvam\Si\PoPraznicite.jpg",
                                                         "Few more TESTS left!!!",
                                                         "",
                                                         "87654321");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertPasswordErrorMessage("* This field is required");
        }

        [Test, Property("Priority", 2)]
        [Author("Georgi Kostadinov")]
        public void RegistrateWithOutConfirmPassword()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Mincho",
                                                         "Praznikov",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { true, true, false }),
                                                         "Bulgaria",
                                                         "5",
                                                         "2",
                                                         "1973",
                                                         "7777777777",
                                                         "Golemiq",
                                                         "parcheto@abv.bg",
                                                         @"C:\Users\Djordjiiiiii\Desktop\Testvam\Si\PoPraznicite.jpg",
                                                         "Few more TESTS left!!!",
                                                         "87654321",
                                                         "");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertConfirmPasswordErrorMessage("* This field is required");
        }

        [Test, Property("Priority", 2)]
        [Author("Georgi Kostadinov")]
        public void RegistrateWithShortPasswordLenght()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Mincho",
                                                         "Praznikov",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { true, true, false }),
                                                         "Bulgaria",
                                                         "5",
                                                         "2",
                                                         "1973",
                                                         "7777777777",
                                                         "Golemiq",
                                                         "parcheto@abv.bg",
                                                         @"C:\Users\Djordjiiiiii\Desktop\Testvam\Si\PoPraznicite.jpg",
                                                         "Few more TESTS left!!!",
                                                         "4444",
                                                         "4444");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertShortPasswordErrorMessage("* Minimum 8 characters required");
        }

        [Test, Property("Priority", 2)]
        [Author("Georgi Kostadinov")]
        public void RegistrateWithDifferentPasswords()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Mincho",
                                                         "Praznikov",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { true, true, false }),
                                                         "Bulgaria",
                                                         "5",
                                                         "2",
                                                         "1973",
                                                         "7777777777",
                                                         "Golemiq",
                                                         "parcheto@abv.bg",
                                                         @"C:\Users\Djordjiiiiii\Desktop\Testvam\Si\PoPraznicite.jpg",
                                                         "Few more TESTS left!!!",
                                                         "12345678",
                                                         "87654321");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertDifferentPasswordErrorMessage("* Fields do not match");
        }

        [Test, Property("Priority", 2)]
        [Author("Georgi Kostadinov")]
        public void RegistrateWithoutFirstName()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("",
                                                         "Praznikov",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { true, true, false }),
                                                         "Bulgaria",
                                                         "5",
                                                         "2",
                                                         "1973",
                                                         "7777777777",
                                                         "Golemiq",
                                                         "parcheto@abv.bg",
                                                         @"C:\Users\Djordjiiiiii\Desktop\Testvam\Si\PoPraznicite.jpg",
                                                         "Few more TESTS left!!!",
                                                         "12345678",
                                                         "12345678");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);
            regPage.RegistrationFormFirstNameField.Click();
            regPage.RegistrationHoleForm.Click();
            regPage.AssertMissingFirstNameErrorMessage("* This field is required");
        }

        [Test, Property("Priority", 2)]
        [Author("Georgi Kostadinov")]
        public void RegistrateWithAlreadyExistingUserName()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Mincho",
                                                         "Praznikov",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { true, true, false }),
                                                         "Bulgaria",
                                                         "5",
                                                         "2",
                                                         "1973",
                                                         "7777777777",
                                                         "Golemiq",
                                                         "parcheto@abv.bg",
                                                         "",
                                                         "Few more TESTS left!!!",
                                                         "12345678",
                                                         "12345678");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertUserNameAlreadyExsistErrorMessage("Error: Username already exists");
        }

        [Test, Property("Priority", 1)]
        [Author("Georgi Kostadinov")]
        public void RegistrateWithOutLastNameAndPhoneNumber()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Mincho",
                                                         "",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { true, true, true }),
                                                         "Bulgaria",
                                                         "5",
                                                         "2",
                                                         "1973",
                                                         "",
                                                         "Golemiq",
                                                         "parcheto@abv.bg",
                                                         @"C:\Users\Djordjiiiiii\Desktop\Testvam\Si\PoPraznicite.jpg",
                                                         "Few more TESTS left!!!",
                                                         "12345678",
                                                         "12345678");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertNamesErrorMessage("This field is required");
            regPage.AssertPhoneErrorMessage("This field is required");
        }

        [Test, Property("Priority", 1)]
        [Author("Georgi Kostadinov")]
        public void RegistrateWithOutLastNameAndMail()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Mincho",
                                                         "",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { true, true, true }),
                                                         "Bulgaria",
                                                         "5",
                                                         "2",
                                                         "1973",
                                                         "7777777777",
                                                         "Golemiq",
                                                         "",
                                                         @"C:\Users\Djordjiiiiii\Desktop\Testvam\Si\PoPraznicite.jpg",
                                                         "Few more TESTS left!!!",
                                                         "12345678",
                                                         "12345678");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertNamesErrorMessage("This field is required");
            regPage.AssertMailErrorMessage("* This field is required");
        }

        [Test, Property("Priority", 1)]
        [Author("Georgi Kostadinov")]
        public void RegistrateWithOutLastNameAndHobbys()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Mincho",
                                                         "",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { false,false, false}),
                                                         "Bulgaria",
                                                         "5",
                                                         "2",
                                                         "1973",
                                                         "7777777777",
                                                         "Golemiq",
                                                         "parcheto@abv.bg",
                                                         @"C:\Users\Djordjiiiiii\Desktop\Testvam\Si\PoPraznicite.jpg",
                                                         "Few more TESTS left!!!",
                                                         "12345678",
                                                         "12345678");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertNamesErrorMessage("This field is required");
            regPage.AssertHobbysErrorMessage("This field is required");
        }

        [Test, Property("Priority", 1)]
        [Author("Georgi Kostadinov")]
        public void RegistrateWithOutLastNameAndUserName()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Mincho",
                                                         "",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { false, false, false }),
                                                         "Bulgaria",
                                                         "5",
                                                         "2",
                                                         "1973",
                                                         "7777777777",
                                                         "",
                                                         "parcheto@abv.bg",
                                                         @"C:\Users\Djordjiiiiii\Desktop\Testvam\Si\PoPraznicite.jpg",
                                                         "Few more TESTS left!!!",
                                                         "12345678",
                                                         "12345678");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertNamesErrorMessage("This field is required");
            regPage.AssertUserNameErrorMessage("* This field is required");
        }

        [Test, Property("Priority", 1)]
        [Author("Georgi Kostadinov")]
        public void RegistrateWithOutLastNameAndPassword()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Mincho",
                                                         "",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { false, false, false }),
                                                         "Bulgaria",
                                                         "5",
                                                         "2",
                                                         "1973",
                                                         "7777777777",
                                                         "Golemiq",
                                                         "parcheto@abv.bg",
                                                         @"C:\Users\Djordjiiiiii\Desktop\Testvam\Si\PoPraznicite.jpg",
                                                         "Few more TESTS left!!!",
                                                         "",
                                                         "12345678");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertNamesErrorMessage("This field is required");
            regPage.AssertPasswordErrorMessage("* This field is required");
        }


        public void Type(IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }
    }
}
