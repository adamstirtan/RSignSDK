using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

using RSignSDK.Models;
using RSignSDK.Models.MasterData;

[assembly: InternalsVisibleTo("RSignSDK.Tests")]

namespace RSignSDK.Contracts
{
    internal interface IRSignAPIInternal : IDisposable
    {
        InitializeEnvelopeResponse InitializeEnvelope(InitializeEnvelopeRequest request);

        UseTemplateResponse UseTemplate(UseTemplateRequest request);

        AddUpdateRecipientResponse AddUpdateRecipient(AddUpdateRecipientRequest request);

        UploadLocalDocumentResponse UploadLocalDocument(UploadLocalDocumentRequest request);

        PrepareEnvelopeResponse PrepareEnvelope(PrepareEnvelopeRequest request);

        SendEnvelopeResponse SendEnvelope(SendEnvelopeRequest request);

        DownloadSignedContractResponse DownloadSignedContract(DownloadSignedContractRequest request);

        EnvelopeStatusResponse GetEnvelopeStatus(EnvelopeStatusRequest request);

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