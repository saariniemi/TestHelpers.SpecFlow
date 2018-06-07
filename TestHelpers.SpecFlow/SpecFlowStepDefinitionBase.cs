using System;
using TechTalk.SpecFlow;

namespace TestHelpers.SpecFlow
{
    public class SpecFlowStepDefinitionBase
    {
        public T Get<T>(string key = null)
        {
            var qualifiedKey = GenerateKey<T>(key);
            T value;
            if (ScenarioContext.Current.TryGetValue<T>(qualifiedKey, out value))
            {
                return value;
            }
            throw new ArgumentOutOfRangeException(qualifiedKey, "Nothing is setup for key " + qualifiedKey);
        }

        public T GetOrSet<T>(string key, T defaultInstance)
        {
            var qualifiedKey = GenerateKey<T>(key);
            T value;
            return ScenarioContext.Current.TryGetValue<T>(qualifiedKey, out value) ? value : Set(defaultInstance, key);
        }

        public T GetWithDefault<T>(T defaultValue, string key = null)
        {
            var qualifiedKey = GenerateKey<T>(key);
            T value;
            if (ScenarioContext.Current.TryGetValue<T>(qualifiedKey, out value))
            {
                return value;
            }

            return defaultValue;
        }

        public T GetOrDefault<T>(Func<T> defaultValue = null, string key = null)
        {
            var qualifiedKey = GenerateKey<T>(key);
            T value;
            if (ScenarioContext.Current.TryGetValue<T>(qualifiedKey, out value))
            {
                return value;
            }

            return defaultValue != null ? defaultValue() : default(T);
        }

        public T Set<T>(T value, string key = null)
        {
            var qualifiedKey = GenerateKey<T>(key);
            ScenarioContext.Current.Set(value, qualifiedKey);
            return value;
        }

        private string GenerateKey<T>(string key = null)
        {
            return key != null ? $"{typeof(T).Name}.{key}" : typeof(T).Name;
        }
    }
}