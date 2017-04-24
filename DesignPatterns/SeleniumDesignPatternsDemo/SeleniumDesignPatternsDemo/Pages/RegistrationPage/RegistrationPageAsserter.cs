using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumDesignPatterns.Pages.RegistrationPage
{
    public static class RegistrationPageAsserter
    {
        public static void AssertRegistrationPageIsOpen(this RegistrationPage page, string text)
        {
            Assert.AreEqual(text, page.Header.Text);
        }

        public static void AssesrtSuccessMessage(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.SuccessMessage.Displayed);
            Assert.AreEqual(text, page.SuccessMessage.Text);
        }

        public static void AssertNamesErrorMessage(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessagesForNames.Displayed);
            StringAssert.Contains(text, page.ErrorMessagesForNames.Text);
        }

        public static void AssertPhoneErrorMessage(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessagesForPhone.Displayed);
            StringAssert.Contains(text, page.ErrorMessagesForPhone.Text);
        }

        public static void AssertHobbysErrorMessage(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessagesForHobbys.Displayed);
            StringAssert.Contains(text, page.ErrorMessagesForHobbys.Text);
        }

        public static void AssertInvalidPhoneErrorMessage(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessageForInvalidPhone.Displayed);
            StringAssert.Contains(text, page.ErrorMessageForInvalidPhone.Text);
        }

        public static void AssertUserNameErrorMessage(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessageForUserName.Displayed);
            StringAssert.Contains(text, page.ErrorMessageForUserName.Text);
        }

        public static void AssertMailErrorMessage(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessageForMail.Displayed);
            StringAssert.Contains(text, page.ErrorMessageForMail.Text);
        }

        public static void AssertInvalidMailErrorMessage(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessageForInvalidMail.Displayed);
            StringAssert.Contains(text, page.ErrorMessageForInvalidMail.Text);
        }

        public static void AssertInvalidUploadFile(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessageForInvalidUploadFileFormat.Displayed);
            StringAssert.Contains(text, page.ErrorMessageForInvalidUploadFileFormat.Text);
        }

        public static void AssertPasswordErrorMessage(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessageForMissingPassword.Displayed);
            StringAssert.Contains(text, page.ErrorMessageForMissingPassword.Text);
        }

        public static void AssertConfirmPasswordErrorMessage(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessageForMissingConfirmPassword.Displayed);
            StringAssert.Contains(text, page.ErrorMessageForMissingConfirmPassword.Text);
        }

        public static void AssertShortPasswordErrorMessage(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessageForShortPasswordLenght.Displayed);
            StringAssert.Contains(text, page.ErrorMessageForShortPasswordLenght.Text);
        }

        public static void AssertDifferentPasswordErrorMessage(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessageForDifferentPasswords.Displayed);
            StringAssert.Contains(text, page.ErrorMessageForDifferentPasswords.Text);
        }

        public static void AssertMissingFirstNameErrorMessage(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessageForMissingFirstName.Displayed);
            StringAssert.Contains(text, page.ErrorMessageForMissingFirstName.Text);
        }

        public static void AssertUserNameAlreadyExsistErrorMessage(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessagesForUsernameAlreadyExsist.Displayed);
            StringAssert.Contains(text, page.ErrorMessagesForUsernameAlreadyExsist.Text);
        }


    }
}
