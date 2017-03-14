using System.ComponentModel;

namespace AIRDsubmit
{
    public class RecordViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        public void raisePropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Record Record { private set; get; }

        public RecordViewModel()
        {
            Record = new Record();
        }

        #endregion
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
                    raisePropertyChange("ErrorMessage");
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
                    raisePropertyChange("UploadError");
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
                    raisePropertyChange("Row");
                }
            }
        }

        public bool Uploaded
        {
            get { return Record.Uploaded; }
            set
            {
                if(value != Record.Uploaded)
                {
                    Record.Uploaded = value;
                    raisePropertyChange("Uploaded");
                }
            }
        }
        public string Permission
        {
            get { return Record.Permission; }
            set
            {
                if(value != Record.Permission)
                {
                    Record.Permission = value;
                    raisePropertyChange("Permission");
                }
            }
        }
        public string Species
        {
            get { return Record.Species; }
            set
            {
                if(value != Record.Species)
                {
                    Record.Species = value;
                    raisePropertyChange("Species");
                }
            }
        }
        public string SpeciesOther
        {
            get { return Record.SpeciesOther; }
            set
            {
                if(value != Record.SpeciesOther)
                {
                    Record.SpeciesOther = value;
                    raisePropertyChange("SpeciesOther");
                }
            }
        }
        public string Reuse
        {
            get { return Record.Reuse; }
            set
            {
                if(value != Record.Reuse)
                {
                    Record.Reuse = value;
                    raisePropertyChange("Reuse");
                }
            }
        }
        public string PlaceOfBirth
        {
            get { return Record.PlaceOfBirth; }
            set
            {
                if(value != Record.PlaceOfBirth)
                {
                    Record.PlaceOfBirth = value;
                    raisePropertyChange("PlaceOfBirth");
                }
            }
        }
        public string NHPGeneration
        {
            get { return Record.NHPGeneration; }
            set
            {
                if(value != Record.NHPGeneration)
                {
                    Record.NHPGeneration = value;
                    raisePropertyChange("NHPGeneration");
                }
            }
        }
        public string NHPSource
        {
            get { return Record.NHPSource; }
            set
            {
                if(value != Record.NHPSource)
                {
                    Record.NHPSource = value;
                    raisePropertyChange("NHPSource");
                }
            }
        }
        public string GeneticStatus
        {
            get { return Record.GeneticStatus; }
            set
            {
                if(value != Record.GeneticStatus)
                {
                    Record.GeneticStatus = value;
                    raisePropertyChange("GeneticStatus");
                }
            }
        }
        public string CreationOfGeneticLine
        {
            get { return Record.CreationOfGeneticLine; }
            set
            {
                if(value != Record.CreationOfGeneticLine)
                {
                    Record.CreationOfGeneticLine = value;
                    raisePropertyChange("CreationOfGeneticLine");
                }
            }
        }
        public string Purpose
        {
            get { return Record.Purpose; }
            set
            {
                if(value != Record.Purpose)
                {
                    Record.Purpose = value;
                    raisePropertyChange("Purpose");
                }
            }
        }
        public string PurposeOther
        {
            get { return Record.PurposeOther; }
            set
            {
                if(value != Record.PurposeOther)
                {
                    Record.PurposeOther = value;
                    raisePropertyChange("PurposeOther");
                }
            }
        }
        public string TestingByLegislation
        {
            get { return Record.TestingByLegislation; }
            set
            {
                if(value != Record.TestingByLegislation)
                {
                    Record.TestingByLegislation = value;
                    raisePropertyChange("TestingByLegislation");
                }
            }
        }
        public string TestingByLegislationOther
        {
            get { return Record.TestingByLegislationOther; }
            set
            {
                if(value != Record.TestingByLegislationOther)
                {
                    Record.TestingByLegislationOther = value;
                    raisePropertyChange("TestingByLegislationOther");
                }
            }
        }
        public string LegislativeRequirements
        {
            get { return Record.LegislativeRequirements; }
            set
            {
                if(value != Record.LegislativeRequirements)
                {
                    Record.LegislativeRequirements = value;
                    raisePropertyChange("LegislativeRequirements");
                }
            }
        }
        public string Severity
        {
            get { return Record.Severity; }
            set
            {
                if(value != Record.Severity)
                {
                    Record.Severity = value;
                    raisePropertyChange("Severity");
                }
            }
        }
        public string CustomSeverity
        {
            get { return Record.CustomSeverity; }
            set
            {
                if(value != Record.CustomSeverity)
                {
                    Record.CustomSeverity = value;
                    raisePropertyChange("CustomSeverity");
                }
            }
        }
        public string Comments1
        {
            get { return Record.Comments1; }
            set
            {
                if(value != Record.Comments1)
                {
                    Record.Comments1 = value;
                    raisePropertyChange("Comments1");
                }
            }
        }
        public string Comments2
        {
            get { return Record.Comments2; }
            set
            {
                if(value != Record.Comments2)
                {
                    Record.Comments2 = value;
                    raisePropertyChange("Comments2");
                }
            }
        }
        public int Number
        {
            get { return Record.Number; }
            set
            {
                if(value != Record.Number)
                {
                    Record.Number = value;
                    raisePropertyChange("Number");
                }
            }
        }
        public int Year
        {
            get { return Record.Year; }
            set
            {
                if(value != Record.Year)
                {
                    Record.Year = value;
                    raisePropertyChange("Year");
                }
            }
        }
    }
}
