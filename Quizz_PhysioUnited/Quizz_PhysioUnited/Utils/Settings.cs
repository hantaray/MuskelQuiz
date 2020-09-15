// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System.Collections.Generic;

namespace Quizz_PhysioUnited.Utils
{
  /// <summary>
  /// This is the Settings static class that can be used in your Core solution or in any
  /// of your client applications. All settings are laid out the same exact way with getters
  /// and setters. 
  /// </summary>
  public static class Settings
{
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants
        //Keys User Settings category 1
        private const string QuestionCounterKatOneSettings = "questionCounter_katOne_key";

        private const string ScoreKatOneSettings = "score_katOne_key";

        private const string TimerValueKatOneSetting = "timerValue_katOne_Key";

        private const string AllQuestionsNumberKatOneSetting = "allQuestionsNr_katOne_Key";

        private const string ChanceBoolKatOneSetting = "chnaceBool_katOne_key";

        //Keys User Settings category 2
        private const string QuestionCounterKatTwoSettings = "questionCounter_katTwo_key";

        private const string ScoreKatTwoSettings = "score_katTwo_key";

        private const string TimerValueKatTwoSetting = "timerValue_kat_Key";

        private const string AllQuestionsNumberKatTwoSetting = "allQuestionsNr_katTwo_Key";

        private const string ChanceBoolKatTwoSetting = "chnaceBool_katTwo_key";

        //Keys User Settings category 3
        private const string QuestionCounterKatThreeSettings = "questionCounter_katThree_key";

        private const string ScoreKatThreeSettings = "score_katThree_key";

        private const string TimerValueKatThreeSetting = "timerValue_katThree_Key";

        private const string AllQuestionsNumberKatThreeSetting = "allQuestionsNr_katThree_Key";

        private const string ChanceBoolKatThreeSetting = "chnaceBool_katThree_key";

        //Keys User Settings category 4
        private const string QuestionCounterKatFourSettings = "questionCounter_katFour_key";

        private const string ScoreKatFourSettings = "score_katFour_key";

        private const string TimerValueKatFourSetting = "timerValue_katFour_Key";

        private const string AllQuestionsNumberKatFourSetting = "allQuestionsNr_katFour_Key";

        private const string ChanceBoolKatFourSetting = "chnaceBool_katFour_key";



        private const string GemsSettings = "last_gems_key";

        //Defaults
        private static readonly string ThirtyAsDefault = "30";

        private static readonly string OneAsDefault = "1";

        private static readonly string ZeroAsDefault = "0";

        private static readonly string SettingsDefault = string.Empty;

        private static readonly string TrueDefault = "True";

        #endregion 

        //Kategorie 1
        public static string QuestionCounterKatOne
        {
            get
            {
                return AppSettings.GetValueOrDefault(QuestionCounterKatOneSettings, OneAsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(QuestionCounterKatOneSettings, value);
            }
        }

        public static string ScoreKatOne
        {
            get
            {
                return AppSettings.GetValueOrDefault(ScoreKatOneSettings, ZeroAsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(ScoreKatOneSettings, value);
            }
        }

        public static string TimerValueKatOne
        {
            get
            {
                return AppSettings.GetValueOrDefault(TimerValueKatOneSetting, ThirtyAsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(TimerValueKatOneSetting, value);
            }
        }

        public static string AllQuestionsNrKatOne
        {
            get
            {
                return AppSettings.GetValueOrDefault(AllQuestionsNumberKatOneSetting, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(AllQuestionsNumberKatOneSetting, value);
            }
        }

        public static string ChanceBoolKatOne
        {
            get
            {
                return AppSettings.GetValueOrDefault(ChanceBoolKatOneSetting, TrueDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(ChanceBoolKatOneSetting, value);
            }
        }

        //Kategorie 2
        public static string QuestionCounterKatTwo
        {
            get
            {
                return AppSettings.GetValueOrDefault(QuestionCounterKatTwoSettings, OneAsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(QuestionCounterKatTwoSettings, value);
            }
        }

        public static string ScoreKatTwo
        {
            get
            {
                return AppSettings.GetValueOrDefault(ScoreKatTwoSettings, ZeroAsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(ScoreKatTwoSettings, value);
            }
        }

        public static string TimerValueKatTwo
        {
            get
            {
                return AppSettings.GetValueOrDefault(TimerValueKatTwoSetting, ThirtyAsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(TimerValueKatTwoSetting, value);
            }
        }

        public static string AllQuestionsNrKatTwo
        {
            get
            {
                return AppSettings.GetValueOrDefault(AllQuestionsNumberKatTwoSetting, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(AllQuestionsNumberKatTwoSetting, value);
            }
        }

        public static string ChanceBoolKatTwo
        {
            get
            {
                return AppSettings.GetValueOrDefault(ChanceBoolKatTwoSetting, TrueDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(ChanceBoolKatTwoSetting, value);
            }
        }

        //Kategorie 3
        public static string QuestionCounterKatThree
        {
            get
            {
                return AppSettings.GetValueOrDefault(QuestionCounterKatThreeSettings, OneAsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(QuestionCounterKatThreeSettings, value);
            }
        }

        public static string ScoreKatThree
        {
            get
            {
                return AppSettings.GetValueOrDefault(ScoreKatThreeSettings, ZeroAsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(ScoreKatThreeSettings, value);
            }
        }

        public static string TimerValueKatThree
        {
            get
            {
                return AppSettings.GetValueOrDefault(TimerValueKatThreeSetting, ThirtyAsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(TimerValueKatThreeSetting, value);
            }
        }

        public static string AllQuestionsNrKatThree
        {
            get
            {
                return AppSettings.GetValueOrDefault(AllQuestionsNumberKatThreeSetting, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(AllQuestionsNumberKatThreeSetting, value);
            }
        }

        public static string ChanceBoolKatThree
        {
            get
            {
                return AppSettings.GetValueOrDefault(ChanceBoolKatThreeSetting, TrueDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(ChanceBoolKatThreeSetting, value);
            }
        }


        //Kategorie 4
        public static string QuestionCounterKatFour
        {
            get
            {
                return AppSettings.GetValueOrDefault(QuestionCounterKatFourSettings, OneAsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(QuestionCounterKatFourSettings, value);
            }
        }

        public static string ScoreKatFour
        {
            get
            {
                return AppSettings.GetValueOrDefault(ScoreKatFourSettings, ZeroAsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(ScoreKatFourSettings, value);
            }
        }

        public static string TimerValueKatFour
        {
            get
            {
                return AppSettings.GetValueOrDefault(TimerValueKatFourSetting, ThirtyAsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(TimerValueKatFourSetting, value);
            }
        }

        public static string AllQuestionsNrKatFour
        {
            get
            {
                return AppSettings.GetValueOrDefault(AllQuestionsNumberKatFourSetting, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(AllQuestionsNumberKatFourSetting, value);
            }
        }

        //Gems
        public static string Gems
        {
            get
            {
                return AppSettings.GetValueOrDefault(GemsSettings, ZeroAsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(GemsSettings, value);
            }
        }

        public static string ChanceBoolKatFour
        {
            get
            {
                return AppSettings.GetValueOrDefault(ChanceBoolKatFourSetting, TrueDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(ChanceBoolKatFourSetting, value);
            }
        }

    }
}