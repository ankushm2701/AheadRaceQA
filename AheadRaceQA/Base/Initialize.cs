using AheadRaceTest.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System;
using System.Configuration;
using TechTalk.SpecFlow;
//[assembly:Parallelizable(ParallelScope.Fixtures)]

namespace AheadRaceTest.Base
{
    [Binding]
    class Initialize 
    {
        private readonly ScenarioContext _scenarioContext;
        public Initialize(ScenarioContext scenarioContext) => _scenarioContext = scenarioContext;

        [BeforeScenario]
        public void InitializeBrowser()
        {
            Setting s = new Setting(_scenarioContext);
            _scenarioContext.Set(s, "Setting");         
        } 

        [AfterScenario]
        public void TearDown()
        {
            _scenarioContext.Get<IWebDriver>("WebDriver").Quit();
        } 
    }
}
