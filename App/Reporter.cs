using System;
using System.Linq;
using System.Collections.Generic;
using SchoolSharp.DictionaryKeys;
using SchoolSharp.Entities;

namespace SchoolSharp.App
{
    public class Reporter
    {
        private Dictionary<DictionaryKeysEnum, IEnumerable<BaseSchool>> _dictionary;
        
        public Reporter(Dictionary<DictionaryKeysEnum, IEnumerable<BaseSchool>> dic)
        {
            if (dic == null)
            {
                throw new ArgumentNullException(nameof(dic));
            }
            _dictionary = dic;
        }

        public IEnumerable<Exam> GetExamsList()
        {
            if (_dictionary.TryGetValue(DictionaryKeysEnum.Exams, out IEnumerable<BaseSchool> list))
            {
                return list.Cast<Exam>();
            }

            return new List<Exam>();
        }
    }
}