using AIRDsubmit.AIRD.Service;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Data;

namespace AIRDsubmit.ValidationRules
{
    public class RecordValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value,
            System.Globalization.CultureInfo cultureInfo)
        {
            foreach(RecordViewModel record in (value as BindingGroup).Items)
                try
                {
                    RecordMapper.RecordToReportingInfo(record.Record);
                    return ValidationResult.ValidResult;
                }
                catch(Exception e)
                {
                    return new ValidationResult(false, e.Message);
                }
            return ValidationResult.ValidResult;
        }
    }

    public class SpeciesValidationRule : GenericValidationRule<Specie>
    {
        internal override Dictionary<string, Specie> map
        {
            get { return RecordMapper.SpeciesStringToEnum; }
        }
    }

    public class ReuseValidationRule : GenericValidationRule<bool>
    {
        internal override Dictionary<string, bool> map
        {
            get { return RecordMapper.ReuseStringToEnum; }
        }
    }
    public class PlaceOfBirthValidationRule : GenericValidationRule<PlaceOfBirth>
    {
        internal override Dictionary<string, PlaceOfBirth> map
        {
            get { return RecordMapper.PlaceOfBirthStringToEnum; }
        }
    }
    public class NHPSourceValidationRule : GenericValidationRule<NHPSource?>
    {
        internal override Dictionary<string, NHPSource?> map
        {
            get { return RecordMapper.NHPSourceStringToEnum; }
        }
    }
    public class NHPGenerationValidationRule : GenericValidationRule<NHPGeneration?>
    {
        internal override Dictionary<string, NHPGeneration?> map
        {
            get { return RecordMapper.NHPGenerationStringToEnum; }
        }
    }

    public class GeneticStatusValidationRule : GenericValidationRule<GeneticStatus>
    {
        internal override Dictionary<string, GeneticStatus> map
        {
            get { return RecordMapper.GeneticStatusStringToEnum; }
        }
    }
    public class CreationOfGeneticLineValidationRule : GenericValidationRule<bool>
    {
        internal override Dictionary<string, bool> map
        {
            get { return RecordMapper.CreationOfGeneticLineStringToEnum; }
        }
    }
    public class PurposeValidationRule : GenericValidationRule<Purpose>
    {
        internal override Dictionary<string, Purpose> map
        {
            get { return RecordMapper.PurposeStringToEnum; }
        }
    }
    public class TestingByLegislationValidationRule : GenericValidationRule<TestingByLegislation?>
    {
        internal override Dictionary<string, TestingByLegislation?> map
        {
            get { return RecordMapper.TestingByLegislationStringToEnum; }
        }
    }
    public class LegislativeRequirementsValidationRule : GenericValidationRule<LegislativeRequirements>
    {
        internal override Dictionary<string, LegislativeRequirements> map
        {
            get { return RecordMapper.LegislativeRequirementsStringToEnum; }
        }
    }
    public class SeverityValidationRule : GenericValidationRule<Severity>
    {
        internal override Dictionary<string, Severity> map
        {
            get { return RecordMapper.SeverityStringToEnum; }
        }
    }


    public abstract class GenericValidationRule<T> : ValidationRule
    {
        internal abstract Dictionary<string, T> map { get; }

        public override ValidationResult Validate(object value,
            System.Globalization.CultureInfo cultureInfo)
        {
            try
            {
                RecordMapper.map(value as string, map);
            }
            catch(Exception e)
            {
                return new ValidationResult(false, e.Message);
            }

            return ValidationResult.ValidResult;
        }
    }
}
