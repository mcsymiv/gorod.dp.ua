using gorod.dp.ua.POMs;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace gorod.dp.ua.Steps
{
    [Binding]
    public class AdvertisementSteps
    {
        IWebDriver chrome;
        AdvertisementPageObject ad_page;
        AdFormPage form_page;
        EditAdPage editAd_page;


        [Given(@"I on the ad page")]
        public void GivenIOnTheAdPage()
        {
            chrome = new ChromeDriver(@"C:\Users\ЛордКотДотКом\Desktop\WebdriverChrome");
            chrome.Navigate().GoToUrl("https://gorod.dp.ua/gazeta/");
            chrome.Manage().Window.Maximize();
            ad_page = new AdvertisementPageObject(chrome);
            form_page = new AdFormPage(chrome);
            editAd_page = new EditAdPage(chrome);
            chrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [When(@"I want to login to my account with my (.*) (.*)")]
        public void WhenIWantToLoginToMyAccountWithMy(string login, string password)
        {
            ad_page.UserAuthorize(login, password);
        }

        [Given(@"I want to add my ad")]
        public void GivenIWantToAddMyAd()
        {
            ad_page.OpenCarAdForm();
        }

        [When(@"I fill in all necessary fields")]
        public void WhenIFillInAllNecessaryFields()
        {
            form_page.FillNecessaryFieldsAd("продать", "2000", "30000", "2000", "Отличное состояние");
        }

        [When(@"I click on add ad")]
        public void WhenIClickOnAddAd()
        {
            form_page.SubmitAdForm();
        }

        [Then(@"I see thank you message on the page")]
        public void ThenISeeThankYouMessageOnThePage()
        {
            string msg = ad_page.ThankYouMessage();
            Assert.IsTrue(msg.Contains("добавлено и открыто после проверки администратором"));
        }

        [Given(@"Ad form is open")]
        public void GivenAdFormIsOpen()
        {
            ad_page.OpenCarAdForm();
        }

        [When(@"User leaves necessary field empty")]
        public void WhenUserLeavesNecessaryFieldEmpty()
        {
            form_page.SubmitAdForm();
        }

        [Then(@"User see red error message")]
        public void ThenUserSeeRedErrorMessage()
        {
            string errorMsg = ad_page.ErrorMessage();
            Assert.IsTrue(errorMsg.Contains("Ошибка"));
        }
        [AfterScenario]
        public void ClosePage()
        {
            chrome.Quit();
        }

        //edit ad

        [Given(@"ad has been created")]
        public void GivenAdHasBeenCreated()
        {
            
        }

        [When(@"I go to page my ads")]
        public void WhenIGoToPageMyAds()
        {
            //editAd_page.ClickOnTheAdHeader();
            editAd_page.ClickOnTheMyAds();
        }

        [Then(@"I see title on the page my ads")]
        public void ThenISeeTitleOnThePageMyAds()
        {
            string actualResult = editAd_page.TitleMyAds();
            Assert.AreEqual("ОБЪЯВЛЕНИЯ", actualResult);
        }

        [When(@"I click on the edit button")]
        public void WhenIClickOnTheEditButton()
        {
            editAd_page.ClickEditFirstAd();
        }

        [Then(@"I see title placing a new ad")]
        public void ThenISeeTitlePlacingANewAd()
        {
            string actualResult = editAd_page.TitleMyAdsAcc();
            Assert.AreEqual("Размещение нового объявления", actualResult);
        }

        [When(@"I edit text and the address of an ad")]
        public void WhenIEditTextAndTheAddressOfAnAd()
        {
            editAd_page.EditTextAd();
            editAd_page.EditAddressAd();
        }

        [When(@"I click on the share ad")]
        public void WhenIClickOnTheShareAd()
        {
            editAd_page.ClickPublishAd();
        }

        [Then(@"I see text information like please wait admin accepting")]
        public void ThenISeeTextInformationLikePleaseWaitAdminAccepting()
        {
            string actualResult = editAd_page.TextInTheEnd();
            Assert.AreEqual("Спасибо!", actualResult);
        }

    }
}
