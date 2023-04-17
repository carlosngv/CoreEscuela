using System;
using CoreEscuela.Entities;

namespace CoreEscuela.App
{
	public class Reporter
	{
		Dictionary<DictionaryKeys, IEnumerable<SchoolBase>> _dict;

        public Reporter(Dictionary<DictionaryKeys, IEnumerable<SchoolBase>> schoolBaseDic)
		{
			if(schoolBaseDic == null)
			{
				throw new ArgumentNullException(nameof(schoolBaseDic));
			}
			_dict = schoolBaseDic;
		}

		public IEnumerable<School> GetEvaluationsList()
		{

			IEnumerable<School> schoolRes;
			var res = _dict.TryGetValue(DictionaryKeys.School, out IEnumerable<SchoolBase> list);

			if(res)
			{
				schoolRes = list.Cast<School>();
            }
			else
			{
				schoolRes = null;
				// Escribir en log
			}

			return schoolRes;
		}
	}
}

