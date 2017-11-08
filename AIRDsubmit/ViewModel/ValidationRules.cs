using AIRDsubmit.AIRD.Service;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace AIRDsubmit.ValidationRules
{
    public class RecordValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            foreach(RecordViewModel record in (value as BindingGroup).Items)
                try
                {
                    RecordMapper.RecordToReportingInfo(record.Record);
                }
                catch(Exception e)
                {
                    return new ValidationResult(false, e.Message);
                }
            return ValidationResult.ValidResult;
        }
    }

    public abstract class GenericValidationRule<T> : ValidationRule
    {
        internal abstract Dictionary<string, T> map { get; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                RecordMapper.map(value as string, map);
            }
            catch (Exception e)
            {
                return new ValidationResult(false, e.Message);
            }
            return ValidationResult.ValidResult;
        }
    }

    public class SpeciesValidationRule : GenericValidationRule<Specie>
    {
        internal override Dictionary<string, Specie> map => RecordMapper.SpeciesStringToEnum;
    }

    public class ReuseValidationRule : GenericValidationRule<bool>
    {
        internal override Dictionary<string, bool> map => RecordMapper.ReuseStringToEnum;
    }
    public class PlaceOfBirthValidationRule : GenericValidationRule<PlaceOfBirth>
    {
        internal override Dictionary<string, PlaceOfBirth> map => RecordMapper.PlaceOfBirthStringToEnum;
    }
    public class NHPSourceValidationRule : GenericValidationRule<NHPSource?>
    {
        internal override Dictionary<string, NHPSource?> map => RecordMapper.NHPSourceStringToEnum;
    }
    public class NHPGenerationValidationRule : GenericValidationRule<NHPGeneration?>
    {
        internal override Dictionary<string, NHPGeneration?> map => RecordMapper.NHPGenerationStringToEnum;
    }
    public class GeneticStatusValidationRule : GenericValidationRule<GeneticStatus>
    {
        internal override Dictionary<string, GeneticStatus> map => RecordMapper.GeneticStatusStringToEnum;
    }
    public class CreationOfGeneticLineValidationRule : GenericValidationRule<bool>
    {
        internal override Dictionary<string, bool> map => RecordMapper.CreationOfGeneticLineStringToEnum;
    }
    public class PurposeValidationRule : GenericValidationRule<Purpose>
    {
        internal override Dictionary<string, Purpose> map => RecordMapper.PurposeStringToEnum;
    }
    public class TestingByLegislationValidationRule : GenericValidationRule<TestingByLegislation?>
    {
        internal override Dictionary<string, TestingByLegislation?> map => RecordMapper.TestingByLegislationStringToEnum;
    }
    public class LegislativeRequirementsValidationRule : GenericValidationRule<LegislativeRequirements>
    {
        internal override Dictionary<string, LegislativeRequirements> map => RecordMapper.LegislativeRequirementsStringToEnum;
    }
    public class SeverityValidationRule : GenericValidationRule<Severity>
    {
        internal override Dictionary<string, Severity> map => RecordMapper.SeverityStringToEnum;
    }
}
