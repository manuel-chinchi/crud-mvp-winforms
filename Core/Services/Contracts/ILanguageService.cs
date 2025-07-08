using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Contracts
{
    public interface ILanguageService
    {
        void SetLanguage(string language);
        string GetString(string key);
    }
}
