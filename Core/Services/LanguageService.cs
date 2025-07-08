using Core.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Core;

namespace Core.Services
{
    public class LanguageService : ILanguageService
    {
        private readonly ResourceManager _resourceManager;

        public LanguageService()
        {
            _resourceManager = new ResourceManager(typeof(Core.Resources.Resources));
        }

        public string GetString(string key)
        {
            string value = (string)_resourceManager.GetObject(key);
            return value;
        }

        public void SetLanguage(string language)
        {
            var culture = new CultureInfo(language);

            Thread.CurrentThread.CurrentUICulture = culture;
            Thread.CurrentThread.CurrentCulture = culture;

            // Si la clase estuviera en PresentationLayer
            //Properties.Settings.Default.Save();
        }

        public static class Messages
        {
            // group types
            // Ok, Error, Alert, Ask, Other

            public const string AlertCategoryDeleted = "AlertCategoryDeleted";
            public const string AlertInvalidNameField = "AlertInvalidNameField";
            public const string AlertSelectAFilter = "AlertSelectAFilter";
            public const string AlertSelectOneArticle = "AlertSelectOneArticle";
            public const string AlertSelectOneCategory = "AlertSelectOneCategory";
            public const string AskDeleteSelectedItems = "AskDeleteSelectedItems";
            public const string OkArticleCreated = "OkArticleCreated";
            public const string OkArticlesDeleted = "OkArticlesDeleted";
            public const string OkArticleUpdated= "OkArticleUpdated";
            public const string OkCaregoryCreated = "OkCaregoryCreated";
            public const string OkCategoriesDeleted = "OkCategoriesDeleted";
            public const string OkCountFindResults = "OkCountFindResults";
            public const string OkNotFindResults = "OkNoFindResults";
        }

        public static class Controls
        {
            // main
            public const string btnArt = "btnArt";
            public const string btnCat = "btnCat";
            public const string btnReports = "btnReports";
            public const string lnkAbout = "lnkAbout";

            // articles
            public const string btnCreateA = "btnCreateA";
            public const string btnEditA = "btnEditA";
            public const string btnDeleteA = "btnDeleteA";
            public const string btnShowAllA = "btnShowAllA";
            public const string btnSearchA = "btnSearchA";
            public const string grpFiltersA = "grpFiltersA";

            // categories
            public const string btnCreateC = "btnCreateC";
            public const string btnDeleteC = "btnDeleteC";
        }
    }
}
