using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AIRDsubmit
{
    public class RecordViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private void SetAndNotify<T>(T value, object target, string propertyName, [CallerMemberName] string notifyProperty = null)
        {
            var prop = target.GetType().GetProperty(propertyName);
            if (!EqualityComparer<T>.Default.Equals(value, (T)prop.GetValue(target)))
            {
                prop.SetValue(target, value);
                NotifyPropertyChanged(notifyProperty);
            }
        }
        #endregion

        public Record Record { private set; get; }

        public RecordViewModel()
        {
            Record = new Record();
        }

        private string _ErrorMessage;
        public string ErrorMessage
        {
            get { return _ErrorMessage; }
            set
            {
                if(value != _ErrorMessage)
                {
                    _ErrorMessage = value;
                    UploadError = !string.IsNullOrEmpty(value);
                    NotifyPropertyChanged();
                }
            }
        }

        private bool _UploadError;
        public bool UploadError
        {
            get { return _UploadError; }
            private set
            {
                if(value != _UploadError)
                {
                    _UploadError = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private int _Row;
        public int Row
        {
            get { return _Row; }
            set
            {
                if(value != _Row)
                {
                    _Row = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public bool Uploaded
        {
            get { return Record.Uploaded; }
            set { SetAndNotify(value, Record, nameof(Record.Uploaded)); }
        }
        public string Permission
        {
            get { return Record.Permission; }
            set { SetAndNotify(value, Record, nameof(Record.Permission)); }
        }
        public string Species
        {
            get { return Record.Species; }
            set { SetAndNotify(value, Record, nameof(Record.Species)); }
        }
        public string SpeciesOther
        {
            get { return Record.SpeciesOther; }
            set { SetAndNotify(value, Record, nameof(Record.SpeciesOther)); }
        }
        public string Reuse
        {
            get { return Record.Reuse; }
            set { SetAndNotify(value, Record, nameof(Record.Reuse)); }
        }
        public string PlaceOfBirth
        {
            get { return Record.PlaceOfBirth; }
            set { SetAndNotify(value, Record, nameof(Record.PlaceOfBirth)); }
        }
        public string NHPGeneration
        {
            get { return Record.NHPGeneration; }
            set { SetAndNotify(value, Record, nameof(Record.NHPGeneration)); }
        }
        public string NHPSource
        {
            get { return Record.NHPSource; }
            set { SetAndNotify(value, Record, nameof(Record.NHPSource)); }
        }
        public string GeneticStatus
        {
            get { return Record.GeneticStatus; }
            set { SetAndNotify(value, Record, nameof(Record.GeneticStatus)); }
        }
        public string CreationOfGeneticLine
        {
            get { return Record.CreationOfGeneticLine; }
            set { SetAndNotify(value, Record, nameof(Record.CreationOfGeneticLine)); }
        }
        public string Purpose
        {
            get { return Record.Purpose; }
            set { SetAndNotify(value, Record, nameof(Record.Purpose)); }
        }
        public string PurposeOther
        {
            get { return Record.PurposeOther; }
            set { SetAndNotify(value, Record, nameof(Record.PurposeOther)); }
        }
        public string TestingByLegislation
        {
            get { return Record.TestingByLegislation; }
            set { SetAndNotify(value, Record, nameof(Record.TestingByLegislation)); }
        }
        public string TestingByLegislationOther
        {
            get { return Record.TestingByLegislationOther; }
            set { SetAndNotify(value, Record, nameof(Record.TestingByLegislationOther)); }
        }
        public string LegislativeRequirements
        {
            get { return Record.LegislativeRequirements; }
            set { SetAndNotify(value, Record, nameof(Record.LegislativeRequirements)); }
        }
        public string Severity
        {
            get { return Record.Severity; }
            set { SetAndNotify(value, Record, nameof(Record.Severity)); }
        }
        public string CustomSeverity
        {
            get { return Record.CustomSeverity; }
            set { SetAndNotify(value, Record, nameof(Record.CustomSeverity)); }
        }
        public string Comments1
        {
            get { return Record.Comments1; }
            set { SetAndNotify(value, Record, nameof(Record.Comments1)); }
        }
        public string Comments2
        {
            get { return Record.Comments2; }
            set { SetAndNotify(value, Record, nameof(Record.Comments2)); }
        }
        public int Number
        {
            get { return Record.Number; }
            set { SetAndNotify(value, Record, nameof(Record.Number)); }
        }
        public int Year
        {
            get { return Record.Year; }
            set { SetAndNotify(value, Record, nameof(Record.Year)); }
        }
    }
}
