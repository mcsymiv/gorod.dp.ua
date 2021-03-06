﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gorod.dp.ua.POMs
{
    public class EditAdPage
    {

        IWebDriver _driver;
        public EditAdPage(IWebDriver driver)
        {
            this._driver = driver;
        }

        By _adButtonHeader = By.CssSelector("#navbarNav > ul > li:nth-child(7) > a");
        By _myAds = By.CssSelector("body > div.container > div:nth-child(10) > div.contentbox2 > div:nth-child(2) > div > table:nth-child(2) > tbody > tr:nth-child(2) > td.norm9 > ul > li:nth-child(1) > a");
        By _editMyFirstAd = By.CssSelector("body > div.container > div:nth-child(10) > div.contentbox > table.norm9 > tbody > tr:nth-child(2) > td:nth-child(5) > a:nth-child(1) > img");
        By _textFieldOfAd = By.CssSelector("body > div.container > div:nth-child(10) > div.contentbox > form > table:nth-child(5) > tbody > tr:nth-child(5) > td.norm8 > textarea");
        By _addressFieldOfAd = By.CssSelector("body > div.container > div:nth-child(10) > div.contentbox > form > table:nth-child(5) > tbody > tr:nth-child(13) > td.norm8 > textarea");
        By _publishAdButton = By.CssSelector("body > div.container > div:nth-child(10) > div.contentbox > form > table:nth-child(5) > tbody > tr:nth-child(16) > td.norm8 > input");
        By _titleMyAd = By.CssSelector("body > div.container > div.content_pagename > h4 > a");
        By _titleMyAddsAcc = By.CssSelector("body > div.container > div:nth-child(10) > div.contentbox > h1");
        By _textAfterEdit = By.CssSelector("body > div.container > div:nth-child(10) > div.contentbox > div > b:nth-child(1)");

        public EditAdPage ClickOnTheAdHeader()
        {
            _driver.FindElement(_adButtonHeader).Click();
            return this;
        }

        public EditAdPage ClickOnTheMyAds()
        {
            _driver.FindElement(_myAds).Click();
            return this;
        }

        public EditAdPage ClickEditFirstAd()
        {
            _driver.FindElement(_editMyFirstAd).Click();
            return this;
        }

        public EditAdPage EditTextAd()
        {
            _driver.FindElement(_textFieldOfAd).Click();
            _driver.FindElement(_textFieldOfAd).SendKeys("this ad has been edited!");
            return this;
        }

        public EditAdPage EditAddressAd()
        {
            _driver.FindElement(_addressFieldOfAd).Click();
            _driver.FindElement(_addressFieldOfAd).SendKeys("flat 10");
            return this;
        }

        public EditAdPage ClickPublishAd()
        {
            _driver.FindElement(_publishAdButton).Click();
            return this;
        }

        public string TitleMyAds()
        {
            string temp = _driver.FindElement(_titleMyAd).Text;
            return temp;
        }

        public string TitleMyAdsAcc()
        {
            string temp = _driver.FindElement(_titleMyAddsAcc).Text;
            return temp;
        }

        public string TextInTheEnd()
        {
            string temp = _driver.FindElement(_textAfterEdit).Text;
            return temp;
        }

    }
}
