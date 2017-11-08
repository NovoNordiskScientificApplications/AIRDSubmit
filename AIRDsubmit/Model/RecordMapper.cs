using AIRDsubmit.AIRD.Service;
using System;
using System.Collections.Generic;

namespace AIRDsubmit
{
    public static class RecordMapper
    {
        public static T map<T>(string input, Dictionary<string, T> a)
        {
            if(input == null && Nullable.GetUnderlyingType(typeof(T)) != null)
                return default(T);
            
            if(a.ContainsKey(input ?? string.Empty))
                return a[input ?? string.Empty];
            else
                throw new Exception(input + " is not a valid entry. Please select a valid entry from the list");
        }

        public static ReportingInfo RecordToReportingInfo(Record r)
        {
            var reportingInfo = new ReportingInfo();

            reportingInfo.ApprovalReportingCaptiaIdLink = r.Permission;
            reportingInfo.Species = map(r.Species, SpeciesStringToEnum);
            reportingInfo.SpeciesOther = r.SpeciesOther;
            reportingInfo.NoOfAnimals = r.Number;
            reportingInfo.Reuse = map(r.Reuse, ReuseStringToEnum);
            reportingInfo.PlaceOfBirth = map(r.PlaceOfBirth, PlaceOfBirthStringToEnum);
            reportingInfo.NHPSource = map(r.NHPSource, NHPSourceStringToEnum);
            reportingInfo.NHPGeneration = map(r.NHPGeneration, NHPGenerationStringToEnum);
            reportingInfo.GeneticStatus = map(r.GeneticStatus, GeneticStatusStringToEnum);
            reportingInfo.CreationOfNewGL = map(r.CreationOfGeneticLine, CreationOfGeneticLineStringToEnum);
            reportingInfo.Purpose = map(r.Purpose, PurposeStringToEnum);
            reportingInfo.PurposeOther = r.PurposeOther;
            reportingInfo.TestingByLegislation = map(r.TestingByLegislation, TestingByLegislationStringToEnum);
            reportingInfo.TestingByLegislationOther = r.TestingByLegislationOther;
            reportingInfo.LegislativeRequirements = map(r.LegislativeRequirements, LegislativeRequirementsStringToEnum);
            reportingInfo.Severity = map(r.Severity, SeverityStringToEnum);
            reportingInfo.CustomSeverity = r.CustomSeverity;
            reportingInfo.Comments1 = r.Comments1;
            reportingInfo.Comments2 = r.Comments2;
            reportingInfo.ReportingYear = r.Year;
            reportingInfo.ApprovalUnitReportingLinks = new ApprovalUnitReportingLink[] { };
            return reportingInfo;
        }

        public static Dictionary<string, bool> CreationOfGeneticLineStringToEnum = new Dictionary<string, bool> {
            { App.Settings["NO"], false },
            { App.Settings["YES"], true }
        };

        public static Dictionary<string, bool> ReuseStringToEnum = new Dictionary<string, bool> {
            { App.Settings["NO"], false },
            { App.Settings["YES"], true }
        };

        public static Dictionary<string, NHPGeneration?> NHPGenerationStringToEnum = new Dictionary<string, NHPGeneration?> {
            { string.Empty, null },
            { App.Settings["NHPG1"], NHPGeneration.NHPG1 },
            { App.Settings["NHPG2"], NHPGeneration.NHPG2 },
            { App.Settings["NHPG3"], NHPGeneration.NHPG3 },
            { App.Settings["NHPG4"], NHPGeneration.NHPG4 }
        };

        public static Dictionary<string, NHPSource?> NHPSourceStringToEnum = new Dictionary<string, NHPSource?> {
            { string.Empty, null },
            { App.Settings["NHPO1"], NHPSource.NHPO1 },
            { App.Settings["NHPO2"], NHPSource.NHPO2 },
            { App.Settings["NHPO3"], NHPSource.NHPO3 },
            { App.Settings["NHPO4"], NHPSource.NHPO4 },
            { App.Settings["NHPO5"], NHPSource.NHPO5 },
            { App.Settings["NHPO6"], NHPSource.NHPO6 }
        };

        public static Dictionary<string, GeneticStatus> GeneticStatusStringToEnum = new Dictionary<string, GeneticStatus> {
            { App.Settings["GS1"], GeneticStatus.GS1 },
            { App.Settings["GS2"], GeneticStatus.GS2 },
            { App.Settings["GS3"], GeneticStatus.GS3 }
        };

        public static Dictionary<string, LegislativeRequirements> LegislativeRequirementsStringToEnum = new Dictionary<string, LegislativeRequirements> {
            { string.Empty, LegislativeRequirements.LO1 },
            { App.Settings["LO1"], LegislativeRequirements.LO1 },
            { App.Settings["LO2"], LegislativeRequirements.LO2 },
            { App.Settings["LO3"], LegislativeRequirements.LO3 }
        };

        public static Dictionary<string, TestingByLegislation?> TestingByLegislationStringToEnum = new Dictionary<string, TestingByLegislation?> {
            { string.Empty, null },
            { App.Settings["LT1"], TestingByLegislation.LT1 },
            { App.Settings["LT2"], TestingByLegislation.LT2 },
            { App.Settings["LT3"], TestingByLegislation.LT3 },
            { App.Settings["LT4"], TestingByLegislation.LT4 },
            { App.Settings["LT5"], TestingByLegislation.LT5 },
            { App.Settings["LT6"], TestingByLegislation.LT6 },
            { App.Settings["LT7"], TestingByLegislation.LT7 },
            { App.Settings["LT8"], TestingByLegislation.LT8 },
            { App.Settings["LT9"], TestingByLegislation.LT9 },
            { App.Settings["LT10"], TestingByLegislation.LT10 }
        };

        public static Dictionary<string, PlaceOfBirth> PlaceOfBirthStringToEnum = new Dictionary<string, PlaceOfBirth> {
            { App.Settings["O1"], PlaceOfBirth.O1 },
            { App.Settings["O2"], PlaceOfBirth.O2 },
            { App.Settings["O3"], PlaceOfBirth.O3 },
            { App.Settings["O4"], PlaceOfBirth.O4 }
        };

        public static Dictionary<string, Purpose> PurposeStringToEnum = new Dictionary<string, Purpose>
             {
            { App.Settings["PB1"], Purpose.PB1 },
            { App.Settings["PB2"], Purpose.PB2 },
            { App.Settings["PB3"], Purpose.PB3 },
            { App.Settings["PB4"], Purpose.PB4 },
            { App.Settings["PB5"], Purpose.PB5 },
            { App.Settings["PB6"], Purpose.PB6 },
            { App.Settings["PB7"], Purpose.PB7 },
            { App.Settings["PB8"], Purpose.PB8 },
            { App.Settings["PB9"], Purpose.PB9 },
            { App.Settings["PB10"], Purpose.PB10 },
            { App.Settings["PB11"], Purpose.PB11 },
            { App.Settings["PB12"], Purpose.PB12 },
            { App.Settings["PB13"], Purpose.PB13 },
            { App.Settings["PT21"], Purpose.PT21 },
            { App.Settings["PT22"], Purpose.PT22 },
            { App.Settings["PT23"], Purpose.PT23 },
            { App.Settings["PT24"], Purpose.PT24 },
            { App.Settings["PT25"], Purpose.PT25 },
            { App.Settings["PT26"], Purpose.PT26 },
            { App.Settings["PT27"], Purpose.PT27 },
            { App.Settings["PT28"], Purpose.PT28 },
            { App.Settings["PT29"], Purpose.PT29 },
            { App.Settings["PT30"], Purpose.PT30 },
            { App.Settings["PT31"], Purpose.PT31 },
            { App.Settings["PT32"], Purpose.PT32 },
            { App.Settings["PT33"], Purpose.PT33 },
            { App.Settings["PT34"], Purpose.PT34 },
            { App.Settings["PT35"], Purpose.PT35 },
            { App.Settings["PT36"], Purpose.PT36 },
            { App.Settings["PT37"], Purpose.PT37 },
            { App.Settings["PE40"], Purpose.PE40 },
            { App.Settings["PS41"], Purpose.PS41 },
            { App.Settings["PE42"], Purpose.PE42 },
            { App.Settings["PF43"], Purpose.PF43 },
            { App.Settings["PG43"], Purpose.PG43 },
            { App.Settings["PR51"], Purpose.PR51 },
            { App.Settings["PR52"], Purpose.PR52 },
            { App.Settings["PR53"], Purpose.PR53 },
            { App.Settings["PR61"], Purpose.PR61 },
            { App.Settings["PR62"], Purpose.PR62 },
            { App.Settings["PR63"], Purpose.PR63 },
            { App.Settings["PR64"], Purpose.PR64 },
            { App.Settings["PR71"], Purpose.PR71 },
            { App.Settings["PR81"], Purpose.PR81 },
            { App.Settings["PR82"], Purpose.PR82 },
            { App.Settings["PR83"], Purpose.PR83 },
            { App.Settings["PR84"], Purpose.PR84 },
            { App.Settings["PR85"], Purpose.PR85 },
            { App.Settings["PR86"], Purpose.PR86 },
            { App.Settings["PR87"], Purpose.PR87 },
            { App.Settings["PR88"], Purpose.PR88 },
            { App.Settings["PR89"], Purpose.PR89 },
            { App.Settings["PR90"], Purpose.PR90 },
            { App.Settings["PR91"], Purpose.PR91 },
            { App.Settings["PR92"], Purpose.PR92 },
            { App.Settings["PR93"], Purpose.PR93 },
            { App.Settings["PR94"], Purpose.PR94 },
            { App.Settings["PR95"], Purpose.PR95 },
            { App.Settings["PR96"], Purpose.PR96 },
            { App.Settings["PR97"], Purpose.PR97 },
            { App.Settings["PR98"], Purpose.PR98 },
            { App.Settings["PR99"], Purpose.PR99 },
            { App.Settings["PR100"], Purpose.PR100 },
            { App.Settings["PR101"], Purpose.PR101 },
            { App.Settings["PR102"], Purpose.PR102 },
            { App.Settings["PR103"], Purpose.PR103 },
            { App.Settings["PR104"], Purpose.PR104 },
            { App.Settings["PR105"], Purpose.PR105 },
            { App.Settings["PR106"], Purpose.PR106 },
        };

        public static Dictionary<string, Specie> SpeciesStringToEnum = new Dictionary<string, Specie> {
            { App.Settings["A1"], Specie.A1 },
            { App.Settings["A2"], Specie.A2 },
            { App.Settings["A3"], Specie.A3 },
            { App.Settings["A4"], Specie.A4 },
            { App.Settings["A5"], Specie.A5 },
            { App.Settings["A6"], Specie.A6 },
            { App.Settings["A7"], Specie.A7 },
            { App.Settings["A8"], Specie.A8 },
            { App.Settings["A9"], Specie.A9 },
            { App.Settings["A10"], Specie.A10 },
            { App.Settings["A11"], Specie.A11 },
            { App.Settings["A12"], Specie.A12 },
            { App.Settings["A13"], Specie.A13 },
            { App.Settings["A14"], Specie.A14 },
            { App.Settings["A15"], Specie.A15 },
            { App.Settings["A16"], Specie.A16 },
            { App.Settings["A17"], Specie.A17 },
            { App.Settings["A18"], Specie.A18 },
            { App.Settings["A19"], Specie.A19 },
            { App.Settings["A20"], Specie.A20 },
            { App.Settings["A21"], Specie.A21 },
            { App.Settings["A22"], Specie.A22 },
            { App.Settings["A23"], Specie.A23 },
            { App.Settings["A24"], Specie.A24 },
            { App.Settings["A25"], Specie.A25 },
            { App.Settings["A26"], Specie.A26 },
            { App.Settings["A27"], Specie.A27 },
            { App.Settings["A28"], Specie.A28 },
            { App.Settings["A29"], Specie.A29 },
            { App.Settings["A30"], Specie.A30 },
            { App.Settings["A31"], Specie.A31 },
            { App.Settings["A32"], Specie.A32 },
            { App.Settings["A33"], Specie.A33 },
            { App.Settings["A34"], Specie.A34 },
            { App.Settings["A35"], Specie.A35 },
            { App.Settings["A36"], Specie.A36 }
        };

        public static Dictionary<string, Severity> SeverityStringToEnum = new Dictionary<string, Severity> {
            { App.Settings["SV1"], Severity.SV1 },
            { App.Settings["SV2"], Severity.SV2 },
            { App.Settings["SV3"], Severity.SV3 },
            { App.Settings["SV4"], Severity.SV4 }
        };
    }
}
