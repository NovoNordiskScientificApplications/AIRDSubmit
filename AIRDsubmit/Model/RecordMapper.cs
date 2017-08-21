using AIRDsubmit.AIRD.Service;
using AIRDsubmit.Properties;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AIRDsubmit
{
    public static class RecordMapper
    {
        public static T map<T>(string input, Dictionary<string, T> a)
        {
            if(input == null && Nullable.GetUnderlyingType(typeof(T)) != null)
                return default(T);
            
            if(a.ContainsKey(input ?? string.Empty))
                try
                {
                    return a[input ?? string.Empty];
                }
                catch
                {
                    throw new Exception(input + " is not a valid entry. Please select a valid entry from the list");
                }
            else
                throw new Exception(input + " is not a valid entry. Please select a valid entry from the list");
        }

        public static ReportingInfo RecordToReportingInfo(Record r)
        {
            var reportingInfo = new ReportingInfo();

            reportingInfo.ApprovalReportingCaptiaIdLink = r.Permission;
            reportingInfo.Species = map(r.Species, SpeciesStringToEnum);
            reportingInfo.SpeciesOther = r.SpeciesOther ?? string.Empty;
            reportingInfo.NoOfAnimals = r.Number;
            reportingInfo.Reuse = map(r.Reuse, ReuseStringToEnum);
            reportingInfo.PlaceOfBirth = map(r.PlaceOfBirth, PlaceOfBirthStringToEnum);
            reportingInfo.NHPSource = map(r.NHPSource, NHPSourceStringToEnum);
            reportingInfo.NHPGeneration = map(r.NHPGeneration, NHPGenerationStringToEnum);
            reportingInfo.GeneticStatus = map(r.GeneticStatus, GeneticStatusStringToEnum);
            reportingInfo.CreationOfNewGL = map(r.CreationOfGeneticLine, CreationOfGeneticLineStringToEnum);
            reportingInfo.Purpose = map(r.Purpose, PurposeStringToEnum);
            reportingInfo.PurposeOther = r.PurposeOther ?? string.Empty;
            reportingInfo.TestingByLegislation = map(r.TestingByLegislation, TestingByLegislationStringToEnum);
            reportingInfo.TestingByLegislationOther = r.TestingByLegislationOther ?? string.Empty;
            reportingInfo.LegislativeRequirements = map(r.LegislativeRequirements, LegislativeRequirementsStringToEnum);
            reportingInfo.Severity = map(r.Severity, SeverityStringToEnum);
            reportingInfo.CustomSeverity = r.CustomSeverity ?? string.Empty;
            reportingInfo.Comments1 = r.Comments1 ?? string.Empty;
            reportingInfo.Comments2 = r.Comments2 ?? string.Empty;
            reportingInfo.ReportingYear = r.Year;
            reportingInfo.ApprovalUnitReportingLinks = new ApprovalUnitReportingLink[] { };
            return reportingInfo;
        }

        public static Dictionary<string, bool> CreationOfGeneticLineStringToEnum = new Dictionary<string, bool> {
            { "[N] No", false },
            { "[Y] Yes", true }
        };

        public static Dictionary<string, bool> ReuseStringToEnum = new Dictionary<string, bool> {
            { "[N] No", false },
            { "[Y] Yes", true }
        };

        public static Dictionary<string, NHPGeneration?> NHPGenerationStringToEnum = new Dictionary<string, NHPGeneration?> {
            { string.Empty, null },
            { Resources.NHPG1, NHPGeneration.NHPG1 },
            { Resources.NHPG2, NHPGeneration.NHPG2 },
            { Resources.NHPG3, NHPGeneration.NHPG3 },
            { Resources.NHPG4, NHPGeneration.NHPG4 }
        };

        public static Dictionary<string, NHPSource?> NHPSourceStringToEnum = new Dictionary<string, NHPSource?> {
            { string.Empty, null },
            { Resources.NHPO1, NHPSource.NHPO1 },
            { Resources.NHPO2, NHPSource.NHPO2 },
            { Resources.NHPO3, NHPSource.NHPO3 },
            { Resources.NHPO4, NHPSource.NHPO4 },
            { Resources.NHPO5, NHPSource.NHPO5 },
            { Resources.NHPO6, NHPSource.NHPO6 }
        };

        public static Dictionary<string, GeneticStatus> GeneticStatusStringToEnum = new Dictionary<string, GeneticStatus> {
            { Resources.GS1, GeneticStatus.GS1 },
            { Resources.GS2, GeneticStatus.GS2 },
            { Resources.GS3, GeneticStatus.GS3 }
        };

        public static Dictionary<string, LegislativeRequirements> LegislativeRequirementsStringToEnum = new Dictionary<string, LegislativeRequirements> {
            { string.Empty, LegislativeRequirements.LO1 },
            { Resources.LO1, LegislativeRequirements.LO1 },
            { Resources.LO2, LegislativeRequirements.LO2 },
            { Resources.LO3, LegislativeRequirements.LO3 }
        };

        public static Dictionary<string, TestingByLegislation?> TestingByLegislationStringToEnum = new Dictionary<string, TestingByLegislation?> {
            { string.Empty, null },
            { Resources.LT1, TestingByLegislation.LT1 },
            { Resources.LT2, TestingByLegislation.LT2 },
            { Resources.LT3, TestingByLegislation.LT3 },
            { Resources.LT4, TestingByLegislation.LT4 },
            { Resources.LT5, TestingByLegislation.LT5 },
            { Resources.LT6, TestingByLegislation.LT6 },
            { Resources.LT7, TestingByLegislation.LT7 },
            { Resources.LT8, TestingByLegislation.LT8 },
            { Resources.LT9, TestingByLegislation.LT9 },
            { Resources.LT10, TestingByLegislation.LT10 }
        };

        public static Dictionary<string, PlaceOfBirth> PlaceOfBirthStringToEnum = new Dictionary<string, PlaceOfBirth> {
            { Resources.O1, PlaceOfBirth.O1 },
            { Resources.O2, PlaceOfBirth.O2 },
            { Resources.O3, PlaceOfBirth.O3 },
            { Resources.O4, PlaceOfBirth.O4 }
        };

        public static Dictionary<string, Purpose> PurposeStringToEnum = new Dictionary<string, Purpose>
             {
            { Resources.PB1, Purpose.PB1 },
            { Resources.PB2, Purpose.PB2 },
            { Resources.PB3, Purpose.PB3 },
            { Resources.PB4, Purpose.PB4 },
            { Resources.PB5, Purpose.PB5 },
            { Resources.PB6, Purpose.PB6 },
            { Resources.PB7, Purpose.PB7 },
            { Resources.PB8, Purpose.PB8 },
            { Resources.PB9, Purpose.PB9 },
            { Resources.PB10, Purpose.PB10 },
            { Resources.PB11, Purpose.PB11 },
            { Resources.PB12, Purpose.PB12 },
            { Resources.PB13, Purpose.PB13 },
            { Resources.PT21, Purpose.PT21 },
            { Resources.PT22, Purpose.PT22 },
            { Resources.PT23, Purpose.PT23 },
            { Resources.PT24, Purpose.PT24 },
            { Resources.PT25, Purpose.PT25 },
            { Resources.PT26, Purpose.PT26 },
            { Resources.PT27, Purpose.PT27 },
            { Resources.PT28, Purpose.PT28 },
            { Resources.PT29, Purpose.PT29 },
            { Resources.PT30, Purpose.PT30 },
            { Resources.PT31, Purpose.PT31 },
            { Resources.PT32, Purpose.PT32 },
            { Resources.PT33, Purpose.PT33 },
            { Resources.PT34, Purpose.PT34 },
            { Resources.PT35, Purpose.PT35 },
            { Resources.PT36, Purpose.PT36 },
            { Resources.PT37, Purpose.PT37 },
            { Resources.PE40, Purpose.PE40 },
            { Resources.PS41, Purpose.PS41 },
            { Resources.PE42, Purpose.PE42 },
            { Resources.PF43, Purpose.PF43 },
            { Resources.PG43, Purpose.PG43 },
            { Resources.PR51, Purpose.PR51 },
            { Resources.PR52, Purpose.PR52 },
            { Resources.PR53, Purpose.PR53 },
            { Resources.PR61, Purpose.PR61 },
            { Resources.PR62, Purpose.PR62 },
            { Resources.PR63, Purpose.PR63 },
            { Resources.PR64, Purpose.PR64 },
            { Resources.PR71, Purpose.PR71 },
            { Resources.PR81, Purpose.PR81 },
            { Resources.PR82, Purpose.PR82 },
            { Resources.PR83, Purpose.PR83 },
            { Resources.PR84, Purpose.PR84 },
            { Resources.PR85, Purpose.PR85 },
            { Resources.PR86, Purpose.PR86 },
            { Resources.PR87, Purpose.PR87 },
            { Resources.PR88, Purpose.PR88 },
            { Resources.PR89, Purpose.PR89 },
            { Resources.PR90, Purpose.PR90 },
            { Resources.PR91, Purpose.PR91 },
            { Resources.PR92, Purpose.PR92 },
            { Resources.PR93, Purpose.PR93 },
            { Resources.PR94, Purpose.PR94 },
            { Resources.PR95, Purpose.PR95 },
            { Resources.PR96, Purpose.PR96 },
            { Resources.PR97, Purpose.PR97 },
            { Resources.PR98, Purpose.PR98 },
            { Resources.PR99, Purpose.PR99 },
            { Resources.PR100, Purpose.PR100 },
            { Resources.PR101, Purpose.PR101 },
            { Resources.PR102, Purpose.PR102 },
            { Resources.PR103, Purpose.PR103 },
            { Resources.PR104, Purpose.PR104 },
            { Resources.PR105, Purpose.PR105 },
            { Resources.PR106, Purpose.PR106 },
        };

        public static Dictionary<string, Specie> SpeciesStringToEnum = new Dictionary<string, Specie> {
            { Resources.A1, Specie.A1 },
            { Resources.A2, Specie.A2 },
            { Resources.A3, Specie.A3 },
            { Resources.A4, Specie.A4 },
            { Resources.A5, Specie.A5 },
            { Resources.A6, Specie.A6 },
            { Resources.A7, Specie.A7 },
            { Resources.A8, Specie.A8 },
            { Resources.A9, Specie.A9 },
            { Resources.A10, Specie.A10 },
            { Resources.A11, Specie.A11 },
            { Resources.A12, Specie.A12 },
            { Resources.A13, Specie.A13 },
            { Resources.A14, Specie.A14 },
            { Resources.A15, Specie.A15 },
            { Resources.A16, Specie.A16 },
            { Resources.A17, Specie.A17 },
            { Resources.A18, Specie.A18 },
            { Resources.A19, Specie.A19 },
            { Resources.A20, Specie.A20 },
            { Resources.A21, Specie.A21 },
            { Resources.A22, Specie.A22 },
            { Resources.A23, Specie.A23 },
            { Resources.A24, Specie.A24 },
            { Resources.A25, Specie.A25 },
            { Resources.A26, Specie.A26 },
            { Resources.A27, Specie.A27 },
            { Resources.A28, Specie.A28 },
            { Resources.A29, Specie.A29 },
            { Resources.A30, Specie.A30 },
            { Resources.A31, Specie.A31 },
            { Resources.A32, Specie.A32 },
            { Resources.A33, Specie.A33 },
            { Resources.A34, Specie.A34 },
            { Resources.A35, Specie.A35 },
            { Resources.A36, Specie.A36 }
        };

        public static Dictionary<string, Severity> SeverityStringToEnum = new Dictionary<string, Severity> {
            { Resources.SV1, Severity.SV1 },
            { Resources.SV2, Severity.SV2 },
            { Resources.SV3, Severity.SV3 },
            { Resources.SV4, Severity.SV4 }
        };
    }
}
