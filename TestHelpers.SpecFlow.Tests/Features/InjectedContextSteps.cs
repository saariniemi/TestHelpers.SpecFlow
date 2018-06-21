using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Xunit;

namespace TestHelpers.SpecFlow.Tests.Features
{
    [Binding]
    public class InjectedContextSteps : SpecFlowStepDefinitionBase
    {
        public InjectedContextSteps(ScenarioContext context) : base(context)
        {
        }

        [Given(@"I have called Set with value ""([^""]*)""$")]
        public void GivenIHaveCalledSetWithValue(string value)
        {
            Set(value);
        }

        [Given(@"I have called Set with value ""([^""]*)"" and key ""([^""]*)""")]
        public void GivenIHaveCalledSetWithValueAndKey(string value, string key)
        {
            Set(value, key);
        }

        [When(@"I call Get<string>")]
        public void WhenICallGetString()
        {
            var result = Get<string>();

            Set(result, "Result");
        }

        [When(@"I call GetOrSet<string> with default value ""([^""]*)""")]
        public void WhenICallGetOrSetString(string defaultValue)
        {
            var result = GetOrSet(defaultValue);

            Set(result, "Result");
        }

        [When(@"I call Get<string> with key ""([^""]*)""")]
        public void WhenICallGetStringWithKey(string key)
        {
            var result = Get<string>(key);

            Set(result, "Result");
        }

        [When(@"I call GetOrSet<string> with key ""([^""]*)"" and default value ""([^""]*)""")]
        public void WhenICallGetOrSetStringWithKey(string key, string defaultValue)
        {
            var result = GetOrSet(key, defaultValue);

            Set(result, "Result");
        }

        [Then(@"the result is ""(.*)""")]
        public void ThenTheResultIs(string expectedResult)
        {
            var result = Get<string>("Result");

            Assert.Equal(expectedResult, result);
        }

        [Then(@"the next call to Get<string> returns ""([^""]*)""")]
        public void ThenTheNextCallToGetReturns(string expectedValue)
        {
            Assert.Equal(expectedValue, Get<string>());
        }

        [Then(@"the next call to Get<string> with key ""([^""]*)"" returns ""([^""]*)""")]
        public void ThenTheNextCallToGetWithKeyReturns(string key, string expectedValue)
        {
            Assert.Equal(expectedValue, Get<string>(key));
        }

    }
}
