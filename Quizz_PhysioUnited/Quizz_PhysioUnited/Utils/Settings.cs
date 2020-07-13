// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;

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

        private const string LastQuestionNumberSettings = "last_questionNumber_key";

        private const string LastBandCounterSettings = "last_bandCounter_key";
        private const string LastQuestionCounterSettings = "last_questionCounter_key";

        private const string LastScoreSettings = "last_score_key";
        private static readonly string SettingsDefault = string.Empty;

        #endregion


        public static string LastUsedQuestionNumber
        {
            get
            {
                return AppSettings.GetValueOrDefault(LastQuestionNumberSettings, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(LastQuestionNumberSettings, value);
            }
        }

        public static string LastUsedBandCounter
        {
            get
            {
                return AppSettings.GetValueOrDefault(LastBandCounterSettings, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(LastBandCounterSettings, value);
            }
        }

        public static string LastUsedQuestionCounter
        {
            get
            {
                return AppSettings.GetValueOrDefault(LastQuestionCounterSettings, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(LastQuestionCounterSettings, value);
            }
        }

        public static string LastUsedScore
    {
        get
        {
            return AppSettings.GetValueOrDefault(LastScoreSettings, SettingsDefault);
        }
        set
        {
            AppSettings.AddOrUpdateValue(LastScoreSettings, value);
        }
    }

}
}