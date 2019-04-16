using System;
using System.Collections.Generic;

using RSignSDK.Models;
using RSignSDK.Models.MasterData;

namespace RSignSDK.Contracts
{
    public interface IRSignAPI : IDisposable
    {
        InitializeEnvelopeResponse InitializeEnvelope(InitializeEnvelopeRequest request);

        UseTemplateResponse UseTemplate(UseTemplateRequest request);

        AddUpdateReceipientResponse AddUpdateRecipient(AddUpdateRecipientRequest request);

        PrepareEnvelopeResponse PrepareEnvelope(PrepareEnvelopeRequest request);

        SendEnvelopeResponse SendEnvelope(SendEnvelopeRequest request);

        IEnumerable<Template> GetTemplates();

        IEnumerable<Rule> GetRules();

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

        IEnumerable<RuleConfiguration> GetRuleConfigurations();

        IEnumerable<SettingsForType> GetSettingsForTypes();

        IEnumerable<SettingsKeyConfiguration> GetSettingsKeyConfigurations();

        IEnumerable<ShowSettingsTab> GetShowSettingsTabs();

        IEnumerable<string> GetSignatureFonts();

        IEnumerable<SignatureType> GetSignatureTypes();

        IEnumerable<SignFontStyle> GetSignFontStyles();

        IEnumerable<StatusCode> GetStatusCodes();

        IEnumerable<TextType> GetTextTypes();

        IEnumerable<Models.MasterData.TimeZone> GetTimeZones();

        IEnumerable<UserConstant> GetUserConstants();

        IEnumerable<UserType> GetUserTypes();

        #endregion Master Data
    }
}