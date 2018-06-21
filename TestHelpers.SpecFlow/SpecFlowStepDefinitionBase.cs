using System;
using TechTalk.SpecFlow;

namespace TestHelpers.SpecFlow
{
    [Binding]
    public abstract class SpecFlowStepDefinitionBase
    {
        private readonly ScenarioContext scenarioContext;

        protected SpecFlowStepDefinitionBase(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }
        
        protected T Get<T>(string key = null)
        {
            var qualifiedKey = GenerateKey<T>(key);
            if (scenarioContext.TryGetValue<T>(qualifiedKey, out T value))
            {
                return value;
            }
            throw new ArgumentOutOfRangeException(qualifiedKey, "Nothing is setup for key " + qualifiedKey);
        }

        protected T GetOrSet<T>(string key, T defaultInstance)
        {
            var qualifiedKey = GenerateKey<T>(key);
            return scenarioContext.TryGetValue<T>(qualifiedKey, out T value) ? value : Set(defaultInstance, key);
        }

        protected T GetOrSet<T>(T defaultInstance)
        {
            return GetOrSet<T>(null, defaultInstance);
        }

        protected T GetWithDefault<T>(T defaultValue, string key = null)
        {
            var qualifiedKey = GenerateKey<T>(key);
            if (scenarioContext.TryGetValue<T>(qualifiedKey, out T value))
            {
                return value;
            }

            return defaultValue;
        }

        protected T GetOrDefault<T>(Func<T> defaultValue = null, string key = null)
        {
            var qualifiedKey = GenerateKey<T>(key);
            if (scenarioContext.TryGetValue<T>(qualifiedKey, out T value))
            {
                return value;
            }

            return defaultValue != null ? defaultValue() : default(T);
        }

        protected T Set<T>(T value, string key = null)
        {
            var qualifiedKey = GenerateKey<T>(key);
            scenarioContext.Set(value, qualifiedKey);
            return value;
        }

        private string GenerateKey<T>(string key = null)
        {
            return key != null ? $"{typeof(T).Name}.{key}" : typeof(T).Name;
        }
    }
}