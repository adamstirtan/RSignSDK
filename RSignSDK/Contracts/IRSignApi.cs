using System.Collections.Generic;

using RSignSDK.Models.MasterData;

namespace RSignSDK.Contracts
{
    public interface IRSignAPI
    {
        #region Master Data

        IEnumerable<Control> GetControls();

        IEnumerable<DateFormat> GetDateFormats();

        IEnumerable<DropDownOption> GetDropDownOptions();

        IEnumerable<EnvelopeStatus> GetEnvelopeStatuses();

        IEnumerable<EnvelopeType> GetEnvelopeTypes();

        IEnumerable<ExpiryType> GetExpiryTypes();

        IEnumerable<Font> GetFonts();

        IEnumerable<MailTemplate> GetMailTemplates();

        IEnumerable<MaxCharacter> GetMaxCharacters();

        IEnumerable<RecipientType> GetRecipientTypes();

        IEnumerable<RSignStage> GetRSignStages();

        IEnumerable<RuleConfig> GetRuleConfigs();

        IEnumerable<SettingsForType> GetSettingsForTypes();

        IEnumerable<SettingsKeyConfig> GetSettingsKeyConfigs();

        IEnumerable<ShowSettingsTab> GetShowSettingsTabs();

        IEnumerable<string> GetSignatureFonts();

        IEnumerable<SignatureType> GetSignatureTypes();

        IEnumerable<SignFontStyle> GetSignFontStyles();

        IEnumerable<StatusCode> GetStatusCodes();

        IEnumerable<TextType> GetTextTypes();

        IEnumerable<TimeZone> GetTimeZones();

        IEnumerable<UserConstant> GetUserConstants();

        IEnumerable<UserType> GetUserTypes();

        #endregion Master Data
    }
}